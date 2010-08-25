using System;
using System.Linq;
using AutoMapper;
using FlickTrap.Domain;

namespace FlickTrap.Web.Models
{
    public class FlickDetailsViewModel
    {
        public decimal Budget { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public DateTime? RentalReleaseDate { get; set; }
        public decimal Revenue { get; set; }
        public DateTime? TheaterReleaseDate { get; set; }
        public bool IsTrapped { get; set; }
        public string Stars { get; set; }
        public string RemoteId { get; set; }
        public string ThumbnailUrl { get; set; }
        public bool IsTrappable { get; set; }

        public static FlickDetailsViewModel Map(Flick flick, UserProfile userProfile)
        {
            FlickDetailsViewModel viewModel = Mapper.Map<Flick, FlickDetailsViewModel>(flick);
            viewModel.Stars = GetStars(flick.UserRating);
            if( userProfile != null )
            {
                viewModel.IsTrappable = true;
                viewModel.IsTrapped = userProfile.Trapped.Any(x => x.RemoteId == flick.RemoteId);
            }

            return viewModel;
        }

        private static string GetStars(decimal source)
        {
            var viewModel = new FlickDetailsViewModel();
            decimal rating = Math.Round(source/2);
            switch (Convert.ToInt16(rating))
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
            }
            return "none";
        }
    }
}