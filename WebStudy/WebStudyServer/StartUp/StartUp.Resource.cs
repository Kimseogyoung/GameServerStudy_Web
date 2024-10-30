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
using WebStudyServer.GAME;

namespace WebStudyServer
{
    public partial class Startup
    {
        public void Resource(IServiceCollection services)
        {
            services.AddMemoryCache();
            AddRepo<UserRepo>(services);
            AddRepo<AuthRepo>(services);
        }

        private void AddRepo<TRepo>(IServiceCollection services) where TRepo : RepoBase
        {
            using var serviceProvider = services.BuildServiceProvider();
            services.AddScoped<TRepo>();
        }

        private void ConnectionTest()
        {
            foreach (var connectionStr in APP.Cfg.UserDbConnectionStrList)
            {
                var excutor = DBSqlExecutor.Create(connectionStr, System.Data.IsolationLevel.ReadCommitted);
                excutor.Commit();
            }

            foreach (var connectionStr in APP.Cfg.AuthDbConnectionStrList)
            {
                var excutor = DBSqlExecutor.Create(connectionStr, System.Data.IsolationLevel.ReadCommitted);
                excutor.Commit();
            }
        }
    }
}
