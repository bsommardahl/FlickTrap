using System.Web.Mvc;
using FlickTrap.Domain;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using Moq;
using It = Machine.Specifications.It;

namespace FlickTrap.Web.Specs.UserProfileControllerSpecs
{
    public class when_viewing_login_page : given_a_user_profile_controller_context
    {
        private static ActionResult _result;

        private Because of = () => _result = _userProfileController.Login();

        private It should_return_a_view = () => _result.ShouldBeAView().And().ViewName.ShouldEqual("Login");
    }
    
    public abstract class given_a_user_profile_controller_context
    {
        protected static Mock<IAuthorizer> _mockAuthorizer;
        protected static Mock<IUserProfileService> _mockUserProfileService;
        protected static Controllers.UserProfileController _userProfileController;

        Establish an_account_controller_context = () =>
            {
                new RegisterAutoMaps().Execute();

                _mockUserProfileService = new Mock<IUserProfileService>();
                _mockAuthorizer = new Mock<IAuthorizer>();
                _userProfileController = new Controllers.UserProfileController(_mockUserProfileService.Object, _mockAuthorizer.Object);
            };
    }
}