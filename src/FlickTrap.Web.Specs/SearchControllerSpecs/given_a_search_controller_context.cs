using FlickTrap.Domain.Abstract;
using Machine.Specifications;
using Moq;

namespace FlickTrap.Web.Specs.SearchControllerSpecs
{
    public abstract class given_a_search_controller_context
    {
        protected static Mock<IFlickInfoService> _mockFlickInfoService;
        protected static Controllers.SearchController _controller;

        Establish context = () =>
            {
                new RegisterAutoMaps().Execute();

                _mockFlickInfoService = new Mock<IFlickInfoService>();

                _controller = new Controllers.SearchController(_mockFlickInfoService.Object);
                _controller.ControllerContext = new MvcFakes.FakeControllerContext(_controller, "username");
            };
    }
}