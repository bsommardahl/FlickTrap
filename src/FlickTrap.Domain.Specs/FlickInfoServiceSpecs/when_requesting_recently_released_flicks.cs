using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;

namespace FlickTrap.Domain.Specs.FlickInfoServiceSpecs
{
    [Subject(typeof (FlickInfoService))]
    public class when_requesting_recently_released_flicks : given_a_flick_info_service_context
    {
        static IEnumerable<Flick> _result;

        Establish additional_context = () =>
            {
                var recentlyReleasedFlicks = new List<Flick>
                                                 {
                                                     new Flick {Name = "Hitch", Rating = "PG-13", TheaterReleaseDate = new DateTime(2010, 1, 1)},
                                                     new Flick {Name = "Immortal", Rating = "PG-13", TheaterReleaseDate = new DateTime(2010, 1, 1)},
                                                     new Flick {Name = "Airbender", Rating = "PG", TheaterReleaseDate = new DateTime(2010, 1, 1)},
                                                     new Flick {Name = "Avatar", Rating = "PG-13", TheaterReleaseDate = new DateTime(2010, 1, 1)},
                                                     new Flick {Name = "Handy", Rating = "PG", TheaterReleaseDate = new DateTime(2010, 1, 1)},
                                                     new Flick {Name = "The Horse", Rating = "G", TheaterReleaseDate = new DateTime(2010, 1, 1)},
                                                     new Flick {Name = "Revenge of the Nerds VIII", Rating = "PG-13", TheaterReleaseDate = new DateTime(2010, 1, 1)},
                                                     new Flick {Name = "Alien vs Predator", Rating = "R", TheaterReleaseDate = new DateTime(2010, 1, 1)},
                                                     new Flick {Name = "Love Hurts", Rating = "PG", TheaterReleaseDate = new DateTime(2010, 1, 1)},
                                                 };

                _mockFlickRepository.Setup(x => x.GetRecentlyReleased()).Returns(recentlyReleasedFlicks);
            };

        Because of = () => _result = _flickInfoService.GetRecentlyReleasedFlicks();

        It should_return_a_list_of_flicks = () => _result.ShouldNotBeNull();
        It should_return_the_correct_number_of_flicks = () => _result.Count().ShouldEqual(9);
        It should_return_the_first_flick_with_the_correct_name = () => _result.First().Name.ShouldEqual("Hitch");
    }
}