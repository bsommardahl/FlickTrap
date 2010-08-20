using FlickTrap.Domain;
using FlickTrap.Web.Controllers;
using Machine.Specifications;
using Moq;

namespace FlickTrap.Web.Specs
{
    public abstract class given_a_user_profile_controller_context
    {
        protected static Mock<IAuthorizer> _mockAuthorizer;
        protected static Mock<IUserProfileService> _mockUserProfileService;
        protected static UserProfileController _userProfileController;

        Establish an_account_controller_context = () =>
            {
                new RegisterAutoMaps().Execute();

                _mockUserProfileService = new Mock<IUserProfileService>();
                _mockAuthorizer = new Mock<IAuthorizer>();
                _userProfileController = new UserProfileController(_mockUserProfileService.Object, _mockAuthorizer.Object);
            };
    }
}