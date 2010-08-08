using System;

namespace FlickTrap.Domain
{
    public class Flick
    {
        public string Name { get; set; }
        public string Rating { get; set; }
        public decimal UserRating { get; set; }
        public string Description { get; set; }
        public DateTime TheaterReleaseDate { get; set; }
        public DateTime RentalReleaseDate { get; set; }
        public string ThumbnailUrl { get; set; }
        public decimal Revenue { get; set; }
        public decimal Budget { get; set; }
        public string ImdbId { get; set; }
    }
}