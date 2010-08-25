using System.Web.Mvc;
using AutoMapper;
using FlickTrap.Domain;
using FlickTrap.Web.Models;
using Machine.Specifications;

namespace FlickTrap.Web.Specs.UserProfileControllerSpecs
{
    [Subject(typeof (Controllers.UserProfileController))]
    public class when_creating_a_user_profile : given_a_user_profile_controller_context
    {
        protected static ActionResult _result;

        Establish context =
            () => _mockUserProfileService
                      .Setup(x => x.CreateUserProfile(Moq.It.IsAny<UserProfile>()))
                      .Returns(new UserProfile
                                   {
                                       Username = "username",
                                       FirstName = "first",
                                       LastName = "last",
                                   });

        Because the_user_attempts_to_create_an_account =
            () => _result = _userProfileController.Create(new UserProfileCreateRequest());

        Behaves_like<a_view_result_with_a_view_model> a_view_result_with_a_view_model;

        It should_use_the_service_to_create_the_user_profile = () => _mockUserProfileService.Verify(x => x.CreateUserProfile(Moq.It.IsAny<UserProfile>()));
        It should_map_request_to_user_profile = () => Mapper.AssertConfigurationIsValid("UserProfileCreateRequest_to_UserProfile");
        It should_map_new_profile_to_view_model = () => Mapper.AssertConfigurationIsValid("UserProfile_to_UserProfileViewModel");

    }
}