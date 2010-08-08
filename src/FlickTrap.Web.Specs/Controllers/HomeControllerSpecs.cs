using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.SessionState;
using FlickTrap.Domain;
using FlickTrap.Web.Controllers;
using FlickTrap.Web.Models;
using Machine.Specifications;
using Moq;
using MvcFakes;
using It = Machine.Specifications.It;

namespace FlickTrap.Web.Specs.Controllers
{
    namespace HomeControllerSpecs
    {
        public abstract class given_a_home_controller_context
        {
            protected static HomeController _controller;
            protected static Mock<IFlickInfoService> _flickInfoService;
            protected static List<Flick> _list_of_flicks;

            Establish a_home_controller_context = () =>
                {
                    _flickInfoService = new Mock<IFlickInfoService>();

                    _controller = new HomeController(_flickInfoService.Object);
                    _controller.ControllerContext = new FakeControllerContext(_controller, new SessionStateItemCollection());

                    _list_of_flicks = new List<Flick>
                                          {
                                              new Flick {},
                                              new Flick(),
                                              new Flick(),
                                              new Flick(),
                                              new Flick(),
                                              new Flick(),
                                              new Flick(),
                                              new Flick(),
                                              new Flick(),
                                              new Flick(),
                                              new Flick(),
                                              new Flick(),
                                              new Flick(),
                                              new Flick(),
                                              new Flick(),
                                          };

                    _flickInfoService.Setup(x => x.GetRecentlyReleasedFlicks()).Returns(_list_of_flicks);

                    _flickInfoService.Setup(x => x.GetUnreleasedFlicks()).Returns(_list_of_flicks);
                };
        }

        [Subject(typeof (HomeController))]
        public class when_an_unknown_user_visits_the_home_page : given_a_home_controller_context
        {
            static UserProfile _userProfile;
            protected static ActionResult _result;

            Behaves_like<a_successful_home_page> a_successful_home_page;

            Because of = () => { _result = _controller.Index(); };

            It should_persist_user_profile_to_session = () => _controller.Session["UserProfile"].ShouldBeOfType(typeof (UserProfile));
            It should_provide_user_with_a_guest_profile = () => ((UserProfile) _controller.Session["UserProfile"]).Id.ShouldEqual(0);
            It should_provide_user_with_a_guest_profile_with_guest_name = () => ((UserProfile) _controller.Session["UserProfile"]).Name.ShouldEqual("Guest");
            It should_provide_user_with_a_guest_profile_with_guest_status = () => ((UserProfile) _controller.Session["UserProfile"]).Status.ShouldEqual(UserProfileStatus.Guest);
        }

        [Behaviors]
        public class a_successful_home_page
        {
            protected static ActionResult _result;

            It should_return_a_view = () => _result.ShouldBeOfType(typeof (ViewResult));
            It should_return_a_view_with_a_list_of_five_unreleased_movies = () => ((HomeViewModel) ((ViewResult) _result).ViewData.Model).UnreleasedFlicks.Count().ShouldEqual(5);
            It should_return_a_view_with_a_list_of_ten_recently_released_movies = () => ((HomeViewModel) ((ViewResult) _result).ViewData.Model).RecentlyReleasedFlicks.Count().ShouldEqual(10);
        }

        [Subject(typeof (HomeController))]
        public class when_a_user_returns_to_the_home_page : given_a_home_controller_context
        {
            static UserProfile _valid_user_profile;
            protected static ActionResult _result;

            Behaves_like<a_successful_home_page> a_successful_home_page;

            Establish context = () =>
                {
                    _valid_user_profile = new UserProfile
                                              {
                                                  Name = "user",
                                                  Id = 1
                                              };

                    _controller.Session["UserProfile"] = _valid_user_profile;
                };

            Because of = () => _result = _controller.Index();

            It should_not_change_the_profile_in_session = () => _controller.Session["UserProfile"].ShouldBeTheSameAs(_valid_user_profile);
        }
    }
}