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
        readonly IUserProfileService _userProfileService;
        
        public HomeController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        public ActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
            };

            
            var username = User.Identity.Name;
            var userProfile = _userProfileService.GetUserProfile(username);
            if( userProfile != null )
                viewModel.Trapped = userProfile.Trapped.Select(x => Mapper.Map<Flick, FlickListingViewModel>(x));

            return View(viewModel);
        }

        
    }
}