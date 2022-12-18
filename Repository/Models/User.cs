using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP_CORE_BASIC_NET_6_API.Repository.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public bool? IsConnected { get; set; }
        public string? ConnectionId { get; set; }
        public string? Email { get; set; }
        public UserDetails? UserDetails { get; set; }
    }
}