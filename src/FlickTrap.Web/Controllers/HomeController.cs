using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FlickTrap.Domain;
using FlickTrap.Domain.Abstract;
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

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Search", new
                                                           {
                                                               searchText = "Star Wars"
                                                           });

            //var recentlyReleased = _flickInfoService.GetRecentlyReleasedFlicks();
            //var recentlyReleasedViewModel = recentlyReleased.Take(10).Select(x => FlickListingViewModel.Map(x, null));

            //var unreleased = _flickInfoService.GetUnreleasedFlicks();
            //var unreleasedViewModel = unreleased.Take( 5 ).Select( x => FlickListingViewModel.Map( x, null ) );
                                                                 
            var viewModel = new HomeViewModel
                                {
                                    //RecentlyReleasedFlicks = recentlyReleasedViewModel,
                                    //UnreleasedFlicks = unreleasedViewModel
                                };

            return View(viewModel);
        }

        
    }
}