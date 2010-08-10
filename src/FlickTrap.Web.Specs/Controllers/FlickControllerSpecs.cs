using System;
using System.Web.Mvc;
using FlickTrap.Domain;
using FlickTrap.Domain.Abstract;
using FlickTrap.Web.Controllers;
using FlickTrap.Web.Models;
using Machine.Specifications;
using Moq;
using MvcFakes;
using It = Machine.Specifications.It;

namespace FlickTrap.Web.Specs.Controllers
{
    namespace FlickControllerSpecs
    {
        public abstract class given_a_valid_flick_controller
        {
            protected static Mock<IFlickInfoService> _mockFlickInfoService;
            protected static FlickController _controller;
            protected static Flick _valid_flick;

            Establish context = () =>
                {
                    _valid_flick = new Flick
                                       {
                                           Name = "Avatar",
                                           Description = "Avatar Description",
                                           UserRating = 9.8M,
                                           Rating = "PG-13",
                                           ThumbnailUrl = "http://avatar.com/poster.jpg",
                                           RentalReleaseDate = new DateTime(2010, 5, 1),
                                           TheaterReleaseDate = new DateTime(2009, 11, 1),
                                           Revenue = 1000M,
                                           Budget = 500M,
                                           ImdbId = "123"
                                       };

                    _mockFlickInfoService = new Mock<IFlickInfoService>();
                    _mockFlickInfoService.Setup(x => x.GetFlick("username", "123")).Returns(_valid_flick);

                    _controller = new FlickController(_mockFlickInfoService.Object);
                    _controller.ControllerContext = new FakeControllerContext(_controller, "username");
                };
        }

        [Subject(typeof (FlickController))]
        public class when_user_requests_to_view_a_flick : given_a_valid_flick_controller
        {
            static ActionResult _result;
            static FlickDetailsViewModel _viewModel;

            Because of = () =>
                {
                    _result = _controller.Details("123");
                    _viewModel = ((FlickDetailsViewModel) ((ViewResult) _result).ViewData.Model);
                };

            It should_return_a_view = () => _result.ShouldBeOfType(typeof (ViewResult));
            It should_return_a_view_with_correct_flick_budget = () => _viewModel.Budget.ShouldEqual(500M);
            It should_return_a_view_with_correct_flick_description = () => _viewModel.Description.ShouldEqual("Avatar Description");
            It should_return_a_view_with_correct_flick_name = () => _viewModel.Name.ShouldEqual("Avatar");
            It should_return_a_view_with_correct_flick_rating = () => _viewModel.Rating.ShouldEqual("PG-13");
            It should_return_a_view_with_correct_flick_rental_release_date = () => _viewModel.RentalReleaseDate.ShouldEqual(new DateTime(2010, 5, 1));
            It should_return_a_view_with_correct_flick_revenue = () => _viewModel.Revenue.ShouldEqual(1000M);
            It should_return_a_view_with_correct_flick_theater_release_date = () => _viewModel.TheaterReleaseDate.ShouldEqual(new DateTime(2009, 11, 1));
            It should_return_a_view_with_correct_flick_stars = () => _viewModel.Stars.ShouldEqual("five");
        }

        [Subject(typeof (FlickController))]
        public class when_user_requests_flick_with_invalid_id
        {
            static Mock<IFlickInfoService> _mockFlickInfoService;
            static FlickController _controller;
            static ActionResult _result;

            Establish context = () =>
                {
                    _mockFlickInfoService = new Mock<IFlickInfoService>();
                    _controller = new FlickController(_mockFlickInfoService.Object);
                    _controller.ControllerContext = new FakeControllerContext(_controller, "username");
                };

            Because of = () => _result = _controller.Details( "123-1" );

            It should_return_a_not_found_view = () => ((ViewResult) _result).ViewName.ShouldEqual("NotFound");
            It should_return_a_view = () => _result.ShouldBeOfType(typeof (ViewResult));
        }

        [Subject(typeof (FlickController))]
        public class when_user_attempts_to_trap_a_flick : given_a_valid_flick_controller
        {
            static ActionResult _result;

            Establish additional_context = () => _valid_flick.IsTrapped = true;

            Because of = () => _result = _controller.Trap("123");

            It should_return_a_view = () => _result.ShouldBeOfType(typeof (ViewResult));
            It should_return_the_default_view = () => ((ViewResult) _result).ViewName.ShouldEqual(string.Empty);
            It should_return_trapped_flick = () => ((FlickDetailsViewModel) ((ViewResult) _result).ViewData.Model).IsTrapped.ShouldBeTrue();
            It should_trap_the_flick = () => _mockFlickInfoService.Verify(x => x.Trap("username", "123"));
        }

        [Subject( typeof( FlickController ) )]
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