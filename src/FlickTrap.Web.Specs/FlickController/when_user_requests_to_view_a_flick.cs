using System;
using System.Web.Mvc;
using FlickTrap.Web.Models;
using Machine.Specifications;

namespace FlickTrap.Web.Specs.FlickController
{
    [Subject(typeof (Controllers.FlickController))]
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
}