using System.Web.Mvc;
using FlickTrap.Web.Controllers;
using FlickTrap.Web.Models;
using Machine.Specifications;

namespace FlickTrap.Web.Specs.FlickControllerSpecs
{
    [Subject(typeof (FlickController))]
    public class when_authenticated_user_requests_to_view_a_trapped_flick : given_a_valid_flick_controller
    {
        protected static ActionResult _result;
        protected static FlickDetailsViewModel _viewModel;

        Establish context = () =>
            {
                _controller.ControllerContext = new MvcFakes.FakeControllerContext( _controller, "username" );

                _mockFlickInfoService.Setup(x => x.GetFlick("username", "123")).Returns(_valid_flick);
            };

        Because of = () =>
            {
                _result = _controller.Details( "123" );
                _viewModel = ( ( FlickDetailsViewModel ) ( ( ViewResult ) _result ).ViewData.Model );
            };

        It should_be_trappable = () => _viewModel.IsTrappable.ShouldBeTrue();
        It should_be_trapped = () => _viewModel.IsTrapped.ShouldBeTrue();

        Behaves_like<a_valid_flick_details_view> a_valid_flick_details_view;
    }
}