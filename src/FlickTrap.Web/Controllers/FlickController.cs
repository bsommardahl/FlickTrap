using System;
using System.Web.Mvc;
using AutoMapper;
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

        public ActionResult Details(string id)
        {
            var username = User.Identity.Name;

            var flick = _flickInfoService.GetFlick(username, id);

            if( flick == null )
                return View("NotFound");

            var viewModel = FlickDetailsViewModel.MapFromFlick(flick, username);
    
            return View("Details", viewModel );
        }

        [HttpGet]
        public ActionResult ToggleTrapping(string id, bool isTrapped)
        {
            var username = User.Identity.Name;

            if(isTrapped)
                _flickInfoService.Untrap(username, id);
            else
                _flickInfoService.Trap(username, id);

            return Json(new ToggleTrappingJsonResult
                            {
                                IsTrapped = !isTrapped
                            }, JsonRequestBehavior.AllowGet);
        }
    }
}