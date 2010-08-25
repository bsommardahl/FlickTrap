using System.Linq;
using System.Web.Mvc;
using FlickTrap.Web.Models;
using Machine.Specifications;

namespace FlickTrap.Web.Specs.SearchControllerSpecs
{
    namespace SearchControllerSpecs
    {
        [Subject(typeof (Controllers.SearchController))]
        public class when_user_visits_search_page_without_search_text : given_a_search_controller_context
        {
            static ActionResult _result;
            
            Because of = () => _result = _controller.Index("");

            It should_not_return_a_null_list = () => ( ( SearchViewModel ) ( ( ViewResult ) _result ).ViewData.Model ).Flicks.ShouldNotBeNull();
            It should_return_a_view = () => _result.ShouldBeOfType(typeof (ViewResult));
            It should_return_an_empty_list_of_flicks = () => ((SearchViewModel) ((ViewResult) _result).ViewData.Model).Flicks.Count().ShouldEqual(0);
        }
    }
}