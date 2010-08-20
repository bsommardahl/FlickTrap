using System.Linq;
using System.Web.Mvc;
using FlickTrap.Web.Models;
using FlickTrap.Web.Specs.SearchController;
using Machine.Specifications;

namespace FlickTrap.Web.Specs.FlickController
{
    [Subject(typeof (Controllers.SearchController))]
    public class when_user_searches_for_a_flick_with_no_results : given_a_search_controller_context
    {
        static ActionResult _result;

        Because of = () => _result = _controller.Index("bad search");

        It should_not_return_a_null_list = () => ((ViewResult) _result).ViewData.Model.ShouldNotBeNull();
        It should_return_a_view = () => _result.ShouldBeOfType(typeof (ViewResult));
        It should_return_an_empty_list_of_flicks = () => ((SearchViewModel) ((ViewResult) _result).ViewData.Model).Flicks.Count().ShouldEqual(0);
    }
}