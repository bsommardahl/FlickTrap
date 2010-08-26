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
}