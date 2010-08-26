using System;
using System.Linq;
using AutoMapper;
using FlickTrap.Domain;

namespace FlickTrap.Web.Models
{
    public class FlickListingViewModel
    {
        public string Name { get; set; }
        public string Rating { get; set; }
        public string Stars { get; set; }
        public string ThumbnailUrl { get; set; }
        public string RemoteId { get; set; }
        public DateTime TheaterReleaseDate { get; set; }
        public bool IsTrapped { get; set; }
        public bool IsTrappable { get; set; }

        public static FlickListingViewModel MapFromFlick(Flick flick, string userName)
        {
            var viewModel = Mapper.Map<Flick, FlickListingViewModel>(flick);
            viewModel.IsTrappable = !string.IsNullOrEmpty(userName);
            return viewModel;
        }

        static string GetStars( decimal source )
        {
            var viewModel = new FlickDetailsViewModel();
            var rating = Math.Round( source / 2 );
            switch( Convert.ToInt16( rating ) )
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