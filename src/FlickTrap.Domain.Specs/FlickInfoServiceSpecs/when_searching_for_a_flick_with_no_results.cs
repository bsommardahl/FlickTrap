using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;

namespace FlickTrap.Domain.Specs.FlickInfoServiceSpecs
{
    [Subject(typeof (FlickInfoService))]
    public class when_searching_for_a_flick_with_no_results : given_a_flick_info_service_context
    {
        static IEnumerable<Flick> _result;

        Because of = () => _result = _flickInfoService.Search("a movie");

        It should_return_an_empty_list = () => _result.Count().ShouldEqual(0);
    }
}