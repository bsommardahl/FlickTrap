namespace FlickTrap.Domain
{
    public interface IUserProfileRepository 
    {
        UserProfile Get(int id);
    }
}