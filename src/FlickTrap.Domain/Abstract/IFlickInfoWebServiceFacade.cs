using System.Collections.Generic;

namespace FlickTrap.Domain.Abstract
{
    public interface IFlickInfoWebServiceFacade
    {
        Flick DownloadFlickInfo(string imdbId);
        IEnumerable<Flick> Search(string searchText);
    }
}