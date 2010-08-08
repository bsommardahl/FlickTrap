namespace FlickTrap.Domain
{
    public interface IUserProfileRepository 
    {
        UserProfile Read(int id);
        UserProfile Create(UserProfile userProfile);
        UserProfile Update(UserProfile userProfile);
        void Delete(UserProfile userProfile);
    }
}