using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;

namespace FlickTrap.Domain.Specs.FlickInfoServiceSpecs
{
    [Subject(typeof (FlickInfoService))]
    public class when_searching_for_a_flick_with_results : given_a_flick_info_service_context
    {
        static IEnumerable<Flick> _result;

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

                _mockFlickInfoWebServiceFacade.Setup(x => x.Search("a movie")).Returns(_a_list_of_flicks);
            };

        Because of = () => _result = _flickInfoService.Search("a movie");

        It should_return_a_list_of_five_flicks = () => _result.Count().ShouldEqual(5);
        It should_return_a_list_of_flicks = () => _result.ShouldNotBeNull();
    }
}