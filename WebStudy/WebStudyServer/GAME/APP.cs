using IdGen;

namespace WebStudyServer.GAME
{
    public static class APP
    {
        public static Config Cfg => _cfg;
        public static IdGenerator IdGenerator => _idGen;

        public static void Init(IConfiguration config, IHostEnvironment environ)
        {
            _cfg.Init(config, environ);

            var workerId = Cfg.ServerNum == -1 ? new Random().Next(1024) : Cfg.ServerNum;
            _idGen = new IdGenerator(workerId);
        }

        private static IdGenerator _idGen = null;
        private static Config _cfg = new Config();
    }
}
