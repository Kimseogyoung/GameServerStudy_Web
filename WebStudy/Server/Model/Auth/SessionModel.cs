using Proto;

namespace WebStudyServer.Model
{
    public class SessionModel : ModelBase
    {
        public string Key { get; set; }

        public ulong AccountId { get; set; }

        public ulong PlayerId { get; set; }

        public int ShardId { get; set; }

        public string DeviceKey { get; set; }

        public long ExpireTimestamp { get; set; }

        public ESessionState State { get; set; }

        public string ClientSecret { get; set; }

        public string EncryptSecret { get; set; }

        public string EncryptIV { get; set; }

        public string PublicIp { get; set; }
    }
}
