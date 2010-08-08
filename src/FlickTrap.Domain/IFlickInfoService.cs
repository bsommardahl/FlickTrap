using System.Collections.Generic;

namespace FlickTrap.Domain
{
    public interface IFlickInfoService
    {
        IEnumerable<Flick> GetRecentlyReleasedFlicks();
        IEnumerable<Flick> GetUnreleasedFlicks();
        Flick GetFlick(string imdbId);
    }
}