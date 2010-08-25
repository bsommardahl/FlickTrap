using FlickTrap.Domain;
using FlickTrap.Web.Controllers;
using Machine.Specifications;
using Moq;

namespace FlickTrap.Web.Specs.HomeControllerSpecs
{
    public abstract class given_a_home_controller_context
    {
        protected static HomeController _controller;
        protected static Mock<IUserProfileService> _mockUserProfileService;

        Establish a_home_controller_context = () =>
            {
                new RegisterAutoMaps().Execute();

                _mockUserProfileService = new Mock<IUserProfileService>();

                _controller = new HomeController(_mockUserProfileService.Object);
            };
    }
}