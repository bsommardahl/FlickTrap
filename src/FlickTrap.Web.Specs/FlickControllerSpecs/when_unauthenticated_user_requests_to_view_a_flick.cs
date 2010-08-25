using System.Web.Mvc;
using FlickTrap.Web.Controllers;
using FlickTrap.Web.Models;
using FlickTrap.Web.Specs.MvcFakes;
using Machine.Specifications;
using Parameter = Moq.It;

namespace FlickTrap.Web.Specs.FlickControllerSpecs
{
    [Subject(typeof (FlickController))]
    public class when_unauthenticated_user_requests_to_view_a_flick : given_a_valid_flick_controller
    {
        protected static ActionResult _result;
        protected static FlickDetailsViewModel _viewModel;
        private Behaves_like<a_valid_flick_details_view> a_valid_flick_details_view;

        private Establish context = () =>
                                        {
                                            _controller.ControllerContext = new FakeControllerContext(_controller,
                                                                                                      string.Empty);

                                            //got to make valid flick look like it's not in the database
                                            _valid_flick.Id = 0;

                                            _mockFlickInfoService
                                                .Setup(x => x.GetFlick(Parameter.IsAny<string>(), Parameter.IsAny<string>())).
                                                Returns(_valid_flick);
                                        };

        private Because of = () =>
                                 {
                                     _result = _controller.Details("123");
                                     _viewModel = ((FlickDetailsViewModel) ((ViewResult) _result).ViewData.Model);
                                 };

        private It should_not_be_trappable = () => _viewModel.IsTrappable.ShouldBeFalse();

        private It should_not_be_trapped = () => _viewModel.IsTrapped.ShouldBeFalse();
    }
}