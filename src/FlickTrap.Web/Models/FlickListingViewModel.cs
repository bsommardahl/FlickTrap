using System;

namespace FlickTrap.Web.Models
{
    public class FlickListingViewModel
    {
        public string Name { get; set; }
        public string Rating { get; set; }
        public decimal UserRating { get; set; }
        public string ThumbnailUrl { get; set; }
        public string ImdbId { get; set; }
    }
}