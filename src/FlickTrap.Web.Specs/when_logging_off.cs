using System.Web.Mvc;
using FlickTrap.Web.Controllers;
using Machine.Specifications;
using Machine.Specifications.Mvc;

namespace FlickTrap.Web.Specs
{
    [Subject(typeof (UserProfileController))]
    public class when_logging_off : given_a_user_profile_controller_context
    {
        static ActionResult _result;

        //Establish context = () => ;

        Because of = () => _result = _userProfileController.Logoff();

        It should_log_the_user_off = () => _mockAuthorizer.Verify(x => x.DeAuth());

        It should_redirect_to_the_home_page = () => _result.ShouldRedirectToAction<HomeController>(x => x.Index());
    }
}