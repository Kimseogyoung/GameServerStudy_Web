using WebStudyServer.Base;

namespace WebStudyServer.Repo
{
    public class AuthRepo : RepoBase
    {
        protected override List<string> DbConnStrList => CONFIG.AuthDbConnectionStrList;
    }
}
