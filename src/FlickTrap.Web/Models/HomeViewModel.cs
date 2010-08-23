using System;
using System.Collections.Generic;
using FlickTrap.Domain;

namespace FlickTrap.Web.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            RecentlyReleasedFlicks = new List<FlickListingViewModel>();
            UnreleasedFlicks = new List<FlickListingViewModel>();
        }

        public IEnumerable<FlickListingViewModel> RecentlyReleasedFlicks { get; set; }
        public IEnumerable<FlickListingViewModel> UnreleasedFlicks { get; set; }
    }
}