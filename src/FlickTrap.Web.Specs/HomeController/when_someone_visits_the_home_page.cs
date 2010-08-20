using System.Web.Mvc;
using FlickTrap.Domain;
using Machine.Specifications;

namespace FlickTrap.Web.Specs.HomeController
{
    [Subject(typeof (Controllers.HomeController))]
    public class when_someone_visits_the_home_page : given_a_home_controller_context
    {
        static UserProfile _userProfile;
        protected static ActionResult _result;

        //Behaves_like<a_successful_home_page> a_successful_home_page;

        //Because of = () => { _result = _controller.Index(); };

    }
}