using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic.FileIO;
using SharpYaml;
using System;
using System.Net;
using WebStudy.Service.Singleton;
using WebStudyServer;
using WebStudyServer.Base;

namespace WebStudy
{
    public partial class Startup
    {
        public void Resource(IServiceCollection services)
        {
            services.AddMemoryCache();

            AddDbContextFactory<UserDbContext>(services);
            AddDbContextFactory<AuthDbContext>(services);
        }

        // 임시. 아직 안 돌아감.
        private void AddDbContextFactory<TDbContext>(IServiceCollection services) where TDbContext : DbContextBase
        {
            using var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetRequiredService<ILogger<DbContextFactory<TDbContext>>>();

            var dbCtxFactory = new DbContextFactory<TDbContext>((optionBuilder, connectStr) =>
            {
                optionBuilder
                    .UseMySql(connectStr, CONFIG.DbVersion, options =>
                    {
                        options.EnableRetryOnFailure(10, TimeSpan.Zero, null);
                    });
                    //.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning));

            }, logger);
            services.AddSingleton(dbCtxFactory);
        }
    }
}
