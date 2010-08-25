using FlickTrap.Domain;
using Machine.Specifications;
using TheMovieDB;

namespace FlickTrap.Data.Specs
{
    public abstract class given_a_flick_info_web_service_facade
    {
        protected static TmdbApiFacade _tmdbApiFacade;

        Establish context = () =>
        {
            var api = new TmdbAPI( "20775617b505949e2d11b870e87cf1d6" );
            _tmdbApiFacade = new TmdbApiFacade( api );
        };

    }

    [Subject(typeof (TmdbApiFacade))]
    public class when_downloading_flick_into_with_failure : given_a_flick_info_web_service_facade
    {
        static Flick _result;

        Because of = () => _result = _tmdbApiFacade.DownloadFlickInfo( "-123" );

        It should_return_null = () => _result.ShouldBeNull();
    }
}