using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStudyServer.Model.Auth
{
    public class AccountModel : ModelBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Id { get; set; }

        public int ShardId { get; set; }

        public int State { get; set; } = 0;

        public string ClientSecret { get; set; }

        public int AdditionalPlayerCount { get; set; }

        public ulong Flag { get; set; }
    }
}
