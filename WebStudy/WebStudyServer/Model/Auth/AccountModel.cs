using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStudyServer.Model.Auth
{
    [Table("Account"), PrimaryKey("Id")]
    public class AccountModel : ModelBase
    {
        public ulong Id { get; set; } = default;
    }
}
