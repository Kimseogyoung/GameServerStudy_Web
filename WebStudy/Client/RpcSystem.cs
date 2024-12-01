using Microsoft.EntityFrameworkCore.Metadata;
using NLog;
using Proto;
using Protocol;
using SharpYaml.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Client
{
    public class RpcSystem
    {
        public void Init(string host, string contentType)
        {
            _host = host.Trim('/');
            _contentType = contentType;
            _httpClient = new HttpClient { Timeout = TimeSpan.FromMinutes(2) };
        }

        public void Clear()
        {
            //_httpClient = null;
        }

        public void SetSessionKey(string key)
        {
            _sessionKey = key;
        }

        public async Task<RES> RequestAsync<REQ, RES>(REQ req)
            where REQ : IReqPacket, new()
            where RES : IResPacket, new()
        {
            // 요청 URL
            var protocolName = req.GetProtocolName();
            var url = $"{_host}/{protocolName}";

            // 요청 데이터 (JSON 형식)
            var reqBodyString = Serialize<REQ>(req);
            var content = new StringContent(reqBodyString, Encoding.UTF8, _contentType);

            // POST 요청 보내기
            var response = await _httpClient.PostAsync(url, content);

            // 응답 처리
            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                var res = Deserialize<RES>(responseData);
                Console.WriteLine("응답: " + responseData);
                return res;
            }
            else
            {
                // TODO: 예외처리
                Console.WriteLine($"에러: {response.StatusCode}");
                string responseData = await response.Content.ReadAsStringAsync();
                var errorRes = Deserialize<ErrorResponsePacket>(responseData);
                var res = new RES();
                res.Info = errorRes.Info;
                return res;
            }
        }

        private string Serialize<REQ>(REQ obj)
        {
            switch (_contentType)
            {
                case MsgProtocol.JsonContentType:
                    var json = JsonSerializer.Serialize<REQ>(obj);
                    return json;
                case MsgProtocol.ProtoBufContentType:
                    byte[] serializedData;
                    using (var ms = new MemoryStream())
                    {
                        ProtoBuf.Serializer.Serialize(ms, obj);
                        serializedData = ms.ToArray();
                    }
                    var protoBufStr = Encoding.UTF8.GetString(serializedData);
                    return protoBufStr;
                default:
                    break;
            }
            return string.Empty;
        }

        private RES Deserialize<RES>(string data) where RES : IResPacket, new()
        {
            var res = new RES();
            res.Info.ResultCode = (int)EErrorCode.NO_HANDLING_ERROR;
            res.Info.ResultMsg = "FAILED_DESERIALIZE";
            switch (_contentType)
            {
                case MsgProtocol.JsonContentType:
                    res = JsonSerializer.Deserialize<RES>(data);
                    break;
                case MsgProtocol.ProtoBufContentType:
                    var byteArr = Encoding.UTF8.GetBytes(data);
                    using (var ms = new MemoryStream(byteArr))
                    {
                        res = ProtoBuf.Serializer.Deserialize<RES>(ms);
                    }
                    break;
                default:
                    break;
            }

            if(res == null)
            {
                throw new Exception("FAILED_DESERIALIZE ~~~~~");
            }

            return res;
        }

        private long GetTimestamp()
        {
            var nowTime = DateTime.UtcNow;
            var timestmap = ((DateTimeOffset)nowTime).ToUnixTimeMilliseconds();
            if ( _prevTimestamp == timestmap)
            {
                timestmap += 1;
            }

            _prevTimestamp = timestmap;
            return timestmap;
        }

        private long _prevTimestamp = 0;
        private long _seq = 0;
        private string _sessionKey = string.Empty;

        private string _host = string.Empty;
        private string _contentType = string.Empty;
        private HttpClient _httpClient;

        private static readonly DateTime s_timestampBaseTime = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
    }
}
