using System.ComponentModel.DataAnnotations;

namespace FlickTrap.Web.Models
{
    public class UserProfileCreateRequest
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Password)]
        public string Password1 { get; set; }

        [DataType(DataType.Password)]
        public string Password2 { get; set; }
    }
}