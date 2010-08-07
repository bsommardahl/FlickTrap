namespace FlickTrap.Domain
{
    public interface IFlickRepository
    {
        Flick Get(int id);
    }
}