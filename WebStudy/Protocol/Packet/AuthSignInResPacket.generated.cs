using ProtoBuf;

namespace Protocol
{
	[ProtoContract]
	public partial class AuthSignInResPacket : IResPacket
	{
    
        [ProtoMember(1)]
        public ResInfoPacket Info { get; set; }
        
        [ProtoMember(2)]
        public string SessionKey { get; set; }
        
	}
}
