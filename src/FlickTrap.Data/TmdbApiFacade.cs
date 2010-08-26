using System;
using System.Collections.Generic;
using System.Linq;
using FlickTrap.Domain;
using FlickTrap.Domain.Abstract;
using TheMovieDB;

namespace FlickTrap.Data
{
    public class TmdbApiFacade : IFlickInfoWebServiceFacade
    {
        readonly TmdbAPI _tmdbApi;

        public TmdbApiFacade(TmdbAPI tmdbApi)
        {
            _tmdbApi = tmdbApi;
            //_api = new TmdbAPI( "20775617b505949e2d11b870e87cf1d6" );
        }

        public Flick DownloadFlickInfo(string remoteId)
        {
            if( remoteId == null )
                return null;

            var movie = _tmdbApi.GetMovieInfo( Convert.ToInt32(remoteId) );
            if( movie == null )
                return null;

            return MapFromMovie(movie);
            
        }

        public IEnumerable<Flick> Search(string searchText)
        {
            var movies = _tmdbApi.MovieSearch( searchText );
            return movies.Select(x => MapFromMovie(x));
        }

        static Flick MapFromMovie( TmdbMovie movie )
        {
            var image = movie.Images == null 
                ? null 
                : movie.Images.FirstOrDefault(x => 
                    x.Size == TmdbImageSize.cover 
                    && x.Type == TmdbImageType.poster);
                                    
            return new Flick
                       {
                           Name = movie.Name,
                           Budget = string.IsNullOrEmpty(movie.Budget) ? 0 : Convert.ToDecimal(movie.Budget),
                           Description = movie.Overview,
                           RemoteId = movie.Id.ToString(),
                           Rating = movie.Certification,
                           RentalReleaseDate = movie.Released.HasValue ? (DateTime?) movie.Released.Value.AddMonths(6) : null,
                           TheaterReleaseDate = movie.Released,
                           Revenue = string.IsNullOrEmpty(movie.Revenue) ? 0 : Convert.ToDecimal(movie.Revenue),
                           ThumbnailUrl = image == null  ? "" : image.Url
                        };
        }
    
    }

}