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

    }
}
