using WebStudyServer.GAME;

namespace WebStudyServer.Helper
{
    public static class IdHelper
    {
        public static string GenerateGuidKey()
        {
            var guid = Guid.NewGuid();
            return guid.ToString();
        }

        public static ulong GenerateSfId()
        {
            var id = (ulong)APP.IdGenerator.CreateId();
            return id;
        }
    }
}
