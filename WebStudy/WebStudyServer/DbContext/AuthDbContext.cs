using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Numerics;
using WebStudyServer.Base;

namespace WebStudyServer
{
    public class AuthDbContext : DbContextBase
    {
        public AuthDbContext(DbContextOptions options)
        {
        }
    }
}
