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

        public ActionResult Details(string imdbId)
        {
            var username = User.Identity.Name;
 
            var flick = _flickInfoService.GetFlick(username, imdbId);

            if( flick == null )
                return View("NotFound");

            var viewModel = FlickDetailsViewModel.Map(flick, null);

            return View( viewModel );
        }

        public ActionResult Trap(string imdbId)
        {
            var username = User.Identity.Name;
            _flickInfoService.Trap(username, imdbId);
            return Details(imdbId);
        }

        public ActionResult Untrap(string imdbId)
        {
            var username = User.Identity.Name;
            _flickInfoService.Untrap( username, imdbId );
            return Details( imdbId );
        }
    }
}