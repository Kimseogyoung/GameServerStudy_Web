using Microsoft.OpenApi.Models;
using System.Net;
using WebStudyServer.Filter;

namespace WebStudyServer
{
    public partial class Startup
    {
        public void Dependency(IServiceCollection services)
        {
            AddMiddlewares(services);
            AddFilters(services);
            AddServices(services);

            services.AddExceptionHandler<ErrorHandler>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private void AddMiddlewares(IServiceCollection services)
        {
        }

        private void AddFilters(IServiceCollection services)
        {
            services.AddScoped<LogFilter>();
        }

        private void AddServices(IServiceCollection services)
        {
        }
    }
}
