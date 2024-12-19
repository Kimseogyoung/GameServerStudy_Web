using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStudyServer.Model;

namespace WebStudyServer
{
    public class PlayerMapModel : ModelBase
    {
        public ulong AccountId { get; set; }

        public ulong PlayerId { get; set; }

        public int ShardId { get; set; }
    }
}
