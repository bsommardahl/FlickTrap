using System;

namespace FlickTrap.Domain
{
    public class Flick : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual string Rating { get; set; }
        public virtual decimal UserRating { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? TheaterReleaseDate { get; set; }
        public virtual DateTime? RentalReleaseDate { get; set; }
        public virtual string ThumbnailUrl { get; set; }
        public virtual decimal Revenue { get; set; }
        public virtual decimal Budget { get; set; }
        public virtual string RemoteId { get; set; }
        public virtual bool IsTrapped { get; set; }
    }
}