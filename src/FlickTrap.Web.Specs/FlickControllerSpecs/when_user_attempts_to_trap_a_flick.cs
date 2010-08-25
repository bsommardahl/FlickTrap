using System.Web.Mvc;
using FlickTrap.Web.Models;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using Parameter=Moq.It;

namespace FlickTrap.Web.Specs.FlickControllerSpecs
{
    [Subject(typeof (Controllers.FlickController))]
    public class when_user_attempts_to_trap_a_flick : given_a_valid_flick_controller
    {
        protected static ActionResult _result;
        
        private Establish additional_context = () =>
                                                   {
                                                       _mockFlickInfoService
                                                           .Setup(
                                                               x =>
                                                               x.GetFlick(Parameter.IsAny<string>(),
                                                                          Parameter.IsAny<string>()))
                                                           .Returns(_valid_flick);

                                                       _controller.ControllerContext =
                                                           new MvcFakes.FakeControllerContext(_controller, "username");

                                                   };

        private Because of = () => _result = _controller.Trap("123");

        It should_return_a_view = () => _result.ShouldBeAView();
        It should_return_the_correct_view = () => _result.ShouldBeAView().And().ViewName.ShouldEqual("Details");
        It should_return_trapped_flick = () => _result.Model<FlickDetailsViewModel>().IsTrapped.ShouldBeTrue();
        It should_trap_the_flick = () => _mockFlickInfoService.Verify(x => x.Trap("username", "123"));

        private Behaves_like<a_valid_flick_details_view> a_valid_flick_details_view; 
    }
}