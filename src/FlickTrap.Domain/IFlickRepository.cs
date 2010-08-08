namespace FlickTrap.Domain
{
    public interface IFlickRepository
    {
        Flick Get(int id);
        void Add(Flick flick);
    }
}