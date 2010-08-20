using System.Collections.Generic;
using System.Linq;
using FlickTrap.Domain;
using Machine.Specifications;

namespace FlickTrap.Data.Specs
{
    [Subject(typeof (TmdbApiFacade))]
    public class when_searching_for_flicks_with_results : given_a_flick_info_web_service_facade
    {
        static IEnumerable<Flick> _result;

        Because of = () => _result = _tmdbApiFacade.Search("Football");

        It should_return_a_list_of_flicks = () => _result.ShouldNotBeNull();
        It should_return_more_than_one_flick = () => _result.Count().ShouldBeGreaterThan(1);
    }
}