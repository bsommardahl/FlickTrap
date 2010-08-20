using System.Web.Mvc;
using FlickTrap.Web.Models;
using Machine.Specifications;

namespace FlickTrap.Web.Specs.FlickController
{
    namespace FlickControllerSpecs
    {
        [Subject( typeof( Controllers.FlickController ) )]
        public class when_user_attempts_to_untrap_a_flick : given_a_valid_flick_controller
        {
            static ActionResult _result;

            Establish additional_context = () => _valid_flick.IsTrapped = false;

            Because of = () => _result = _controller.Untrap( "123" );

            It should_return_a_view = () => _result.ShouldBeOfType( typeof( ViewResult ) );
            It should_return_the_default_view = () => ( ( ViewResult ) _result ).ViewName.ShouldEqual( string.Empty );
            It should_return_untrapped_flick = () => ( ( FlickDetailsViewModel ) ( ( ViewResult ) _result ).ViewData.Model ).IsTrapped.ShouldBeFalse();
            It should_trap_the_flick = () => _mockFlickInfoService.Verify( x => x.Untrap( "username", "123" ) );
        }
    }
}