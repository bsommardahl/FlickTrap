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

            var viewModel = Mapper.Map<Flick, FlickDetailsViewModel>(flick);
            viewModel.IsTrappable = !string.IsNullOrEmpty(username);
            viewModel.IsTrapped = flick.Id > 0;
    
            return View("Details", viewModel );
        }

        public ActionResult Trap(string id)
        {
            var username = User.Identity.Name;
            _flickInfoService.Trap(username, id);
            return Details(id);
        }

        public ActionResult Untrap(string id)
        {
            var username = User.Identity.Name;
            _flickInfoService.Untrap( username, id );
            return Details( id );
        }
    }
}