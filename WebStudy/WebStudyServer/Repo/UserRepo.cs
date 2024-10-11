using WebStudyServer.Base;
using WebStudyServer.Repo.Database;

namespace WebStudyServer.Repo
{
    public class UserRepo : RepoBase
    {
        protected override List<string> DbConnStrList => CONFIG.UserDbConnectionStrList;

    }
}
