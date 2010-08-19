using System;
using System.Web.Mvc;
using AutoMapper;
using FlickTrap.Domain;
using FlickTrap.Web.Models;

namespace FlickTrap.Web.Controllers
{
    public class UserProfileController : Controller
    {
        readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        public ActionResult CreateUserProfile(UserProfileCreateRequest userProfileCreateRequest)
        {
            var userProfile = Mapper.Map<UserProfileCreateRequest, UserProfile>(userProfileCreateRequest);
            var newUserProfile = _userProfileService.CreateUserProfile(userProfile);
            var userProfileViewModel = Mapper.Map<UserProfile, UserProfileViewModel>(newUserProfile);
            return View(userProfileViewModel);
        }
    }
}