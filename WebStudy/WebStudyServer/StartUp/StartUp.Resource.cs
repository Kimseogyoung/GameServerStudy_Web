using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic.FileIO;
using SharpYaml;
using System;
using System.Net;
using WebStudyServer.Service.Singleton;
using WebStudyServer;
using WebStudyServer.Base;
using WebStudyServer.Repo;
using WebStudyServer.Repo.Database;

namespace WebStudyServer
{
    public partial class Startup
    {
        public void Resource(IServiceCollection services)
        {
            services.AddMemoryCache();
            AddRepo<UserRepo>(services);

            foreach (var connectionStr in CONFIG.UserDbConnectionStrList)
            {
                var excutor = DBSqlExecutor.Create(connectionStr, System.Data.IsolationLevel.ReadCommitted);
                excutor.Commit();
            }
        }

        private void AddRepo<TRepo>(IServiceCollection services) where TRepo : RepoBase
        {
            using var serviceProvider = services.BuildServiceProvider();
            services.AddScoped<TRepo>();
        }
    }
}
