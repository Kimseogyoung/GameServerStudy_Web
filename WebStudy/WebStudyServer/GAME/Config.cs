using System.Net.Sockets;
using System.Net;

namespace WebStudy
{ 
    public static class CONFIG
    {

        public static string ServerIp { get; private set; } = string.Empty;
        public static string EnvName { get; private set; } = string.Empty;
        public static bool UseSwagger { get; private set; }

        public static void Init(IConfiguration config, IHostEnvironment environ)
        {
            ServerIp = GetServerIp();
            EnvName = environ.EnvironmentName;

            UseSwagger = config.GetValue("UseSwagger", false);
        }

        private static string GetServerIp()
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
