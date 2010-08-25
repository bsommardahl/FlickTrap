using System;
using System.Collections.Generic;
using FlickTrap.Domain;

namespace FlickTrap.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<FlickListingViewModel> Trapped { get; set; }
    }
}