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

        Because of = () => _result = _controller.Untrap( "123" );

        It should_return_a_view = () => _result.ShouldBeOfType( typeof( ViewResult ) );
        It should_return_the_correct_view = () => ( ( ViewResult ) _result ).ViewName.ShouldEqual( "Details");
        It should_return_untrapped_flick = () => ( ( FlickDetailsViewModel ) ( ( ViewResult ) _result ).ViewData.Model ).IsTrapped.ShouldBeFalse();
        It should_trap_the_flick = () => _mockFlickInfoService.Verify( x => x.Untrap( "username", "123" ) );
    }
}