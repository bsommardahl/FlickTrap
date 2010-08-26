using System.Linq;
using System.Web.Mvc;
using FlickTrap.Web.Controllers;
using FlickTrap.Web.Models;
using Machine.Specifications;

namespace FlickTrap.Web.Specs.SearchControllerSpecs
{
    [Subject(typeof (SearchController))]
    public class when_user_visits_search_page_without_search_text : given_a_search_controller_context
    {
        private static ActionResult _result;

        private Because of = () => _result = _controller.Index("");

        private It should_not_return_a_null_list =
            () => ((SearchViewModel) ((ViewResult) _result).ViewData.Model).Flicks.ShouldNotBeNull();

        private It should_return_a_view = () => _result.ShouldBeOfType(typeof (ViewResult));

        private It should_return_an_empty_list_of_flicks =
            () => ((SearchViewModel) ((ViewResult) _result).ViewData.Model).Flicks.Count().ShouldEqual(0);
    }
}