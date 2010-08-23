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
        readonly IAuthorizer _authorizer;

        public UserProfileController(IUserProfileService userProfileService, IAuthorizer authorizer)
        {
            _userProfileService = userProfileService;
            _authorizer = authorizer;
        }

        [HttpPost]
        public ActionResult Create(UserProfileCreateRequest userProfileCreateRequest)
        {
            var userProfile = Mapper.Map<UserProfileCreateRequest, UserProfile>(userProfileCreateRequest);
            var newUserProfile = _userProfileService.CreateUserProfile(userProfile);
            var userProfileViewModel = Mapper.Map<UserProfile, UserProfileViewModel>(newUserProfile);
            return View("Edit", userProfileViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var userProfile = _userProfileService.GetUserProfile(id);
            var userProfileViewModel = Mapper.Map<UserProfile, UserProfileViewModel>( userProfile );
            return View( "Edit", userProfileViewModel );
        }

        [HttpPost]
        public ActionResult Update(UserProfileUpdateRequest userProfileUpdateRequest)
        {
            var userProfile = Mapper.Map<UserProfileUpdateRequest, UserProfile>(userProfileUpdateRequest);
            var updatedUserProfile = _userProfileService.UpdateUserProfile(userProfile);
            var viewModel = Mapper.Map<UserProfile, UserProfileViewModel>( updatedUserProfile);
            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Login(UserProfileLoginRequest userProfileLoginRequest)
        {
            var isGood = _userProfileService.Validate(userProfileLoginRequest.Username, userProfileLoginRequest.Password);
            if( !isGood )
            {
                ModelState.AddModelError("Username", "Username and/or password was incorrect.");
                return View("Login");
            }

            _authorizer.DoAuth(userProfileLoginRequest.Username, userProfileLoginRequest.RememberMe);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logoff()
        {
            _authorizer.DeAuth();
            return RedirectToAction("Index", "Home");
        }
    }
}