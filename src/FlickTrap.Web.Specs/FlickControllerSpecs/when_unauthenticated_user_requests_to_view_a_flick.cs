using System;
using System.Web.Mvc;
using FlickTrap.Web.Controllers;
using FlickTrap.Web.Models;
using Machine.Specifications;

namespace FlickTrap.Web.Specs.FlickControllerSpecs
{
    [Subject(typeof (FlickController))]
    public class when_unauthenticated_user_requests_to_view_a_flick : given_a_valid_flick_controller
    {
        protected static ActionResult _result;
        protected static FlickDetailsViewModel _viewModel;

        Establish context = () => _mockFlickInfoService.Setup(x => x.GetFlick("username", "123")).Returns(_valid_flick);
        
        Because of = () =>
            {
                _result = _controller.Details("123");
                _viewModel = ((FlickDetailsViewModel) ((ViewResult) _result).ViewData.Model);
            };

        It should_not_be_trappable = () => _viewModel.IsTrappable.ShouldBeFalse();
    
        It should_not_be_trapped = () => _viewModel.IsTrapped.ShouldBeFalse();

        Behaves_like<a_valid_flick_details_view> a_valid_flick_details_view;
    }
}