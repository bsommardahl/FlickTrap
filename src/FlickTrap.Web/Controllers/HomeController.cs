using System;
using System.Linq;
using System.Web.Mvc;
using FlickTrap.Domain;
using FlickTrap.Web.Models;

namespace FlickTrap.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly IFlickInfoService _flickInfoService;

        public HomeController(IFlickInfoService flickInfoService)
        {
            _flickInfoService = flickInfoService;
        }

        FlickListingViewModel MapToListing(Flick flick)
        {
            return new FlickListingViewModel
                       {
                           ImdbId = flick.ImdbId,
                           Name = flick.Name,
                           Rating = flick.Rating,
                           UserRating = flick.UserRating,
                           ThumbnailUrl = flick.ThumbnailUrl   
                       };
        }

        public ActionResult Index()
        {
            var userProfile = (UserProfile) Session["UserProfile"];
            if(userProfile==null)
            {
                userProfile = new UserProfile{ Name = "Guest"};
                Session["UserProfile"] = userProfile;
            }

            var recentlyReleased = _flickInfoService.GetRecentlyReleasedFlicks();
            var recentlyReleasedViewModel = recentlyReleased.Take(10).Select(x => MapToListing(x));

            var unreleased = _flickInfoService.GetUnreleasedFlicks();
            var unreleasedViewModel = unreleased.Take(5).Select(x => MapToListing(x));
                                                                 
            var viewModel = new HomeViewModel
                                {
                                    RecentlyReleasedFlicks = recentlyReleasedViewModel,
                                    UnreleasedFlicks = unreleasedViewModel
                                };

            return View(viewModel);
        }
    }
}