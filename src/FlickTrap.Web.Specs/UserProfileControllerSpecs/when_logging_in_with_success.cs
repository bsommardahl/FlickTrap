using System.Web.Mvc;
using FlickTrap.Web.Models;
using Machine.Specifications;
using Machine.Specifications.Mvc;

namespace FlickTrap.Web.Specs.UserProfileControllerSpecs
{
    [Subject(typeof (Controllers.UserProfileController))]
    public class when_logging_in_with_success : given_a_user_profile_controller_context
    {
        static ActionResult _result;

        Establish context =
            () => _mockUserProfileService
                      .Setup(x => x.Validate(Moq.It.IsAny<string>(), Moq.It.IsAny<string>()))
                      .Returns(true);

        Because user_attempts_to_log_in_with_good_credentials =
            () => _result = _userProfileController.Login(new UserProfileLoginRequest
                                                             {
                                                                 Username = "username",
                                                                 Password = "password",
                                                                 RememberMe = false
                                                             });

        It should_register_the_user_with_the_authorizer =
            () => _mockAuthorizer.Verify(x => x.DoAuth(Moq.It.IsAny<string>(), Moq.It.IsAny<bool>()));

        It should_verify_the_profile_with_the_service =
            () => _mockUserProfileService.Verify(x => x.Validate(Moq.It.IsAny<string>(), Moq.It.IsAny<string>()));

        It should_redirect_to_the_home_page = () => _result.ShouldRedirectToAction<Controllers.HomeController>(x => x.Index());
    }
}