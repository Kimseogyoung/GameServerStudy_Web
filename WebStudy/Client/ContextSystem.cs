using NLog.LayoutRenderers.Wrappers;
using Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ContextSystem
    {
        public void Init()
        {
            _rpcSystem = new RpcSystem();
            _rpcSystem.Init("http://localhost:5157", MsgProtocol.JsonContentType);
        }

        public void Clear()
        {

        }

        public async Task RequestSignUpAsync(string deviceKey)
        {
            var req = new AuthSignUpReqPacket
            {
                DeviceKey = deviceKey
            };

            var res = await _rpcSystem.RequestAsync<AuthSignUpReqPacket, AuthSignUpResPacket>(req);
            Console.WriteLine(res.SessionKey);
        }

        private RpcSystem _rpcSystem;
    }
}
