using System.Collections.Generic;

namespace FlickTrap.Domain.Abstract
{
    public interface IFlickInfoService
    {
        IEnumerable<Flick> GetRecentlyReleasedFlicks();
        IEnumerable<Flick> GetUnreleasedFlicks();
        Flick GetFlick(string username, string imdbId);
        void Trap(string username, string imdbId);
        void Untrap(string username, string imdbId);
        IEnumerable<Flick> Search(string searchText);
    }
}