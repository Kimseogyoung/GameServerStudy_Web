using ProtoBuf;

namespace Protocol
{
	[ProtoContract]
	public partial class GameEnterReqPacket : IReqPacket
	{
    
        [ProtoMember(1)]
        public ReqInfoPacket Info { get; set; } 
        
        public string GetProtocolName() => "game/enter";
	}
}
