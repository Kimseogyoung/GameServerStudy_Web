using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStudyServer.Model.Auth
{
    [Table("Account"), PrimaryKey("Id")]
    public class PlayerMapModel : ModelBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong AccountId { get; set; }

        public ulong PlayerId { get; set; }

        public int ShardId { get; set; }
    }
}
