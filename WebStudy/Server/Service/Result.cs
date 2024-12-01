using Proto;
using System.ComponentModel.DataAnnotations;

namespace WebStudyServer.Service
{
    public class AuthSignUpResult
    {
        public string SessionKey { get; set; }
        public string ChannelKey { get; set; }
        public string ClientSecret { get; set; }
        public string AccountEnv { get; set; }
        public EAccountState AccountState { get; set; }
        //[Key(5)]
        //public string AppGuardUniqueId { get; set; }
    }

    public class AuthSignInResult
    {
        public string SessionKey { get; set; }
        public string ChannelKey { get; set; }
        public string ClientSecret { get; set; }
        public string AccountEnv { get; set; }
        public EAccountState AccountState { get; set; }
    }
}
