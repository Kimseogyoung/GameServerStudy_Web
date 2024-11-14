using Microsoft.EntityFrameworkCore;
using Proto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStudyServer.Model.Auth
{
    public class DeviceModel : ModelBase
    {
        public string Key { get; set; } // Key
        public ulong AccountId { get; set; }
        public string Idfa { get; set; }
        public string GeoIpCountry { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public EDeviceState State { get; set; } = 0;
    }
}
