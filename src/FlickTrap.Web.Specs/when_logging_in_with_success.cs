using System.Web.Mvc;
using FlickTrap.Web.Controllers;
using FlickTrap.Web.Models;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using Parameter = Moq.It;

namespace FlickTrap.Web.Specs
{
    [Subject(typeof (UserProfileController))]
    public class when_logging_in_with_success : given_a_user_profile_controller_context
    {
        static ActionResult _result;

        Establish context =
            () => _mockUserProfileService
                      .Setup(x => x.Validate(Parameter.IsAny<string>(), Parameter.IsAny<string>()))
                      .Returns(true);

        Because user_attempts_to_log_in_with_good_credentials =
            () => _result = _userProfileController.Login(new UserProfileLoginRequest
                                                             {
                                                                 Username = "username",
                                                                 Password = "password",
                                                                 RememberMe = false
                                                             });

        It should_register_the_user_with_the_authorizer =
            () => _mockAuthorizer.Verify(x => x.DoAuth(Parameter.IsAny<string>(), Parameter.IsAny<bool>()));

        It should_verify_the_profile_with_the_service =
            () => _mockUserProfileService.Verify(x => x.Validate(Parameter.IsAny<string>(), Parameter.IsAny<string>()));

        It should_redirect_to_the_home_page = () => _result.ShouldRedirectToAction<HomeController>(x => x.Index());
    }
}