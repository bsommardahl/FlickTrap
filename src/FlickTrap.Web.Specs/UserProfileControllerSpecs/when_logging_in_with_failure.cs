using System.Web.Mvc;
using FlickTrap.Web.Models;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using Moq;
using It = Moq.It;

namespace FlickTrap.Web.Specs.UserProfileControllerSpecs
{
    [Subject(typeof (Controllers.UserProfileController))]
    public class when_logging_in_with_failure : given_a_user_profile_controller_context
    {
        static ActionResult _result;

        Establish context =
            () => _mockUserProfileService
                      .Setup(x => x.Validate(It.IsAny<string>(), It.IsAny<string>()))
                      .Returns(false);

        Because user_attempts_to_log_in_with_bad_credentials =
            () => _result = _userProfileController.Login(new UserProfileLoginRequest
                                                             {
                                                                 Username = "username",
                                                                 Password = "password",
                                                                 RememberMe = false
                                                             });

        Machine.Specifications.It should_not_register_the_user_with_the_authorizer =
            () => _mockAuthorizer.Verify(x => x.DoAuth(It.IsAny<string>(), It.IsAny<bool>()), Times.Never());

        Machine.Specifications.It should_verify_the_profile_with_the_service =
            () => _mockUserProfileService.Verify(x => x.Validate(It.IsAny<string>(), It.IsAny<string>()));

        Machine.Specifications.It should_redisplay_the_view_with_model_errors = () => _result.ShouldBeAView().And().ViewName.ShouldEqual("Login");
    }
}