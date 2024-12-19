using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
    public class DebugTestRequestPacket : BaseRequestPacket
    {
        public const string NAME = "debug/test";
        public override string GetProtocolName() => NAME;
    }

    public class DebugTestResponsePacket : BaseResponsePacket
    {
    }
}
