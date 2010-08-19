using FlickTrap.Domain;
using FlickTrap.Infrastructure.Specs.FlickInfoWebServiceFacadeSpecs;
using Machine.Specifications;

namespace FlickTrap.Infrastructure.Specs
{
    [Subject(typeof (TmdbApiFacade))]
    public class when_downloading_flick_info_with_success : given_a_flick_info_web_service_facade
    {
        static Flick _result;

        Because of = () => _result = _tmdbApiFacade.DownloadFlickInfo("tt0066921");

        It should_return_a_flick = () => _result.ShouldNotBeNull();
        It should_return_a_flick_with_the_correct_name = () => _result.Name.ShouldEqual("A Clockwork Orange");
    }
}