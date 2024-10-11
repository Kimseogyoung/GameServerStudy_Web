using Microsoft.OpenApi.Models;
using System.Net;

namespace WebStudyServer
{
    public partial class Startup
    {
        public void Dependency(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
