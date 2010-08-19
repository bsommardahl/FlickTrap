namespace FlickTrap.Domain.Abstract
{
    public interface IUserProfileRepository 
    {
        UserProfile GetUserProfile(string username);
        UserProfile Save(UserProfile userProfile);
    }
}