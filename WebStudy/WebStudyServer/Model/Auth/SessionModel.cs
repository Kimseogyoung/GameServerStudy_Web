using Proto;

namespace WebStudyServer.Model.Auth
{
    public class SessionModel : ModelBase
    {
        public string Key { get; set; }

        public ulong AccountId { get; set; }

        public ulong PlayerId { get; set; }

        public int ShardId { get; set; }

        public string Idfv { get; set; }

        public long ExpireTimestamp { get; set; }

        public ESessionState State { get; set; }

        public string ClientSecret { get; set; }

        public byte[] EncryptSecret { get; set; }

        public byte[] EncryptIV { get; set; }

        public string PublicIp { get; set; }
    }
}
