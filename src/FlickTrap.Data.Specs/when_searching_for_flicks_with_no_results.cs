using System.Collections.Generic;
using System.Linq;
using FlickTrap.Domain;
using Machine.Specifications;

namespace FlickTrap.Data.Specs
{
    [Subject(typeof (TmdbApiFacade))]
    public class when_searching_for_flicks_with_no_results : given_a_flick_info_web_service_facade
    {
        static IEnumerable<Flick> _result;

        Because of = () => _result = _tmdbApiFacade.Search("zzzzzz0101029");

        It should_not_return_null = () => _result.ShouldNotBeNull();
        It should_return_an_empty_list = () => _result.Count().ShouldEqual(0);
    }
}