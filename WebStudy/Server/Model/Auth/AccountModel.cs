using Microsoft.EntityFrameworkCore;
using Proto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStudyServer.Model.Auth
{
    public class AccountModel : ModelBase
    {
        public ulong Id { get; set; }

        public int ShardId { get; set; }

        public EAccountState State { get; set; } = 0;

        public string ClientSecret { get; set; }

        public int AdditionalPlayerCnt { get; set; }

        public ulong Flag { get; set; }
    }
}
