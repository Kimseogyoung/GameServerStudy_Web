
namespace WebStudyServer.Model.Auth
{
    public class ChannelModel : ModelBase
    {
        public string Id { get; set; }
        public ulong AccountId { get; set; }
        public int Type { get; set; }
        public string Token { get; set; }
        public int State { get; set; }
    }
}
