using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FlickTrap.Domain;
using FlickTrap.Domain.Abstract;
using FlickTrap.Web.Models;

namespace FlickTrap.Web.Controllers
{
    public class SearchController : Controller
    {
        readonly IFlickInfoService _flickInfoService;

        public SearchController(IFlickInfoService flickInfoService)
        {
            _flickInfoService = flickInfoService;
        }

        public ActionResult Index(string searchText)
        {
            var flicks = _flickInfoService.Search(searchText);

            var viewModel = new SearchViewModel
                                {
                                    Flicks = flicks.Select( x => FlickListingViewModel.Map(x, null) ),
                                    SearchText = searchText
                                };

            return View(viewModel);
           
        }

    }
}