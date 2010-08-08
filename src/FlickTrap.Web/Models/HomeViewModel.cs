using System;
using System.Collections.Generic;

namespace FlickTrap.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<FlickListingViewModel> RecentlyReleasedFlicks { get; set; }
        public IEnumerable<FlickListingViewModel> UnreleasedFlicks { get; set; }
    }
}