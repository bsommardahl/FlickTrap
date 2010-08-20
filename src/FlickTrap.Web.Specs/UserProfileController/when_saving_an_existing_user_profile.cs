using System.Web.Mvc;
using AutoMapper;
using FlickTrap.Domain;
using FlickTrap.Web.Models;
using Machine.Specifications;

namespace FlickTrap.Web.Specs.UserProfileController
{
    [Subject(typeof (Controllers.UserProfileController))]
    public class when_saving_an_existing_user_profile : given_a_user_profile_controller_context
    {
        protected static ActionResult _result;

        Establish context =
            () => _mockUserProfileService
                      .Setup(x => x.UpdateUserProfile(Moq.It.IsAny<UserProfile>()))
                      .Returns(new UserProfile
                                   {
                                       Id = 1,
                                       FirstName = "first",
                                       LastName = "last",
                                       Username = "username"
                                   });

        Because the_user_updates_his_profile = () => _result = _userProfileController.Update(new UserProfileUpdateRequest());

        It should_get_the_user_profile_from_the_service =
            () => _mockUserProfileService.Verify( x => x.UpdateUserProfile( Moq.It.IsAny<UserProfile>() ) );

        Behaves_like<a_view_result_with_a_view_model> a_view_result_with_a_view_model;

        Behaves_like<a_view_with_user_profile_view_model> a_view_with_user_profile_view_model;

        It should_map_request_to_user_profile = () => Mapper.AssertConfigurationIsValid( "UserProfileUpdateRequest_to_UserProfile" );

        It should_map_new_profile_to_view_model = () => Mapper.AssertConfigurationIsValid( "UserProfile_to_UserProfileViewModel" );
    }
}