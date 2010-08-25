using System.Collections.Generic;

namespace FlickTrap.Domain.Abstract
{
    public interface IFlickInfoService
    {
        IEnumerable<Flick> GetRecentlyReleasedFlicks();
        IEnumerable<Flick> GetUnreleasedFlicks();
        Flick GetFlick(string username, string remoteId);
        void Trap(string username, string remoteId);
        void Untrap(string username, string remoteId);
        IEnumerable<Flick> Search(string searchText);
    }
}