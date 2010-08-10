using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FlickTrap.Domain;
using FlickTrap.Domain.Abstract;
using FlickTrap.Web.Controllers;
using FlickTrap.Web.Models;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace FlickTrap.Web.Specs.Controllers
{
    namespace SearchControllerSpecs
    {
        public abstract class given_a_search_controller_context
        {
            protected static Mock<IFlickInfoService> _mockFlickInfoService;
            protected static SearchController _controller;

            Establish context = () =>
                {
                    new RegisterAutoMaps().Execute();

                    _mockFlickInfoService = new Mock<IFlickInfoService>();

                    _controller = new SearchController(_mockFlickInfoService.Object);
                };
        }

        [Subject(typeof (SearchController))]
        public class when_user_searches_for_a_flick_with_results : given_a_search_controller_context
        {
            static ActionResult _result;

            Establish additional_context = () =>
                {
                    var _a_list_of_flicks = new List<Flick>
                                                {
                                                    new Flick {Name = "Avatar II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                                    new Flick {Name = "My Movie II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                                    new Flick {Name = "Love Hurts II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                                    new Flick {Name = "Karate Kid VII", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                                    new Flick {Name = "Star Wars X", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                                };

                    _mockFlickInfoService.Setup(x => x.Search("search")).Returns(_a_list_of_flicks);
                };

            Because of = () => { _result = _controller.Index("search"); };

            It should_return_a_view = () => _result.ShouldBeOfType(typeof (ViewResult));
            It should_return_a_view_with_5_flicks = () => ((SearchViewModel) ((ViewResult) _result).ViewData.Model).Flicks.Count().ShouldEqual(5);
            It should_return_a_view_with_a_list_of_flicks = () => ((SearchViewModel) ((ViewResult) _result).ViewData.Model).Flicks.ShouldNotBeNull();
        }

        [Subject(typeof (SearchController))]
        public class when_user_searches_for_a_flick_with_no_results : given_a_search_controller_context
        {
            static ActionResult _result;
            
            Because of = () => _result = _controller.Index("bad search");
            
            It should_not_return_a_null_list = () => ((ViewResult) _result).ViewData.Model.ShouldNotBeNull();
            It should_return_a_view = () => _result.ShouldBeOfType(typeof (ViewResult));
            It should_return_an_empty_list_of_flicks = () => ((SearchViewModel) ((ViewResult) _result).ViewData.Model).Flicks.Count().ShouldEqual(0);
        }

        [Subject(typeof (SearchController))]
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