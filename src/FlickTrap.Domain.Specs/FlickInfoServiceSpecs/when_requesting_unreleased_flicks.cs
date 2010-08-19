using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;

namespace FlickTrap.Domain.Specs.FlickInfoServiceSpecs
{
    [Subject(typeof (FlickInfoService))]
    public class when_requesting_unreleased_flicks : given_a_flick_info_service_context
    {
        static IEnumerable<Flick> _result;

        Establish additional_context = () =>
            {
                var unreleasedFlicks = new List<Flick>
                                           {
                                               new Flick {Name = "Avatar II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                               new Flick {Name = "My Movie II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                               new Flick {Name = "Love Hurts II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                               new Flick {Name = "Karate Kid VII", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                               new Flick {Name = "Star Wars X", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                               new Flick {Name = "Hitch II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                               new Flick {Name = "Hannibal II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                               new Flick {Name = "Epic Movie", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                           };

                _mockFlickRepository.Setup(x => x.GetUnreleasedFlicks()).Returns(unreleasedFlicks);
            };

        Because of = () => _result = _flickInfoService.GetUnreleasedFlicks();

        It should_return_a_list_of_flicks = () => _result.ShouldNotBeNull();
        It should_return_the_correct_number_of_flicks = () => _result.Count().ShouldEqual(8);
        It should_return_the_first_flick_with_the_correct_name = () => _result.First().Name.ShouldEqual("Avatar II");
    }
}