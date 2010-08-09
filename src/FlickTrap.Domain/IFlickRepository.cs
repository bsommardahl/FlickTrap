using System.Collections.Generic;

namespace FlickTrap.Domain
{
    public interface IFlickRepository
    {
        IEnumerable<Flick> GetRecentlyReleased();
        IEnumerable<Flick> GetUnreleasedFlicks();
    }
}