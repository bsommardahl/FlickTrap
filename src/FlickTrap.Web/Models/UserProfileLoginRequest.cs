using System.ComponentModel.DataAnnotations;

namespace FlickTrap.Web.Models
{
    public class UserProfileLoginRequest
    {
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}