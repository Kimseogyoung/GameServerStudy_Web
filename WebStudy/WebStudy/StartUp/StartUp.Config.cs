using WebFramework.Config;

namespace WebStudy
{
    public partial class Startup
    {
        public void Config(WebApplicationBuilder builder, string workPath = "")
        {
            workPath = string.IsNullOrEmpty(workPath)? Directory.GetCurrentDirectory() : workPath;

            builder.Configuration
             .SetBasePath(workPath)
             .AddYamlFile("appsettings.yaml", optional: false)      
             .AddYamlFile($"appsettings.{builder.Environment.EnvironmentName}.yaml", optional: true)
             .AddEnvironmentVariables();

            CONFIG.Init(builder.Configuration, builder.Environment);
        }
    }
}
