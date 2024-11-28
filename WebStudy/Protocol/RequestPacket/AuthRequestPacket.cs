using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace Protocol
{ 
    [ProtoContract]
    public class AuthSignUpReqPacket : BaseRequestPacket
    {
        [ProtoMember(1)]
        public string DeviceKey { get; set; }

        public override string GetProtocolName() => "auth/sign-up";
    }

    public class AuthSignInReqPacket : BaseRequestPacket
    {
        public string ChannelId { get; set; }
        public override string GetProtocolName() => "auth/sign-in";
    }
}
