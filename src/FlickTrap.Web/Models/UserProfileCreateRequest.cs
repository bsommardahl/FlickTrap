namespace FlickTrap.Web.Models
{
    public class UserProfileCreateRequest
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password1 { get; set; }
        public string Password2 { get; set; }
    }
}