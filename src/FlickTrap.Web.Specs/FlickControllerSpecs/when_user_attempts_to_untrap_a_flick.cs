using System.Web.Mvc;
using FlickTrap.Web.Models;
using Machine.Specifications;
using Parameter = Moq.It;

namespace FlickTrap.Web.Specs.FlickControllerSpecs
{
    [Subject( typeof( Controllers.FlickController ) )]
    public class when_user_attempts_to_untrap_a_flick : given_a_valid_flick_controller
    {
        static ActionResult _result;

        private Establish additional_context = () =>
                                                   {
                                                       //need to remove id so it looks like an untrapped flick
                                                       _valid_flick.Id = 0;

                                                       _mockFlickInfoService
                                                          .Setup(
                                                              x =>
                                                              x.GetFlick( Parameter.IsAny<string>(),
                                                                         Parameter.IsAny<string>() ) )
                                                          .Returns( _valid_flick );

                                                       _controller.ControllerContext =
                                                           new MvcFakes.FakeControllerContext( _controller, "username" );
                                                   };

        Because of = () => _result = _controller.ToggleTrapping( "123", true );

        private It should_return_a_view = () => _result.ShouldBeOfType( typeof( JsonResult ) );

        private It should_return_a_json_trapped_result =
            () => ( ( JsonResult ) _result ).Data.ShouldBeOfType( typeof( ToggleTrappingJsonResult ) );

        It should_return_trapped_flick = () => ( ( ToggleTrappingJsonResult ) ( ( JsonResult ) _result ).Data ).IsTrapped.ShouldBeFalse();

        private It should_untrap_the_flick = () => _mockFlickInfoService.Verify(x => x.Untrap("username", "123"));
    }
}