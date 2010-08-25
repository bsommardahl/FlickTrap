using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FlickTrap.Domain;
using FlickTrap.Web.Controllers;
using FlickTrap.Web.Models;
using FlickTrap.Web.Specs.MvcFakes;
using Machine.Specifications;
using Machine.Specifications.Mvc;

namespace FlickTrap.Web.Specs.HomeControllerSpecs
{
    [Subject(typeof (HomeController))]
    public class when_unauthenticated_user_visits_the_home_page : given_a_home_controller_context
    {
        static UserProfile _userProfile;
        protected static ActionResult _result;

        //Behaves_like<a_successful_home_page> a_successful_home_page;

        //Because of = () => { _result = _controller.Index(); };
    }

    [Subject(typeof (HomeController))]
    public class when_authenticated_user_visits_home_page : given_a_home_controller_context
    {
        static ActionResult _result;

        Establish context = () =>
            {
                _controller.ControllerContext = new FakeControllerContext(_controller, "username");
                _mockUserProfileService
                    .Setup(x => x.GetUserProfile("username"))
                    .Returns(new UserProfile
                                 {
                                     Trapped = new List<Flick>
                                                   {
                                                       new Flick(),
                                                       new Flick(),
                                                       new Flick(),
                                                       new Flick(),
                                                       new Flick(),
                                                   }
                                 });
            };

        Because of = () => _result = _controller.Index();

        It should_return_a_result = 
            () => _result.ShouldNotBeNull();
        It should_return_a_view = 
            () => _result.ShouldBeAView();
        It should_return_a_result_with_a_view_model = 
            () => _result.ShouldBeAView().And().ViewData.Model.ShouldNotBeNull();
        It should_return_a_view_with_five_trapped_flicks = 
            () => _result.Model<HomeViewModel>().Trapped.Count().ShouldEqual(5);
    }
}