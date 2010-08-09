using System.Collections.Generic;
using System.Linq;
using FlickTrap.Domain;
using Machine.Specifications;

namespace FlickTrap.Data.Specs
{
    namespace FlickInfoWebServiceFacadeSpecs
    {
        [Subject(typeof (FlickInfoWebServiceFacade))]
        public class when_downloading_flick_info_with_success
        {
            static FlickInfoWebServiceFacade _flickInfoWebServiceFacade;
            static Flick _result;

            Establish context = () => { _flickInfoWebServiceFacade = new FlickInfoWebServiceFacade(); };

            Because of = () => _result = _flickInfoWebServiceFacade.DownloadFlickInfo("tt0066921");

            It should_return_a_flick = () => _result.ShouldNotBeNull();
            It should_return_a_flick_with_the_correct_name = () => _result.Name.ShouldEqual("A Clockwork Orange");
        }

        [Subject(typeof (FlickInfoWebServiceFacade))]
        public class when_downloading_flick_into_with_failure
        {
            static FlickInfoWebServiceFacade _flickInfoWebServiceFacade;
            static Flick _result;

            Establish context = () => { _flickInfoWebServiceFacade = new FlickInfoWebServiceFacade(); };

            Because of = () => _result = _flickInfoWebServiceFacade.DownloadFlickInfo("invalid_id");

            It should_return_null = () => _result.ShouldBeNull();
        }

        [Subject(typeof (FlickInfoWebServiceFacade))]
        public class when_searching_for_flicks_with_results
        {
            static FlickInfoWebServiceFacade _flickInfoWebServiceFacade;
            static IEnumerable<Flick> _result;

            Establish context = () => { _flickInfoWebServiceFacade = new FlickInfoWebServiceFacade(); };

            Because of = () => _result = _flickInfoWebServiceFacade.Search("Football");

            It should_return_a_list_of_flicks = () => _result.ShouldNotBeNull();
            It should_return_more_than_one_flick = () => _result.Count().ShouldBeGreaterThan(1);
        }

        [Subject(typeof (FlickInfoWebServiceFacade))]
        public class when_searching_for_flicks_with_no_results
        {
            static FlickInfoWebServiceFacade _flickInfoWebServiceFacade;
            static IEnumerable<Flick> _result;

            Establish context = () => { _flickInfoWebServiceFacade = new FlickInfoWebServiceFacade(); };

            Because of = () => _result = _flickInfoWebServiceFacade.Search("zzzzzz0101029");

            It should_not_return_null = () => _result.ShouldNotBeNull();
            It should_return_an_empty_list = () => _result.Count().ShouldEqual(0);
        }

    }
}