namespace FlickTrap.Domain.Abstract
{
    public interface IUserProfileRepository 
    {
        UserProfile GetUserProfile(string username);
        void Save(UserProfile userProfile);
    }
}