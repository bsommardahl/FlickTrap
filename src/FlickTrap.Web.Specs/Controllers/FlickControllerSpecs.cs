using System;
using System.Web.Mvc;
using FlickTrap.Domain;
using FlickTrap.Web.Controllers;
using FlickTrap.Web.Models;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace FlickTrap.Web.Specs.Controllers
{
    namespace FlickControllerSpecs
    {
        public abstract class given_a_valid_flick_controller
        {
            protected static Mock<IFlickInfoService> _mockFlickInfoService;
            protected static FlickController _controller;

            Establish context = () =>
                {
                    _mockFlickInfoService = new Mock<IFlickInfoService>();
                    _mockFlickInfoService.Setup(x => x.GetFlick("123")).Returns(new Flick
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
                                                                                    });

                    _controller = new FlickController(_mockFlickInfoService.Object);
                };
        }

        [Subject(typeof (FlickController))]
        public class when_user_requests_to_view_a_flick : given_a_valid_flick_controller
        {
            static ActionResult _result;
            static FlickDetailsViewModel _viewModel;

            Because of = () =>
                {
                    _result = _controller.Index("123");
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
            It should_return_a_view_with_correct_flick_user_rating = () => _viewModel.UserRating.ShouldEqual(9.8M);
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
                };

            Because of = () => _result = _controller.Index("123-1");

            It should_return_a_not_found_view = () => ((ViewResult) _result).ViewName.ShouldEqual("NotFound");
            It should_return_a_view = () => _result.ShouldBeOfType(typeof (ViewResult));
        }

        [Subject(typeof (FlickController))]
        public class when_user_attempts_to_trap_a_flick : given_a_valid_flick_controller
        {
            static ActionResult _result;

            Because of = () => _result = _controller.Trap("123");

            It should_return_the_default_view = () => ((ViewResult)_result).ViewName.ShouldEqual
            It should_return_the_default_view = () => _result.ShouldBeOfType(typeof (ViewResult));
            It should_return_trapped_flick = () => ((FlickDetailsViewModel) ((ViewResult) _result).ViewData.Model).IsTrapped.ShouldBeTrue();
        }
    }
}