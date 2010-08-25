using System.Linq;
using System.Web.Mvc;
using FlickTrap.Web.Models;
using Machine.Specifications;

namespace FlickTrap.Web.Specs.HomeControllerSpecs
{
    namespace HomeControllerSpecs
    {
        [Behaviors]
        public class a_successful_home_page
        {
            protected static ActionResult _result;
            
            It should_return_a_view = () => _result.ShouldBeOfType(typeof (ViewResult));
            
            //It should_return_a_view_with_a_list_of_five_unreleased_movies = () => ((HomeViewModel) ((ViewResult) _result).ViewData.Model).UnreleasedFlicks.Count().ShouldEqual(5);
            
            //It should_return_a_view_with_a_list_of_ten_recently_released_movies = () => ((HomeViewModel) ((ViewResult) _result).ViewData.Model).RecentlyReleasedFlicks.Count().ShouldEqual(10);

            //It should_return_correct_first_unreleased_movie = () =>
            //    {
            //        var firstUnreleasedFlick = ((HomeViewModel) ((ViewResult) _result).ViewData.Model).UnreleasedFlicks.First();
                    
            //        firstUnreleasedFlick.Name.ShouldEqual("Hitch");
            //        firstUnreleasedFlick.Rating.ShouldEqual( "PG-13" );
            //        firstUnreleasedFlick.Stars.ShouldEqual("five");
            //        firstUnreleasedFlick.ThumbnailUrl.ShouldEqual("http://hitch.com/poster.jpg");
            //        firstUnreleasedFlick.RemoteId.ShouldEqual("123");                    
            //    };

            //It should_return_correct_first_recent_movie = () =>
            //    {
            //        var firstRecentFlick = ( ( HomeViewModel ) ( ( ViewResult ) _result ).ViewData.Model ).RecentlyReleasedFlicks.First();
                    
            //        firstRecentFlick.Name.ShouldEqual( "Avatar" );
            //        firstRecentFlick.Rating.ShouldEqual( "PG-13" );
            //        firstRecentFlick.Stars.ShouldEqual("five");
            //        firstRecentFlick.ThumbnailUrl.ShouldEqual( "http://avatar.com/poster.jpg" );
            //        firstRecentFlick.RemoteId.ShouldEqual("223");
            //    };

        }

    }
}