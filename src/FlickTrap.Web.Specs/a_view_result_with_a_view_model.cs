using System.Web.Mvc;
using Machine.Specifications;

namespace FlickTrap.Web.Specs
{
    [Behaviors]
    public class a_view_result_with_a_view_model
    {
        protected static ActionResult _result;

        It should_return_a_result = () => _result.ShouldNotBeNull();
        It should_return_a_view = () => _result.ShouldBeOfType( typeof( ViewResult ) );
        It should_return_a_view_model = () => ( ( ViewResult ) _result ).ViewData.Model.ShouldNotBeNull();
    }
}