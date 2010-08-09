using System;
using System.Web.Mvc;
using FlickTrap.Domain;
using FlickTrap.Domain.Abstract;
using FlickTrap.Web.Models;

namespace FlickTrap.Web.Controllers
{
    public class FlickController : Controller
    {
        readonly IFlickInfoService _flickInfoService;

        public FlickController(IFlickInfoService flickInfoService)
        {
            _flickInfoService = flickInfoService;
        }

        public ActionResult Index(string imdbId)
        {
            var username = User.Identity.Name;
 
            var flick = _flickInfoService.GetFlick(username, imdbId);

            if( flick == null )
                return View("NotFound");

            var viewModel = new FlickDetailsViewModel
                                {
                                    Name = flick.Name,
                                    Description = flick.Description,
                                    Budget = flick.Budget,
                                    Rating = flick.Rating,
                                    RentalReleaseDate = flick.RentalReleaseDate,
                                    Revenue = flick.Revenue,
                                    TheaterReleaseDate = flick.TheaterReleaseDate,
                                    UserRating = flick.UserRating,
                                    IsTrapped = flick.IsTrapped
                                };
            
            return View(viewModel);
        }

        public ActionResult Trap(string imdbId)
        {
            var username = User.Identity.Name;
            _flickInfoService.Trap(username, imdbId);
            return Index(imdbId);
        }

        public ActionResult Untrap(string imdbId)
        {
            var username = User.Identity.Name;
            _flickInfoService.Untrap( username, imdbId );
            return Index( imdbId );
        }
    }
}