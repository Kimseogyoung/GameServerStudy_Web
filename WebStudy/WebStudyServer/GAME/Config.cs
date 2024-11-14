using System.Net.Sockets;
using System.Net;
using Microsoft.EntityFrameworkCore;
using WebStudyServer.StartUp;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace WebStudyServer
{ 
    public class Config
    {
        public string LogFolder { get; private set; } = string.Empty;
        public LogLevel LogLevel { get; private set; } = LogLevel.Debug;
        public int ServerNum { get; private set; } = -1;
        public string ServerIp { get; private set; } = string.Empty;
        public string EnvName { get; private set; } = string.Empty;
        public bool UseSwagger { get; private set; }
        public MySqlServerVersion? DbVersion { get; private set; }
        public List<string> UserDbConnectionStrList { get; private set; } = new();
        public List<string> AuthDbConnectionStrList { get; private set; } = new();
        public TimeSpan SessionExpireSpan { get; private set; } = new();
        public void Init(IConfiguration config, IHostEnvironment environ)
        {
            ServerIp = GetServerIp();
            EnvName = environ.EnvironmentName;

            UseSwagger = config.GetValue("UseSwagger", false);

            SessionExpireSpan = config.GetValue("SessionExpireSpan", TimeSpan.FromMinutes(20));

            DbVersion = new MySqlServerVersion(config.GetValue("Db:Version", "0.0.0"));
            UserDbConnectionStrList = config.GetValueStringList("Db:UserDb:ConnectionStrList");
            AuthDbConnectionStrList = config.GetValueStringList("Db:AuthDb:ConnectionStrList");

            LogFolder = config.GetValue("Logging:Folder", "logs");
            LogLevel = config.GetValue("Logging:Level", LogLevel.Debug);
        }

        private string GetServerIp()
        {
            // 호스트 이름 가져오기
            var hostName = Dns.GetHostName();

            // 호스트 정보 가져오기
            var addresses = Dns.GetHostAddresses(hostName);

            // 첫 번째 IPv4 주소 출력
            foreach (var ip in addresses)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return "";
        }
    }
}
