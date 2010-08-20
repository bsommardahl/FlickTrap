using System.Web.Mvc;
using AutoMapper;
using FlickTrap.Domain;
using FlickTrap.Web.Controllers;
using Machine.Specifications;
using It = Moq.It;

namespace FlickTrap.Web.Specs
{
    [Subject(typeof (UserProfileController))]
    public class when_editing_a_user_profile : given_a_user_profile_controller_context
    {
        protected static ActionResult _result;

        Establish context =
            () => _mockUserProfileService
                      .Setup(x => x.GetUserProfile(It.IsAny<int>()))
                      .Returns(new UserProfile
                                   {
                                       FirstName = "first",
                                       LastName = "last",
                                       Username = "username"
                                   });

        Because the_user_views_the_edit_page = () => _result = _userProfileController.Edit(1);

        Machine.Specifications.It should_get_the_user_profile_from_the_service =
            () => _mockUserProfileService.Verify(x => x.GetUserProfile(It.IsAny<int>()));

        Behaves_like<a_view_result_with_a_view_model> a_view_result_with_a_view_model;

        Behaves_like<a_view_with_user_profile_view_model> a_view_with_user_profile_view_model;

        Machine.Specifications.It should_map_new_profile_to_view_model = () => Mapper.AssertConfigurationIsValid("UserProfile_to_UserProfileViewModel");
    }
}