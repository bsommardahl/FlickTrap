using System;
using System.Collections.Generic;

namespace FlickTrap.Web.Models
{
    public class SearchViewModel
    {
        public SearchViewModel()
        {
            Flicks = new List<FlickListingViewModel>();
        }

        public IEnumerable<FlickListingViewModel> Flicks { get; set; }
        public string SearchText { get; set; }
    }
}