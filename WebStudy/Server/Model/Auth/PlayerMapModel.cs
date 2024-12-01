using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStudyServer.Model.Auth
{
    public class PlayerMapModel : ModelBase
    {
        public ulong AccountId { get; set; }

        public ulong PlayerId { get; set; }

        public int ShardId { get; set; }
    }
}
