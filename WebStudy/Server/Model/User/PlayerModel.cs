using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStudyServer;

namespace WebStudyServer.Model.User
{
    public class PlayerModel
    {
        public ulong Id { get; set; } = default;

        public ulong AccountId { get; set; } = default;

        [MaxLength(30)]
        public string ProfileName { get; set; } = "NO_NAME";

        public int Lv { get; set; } = DEF.DEFAULT_LV;

    }
}
