namespace FlickTrap.Domain.Abstract
{
    public interface IUserProfileRepository 
    {
        UserProfile GetUserProfile( int userProfileId );
        UserProfile GetUserProfile( string username );
        UserProfile Save(UserProfile userProfile);
    }
}