using System;

namespace FlickTrap.Web.Models
{
    public class FlickDetailsViewModel
    {
        public decimal Budget { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public DateTime RentalReleaseDate { get; set; }
        public decimal Revenue { get; set; }
        public DateTime TheaterReleaseDate { get; set; }
        public decimal UserRating { get; set; }
        public bool IsTrapped { get; set; }
    }
}