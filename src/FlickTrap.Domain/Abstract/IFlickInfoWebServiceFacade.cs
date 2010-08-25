using System.Collections.Generic;

namespace FlickTrap.Domain.Abstract
{
    public interface IFlickInfoWebServiceFacade
    {
        Flick DownloadFlickInfo(string remoteId);
        IEnumerable<Flick> Search(string searchText);
    }
}