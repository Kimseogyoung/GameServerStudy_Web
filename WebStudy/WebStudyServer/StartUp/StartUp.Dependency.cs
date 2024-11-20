using Microsoft.OpenApi.Models;
using System.Net;
using WebStudyServer.Component;
using WebStudyServer.Filter;
using WebStudyServer.Manager;
using WebStudyServer.Service;

namespace WebStudyServer
{
    public partial class Startup
    {
        public void Dependency(IServiceCollection services)
        {
            AddMiddlewares(services);
            AddFilters(services);
            AddServices(services);

            AddController(services);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }

        private void AddMiddlewares(IServiceCollection services)
        {
        }

        private void AddFilters(IServiceCollection services)
        {
            services.AddScoped<LogFilter>();
            services.AddScoped<AuthTransactionFilter>();
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddScoped<ErrorHandler>();

            services.AddScoped<AuthService>();

            services.AddScoped<AuthComponent>();
            services.AddScoped<AccountComponent>();
            services.AddScoped<ChannelComponent>();
            services.AddScoped<DeviceComponent>();
            services.AddScoped<SessionComponent>();
            services.AddScoped<RpcContext>();
        }

        private void AddController(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.InputFormatters.Insert(0, new CustomInputFormatter());
                options.OutputFormatters.Insert(0, new CustomOutputFormatter());
            });

            //net 6.0
/*            ).AddMvcOptions(options =>
            {
                options.InputFormatters.Insert(0, new CustomInputFormatter());
                options.OutputFormatters.Insert(0, new CustomOutputFormatter());
            });*/
        }

    }
}
