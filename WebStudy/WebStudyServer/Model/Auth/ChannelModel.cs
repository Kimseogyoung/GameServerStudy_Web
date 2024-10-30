
using Proto;

namespace WebStudyServer.Model.Auth
{
    public class ChannelModel : ModelBase
    {
        public string Key { get; set; }
        public ulong AccountId { get; set; }
        public EChannelType Type { get; set; }
        public string Token { get; set; }
        public EChannelState State { get; set; }
    }
}
