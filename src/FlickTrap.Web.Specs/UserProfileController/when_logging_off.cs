using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;

namespace FlickTrap.Web.Specs.UserProfileController
{
    [Subject(typeof (Controllers.UserProfileController))]
    public class when_logging_off : given_a_user_profile_controller_context
    {
        static ActionResult _result;

        Because of = () => _result = _userProfileController.Logoff();

        It should_log_the_user_off = () => _mockAuthorizer.Verify(x => x.DeAuth());

        It should_redirect_to_the_home_page = () => _result.ShouldRedirectToAction<Controllers.HomeController>(x => x.Index());
    }
}