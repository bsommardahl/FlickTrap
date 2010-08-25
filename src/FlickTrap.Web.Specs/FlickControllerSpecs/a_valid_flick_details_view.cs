using System;
using System.Web.Mvc;
using FlickTrap.Web.Models;
using Machine.Specifications;
using Machine.Specifications.Mvc;

namespace FlickTrap.Web.Specs.FlickControllerSpecs
{
    [Behaviors]
    public class a_valid_flick_details_view
    {
        protected static ActionResult _result;
        
        It should_return_a_view = 
            () => _result.ShouldBeOfType( typeof( ViewResult ) );
        
        It should_return_a_view_with_correct_flick_budget = 
            () => _result.Model<FlickDetailsViewModel>().Budget.ShouldEqual( 500M );

        It should_return_a_view_with_correct_flick_description =
            () => _result.Model<FlickDetailsViewModel>().Description.ShouldEqual( "Avatar Description" );

        It should_return_a_view_with_correct_flick_name = 
            () => _result.Model<FlickDetailsViewModel>().Name.ShouldEqual( "Avatar" );
        
        It should_return_a_view_with_correct_flick_rating = 
            () => _result.Model<FlickDetailsViewModel>().Rating.ShouldEqual( "PG-13" );

        It should_return_a_view_with_correct_flick_rental_release_date =
            () => _result.Model<FlickDetailsViewModel>().RentalReleaseDate.ShouldEqual( new DateTime( 2010, 5, 1 ) );

        It should_return_a_view_with_correct_flick_revenue = 
            () => _result.Model<FlickDetailsViewModel>().Revenue.ShouldEqual( 1000M );

        It should_return_a_view_with_correct_flick_stars = 
            () => _result.Model<FlickDetailsViewModel>().Stars.ShouldEqual( "five" );

        It should_return_a_view_with_correct_flick_theater_release_date =
            () => _result.Model<FlickDetailsViewModel>().TheaterReleaseDate.ShouldEqual( new DateTime( 2009, 11, 1 ) );    
    }
}