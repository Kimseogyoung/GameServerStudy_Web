using Microsoft.AspNetCore.Mvc.Rendering;
using NLog;
using Protocol;
using System.Text;
using System.Text.Json;
using WebStudyServer.GAME;

namespace WebStudyServer.Helper
{
    public static class SerializeHelper
    {
        public static string JsonSerialize(object obj)
        {
            var json = JsonSerializer.Serialize(obj);
            return json;
        }

        public static T JsonDeserialize<T>(string json)
        {
            var obj = JsonSerializer.Deserialize<T>(json);
            return obj;
        }

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    }
}
