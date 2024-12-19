using Microsoft.EntityFrameworkCore;
using Proto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStudyServer;

namespace WebStudyServer.Model
{
    public class PlayerModel : ModelBase
    {
        public ulong Id { get; set; } = default;
        public ulong AccountId { get; set; } = default;
        public ulong SfId { get; set; } = default;
        [MaxLength(30)]
        public string ProfileName { get; set; } = "NO_NAME";
        public int Lv { get; set; } = DEF.DEFAULT_LV;
        public EPlayerState State { get; set; } = default;
        public ulong Flag { get; set; } = default;
        public ulong Exp { get; set; } = default;
        public int AccExp { get; set; } = default;
        public int ProfileTitleName { get; set; } = default;
        public int ProfileIconNum { get; set; } = default;
        public int ProfileFrameNum { get; set; } = default;
        public int ProfileCookieNum { get; set; } = default;
        public ulong GuildId { get; set; } = default;
        public double KingdomExp { get; set; } = default;
        public double Gold { get; set; } = default;
        public double AccGold { get; set; } = default;
        public double RealCash { get; set; } = default;
        public double FreeCash { get; set; } = default;
        public double AccRealCash{ get; set; } = default;
        public double AccFreeCash { get; set; } = default;

    }
}
