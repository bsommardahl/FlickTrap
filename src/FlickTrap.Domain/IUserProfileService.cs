namespace FlickTrap.Domain
{
    public interface IUserProfileService
    {
        UserProfile CreateUserProfile(UserProfile userProfile);
        UserProfile GetUserProfile(int userProfileId);
        UserProfile UpdateUserProfile(UserProfile userProfile);
        bool Validate(string username, string password);
        UserProfile GetUserProfile(string userName);
    }
}