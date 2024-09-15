using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WebStudyServer.Base;

namespace WebStudyServer
{
    public class UserDbContext : DbContextBase
    {
        public UserDbContext(DbContextOptions options)
        {
        }
    }
}
