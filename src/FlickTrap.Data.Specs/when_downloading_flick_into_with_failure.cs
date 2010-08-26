using FlickTrap.Domain;
using Machine.Specifications;

namespace FlickTrap.Data.Specs
{
    [Subject(typeof (TmdbApiFacade))]
    public class when_downloading_flick_into_with_failure : given_a_flick_info_web_service_facade
    {
        static Flick _result;

        Because of = () => _result = _tmdbApiFacade.DownloadFlickInfo( "-123" );

        It should_return_null = () => _result.ShouldBeNull();
    }
}