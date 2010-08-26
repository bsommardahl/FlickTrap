using System.ComponentModel.DataAnnotations;

namespace FlickTrap.Web.Models
{
    public class UserProfileCreateRequest
    {
        [Display(Name = "Login Username")]
        [Required]
        public string Username { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        public string EmailAddress { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required]
        public string Password1 { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Repeat Password")]
        [Required]
        public string Password2 { get; set; }
    }
}