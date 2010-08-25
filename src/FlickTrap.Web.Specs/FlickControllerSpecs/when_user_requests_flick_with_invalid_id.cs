using System.Web.Mvc;
using FlickTrap.Domain.Abstract;
using FlickTrap.Web.Specs.MvcFakes;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace FlickTrap.Web.Specs.FlickControllerSpecs
{
    [Subject(typeof (Controllers.FlickController))]
    public class when_user_requests_flick_with_invalid_id
    {
        static Mock<IFlickInfoService> _mockFlickInfoService;
        static Controllers.FlickController _controller;
        static ActionResult _result;

        Establish context = () =>
            {
                _mockFlickInfoService = new Mock<IFlickInfoService>();
                _controller = new Controllers.FlickController(_mockFlickInfoService.Object);
                _controller.ControllerContext = new FakeControllerContext(_controller, "username");
            };

        Because of = () => _result = _controller.Details( "123-1" );

        It should_return_a_not_found_view = () => ((ViewResult) _result).ViewName.ShouldEqual("NotFound");
        It should_return_a_view = () => _result.ShouldBeOfType(typeof (ViewResult));
    }
}