using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
    public static class MsgProtocol
    {
        // content-type
        public static List<string> ContentTypeList = new List<string>() { JsonContentType/*, MsgPackProtocol*/ };

        public const string JsonProtocol = "json";
        public const string MsgPackProtocol = "x-msgpack";

        public const string JsonContentType = c_contentTypePrefix + JsonProtocol;
        public const string MsgPackContentType = c_contentTypePrefix + MsgPackProtocol;

        private const string c_contentTypePrefix = "application/";


        // query
        public const string Query_SessionKey = "sessionKey";
        public const string Query_Timestamp = "timestamp";
        public const string Query_Seq = "seq";
    }
}
