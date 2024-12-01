using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
    [ProtoContract]
    public class ErrorResponsePacket : IResPacket
    {
        [ProtoMember(1)]
        public ResInfoPacket Info { get; set; }
    }
}
