using System;
using System.Collections.Generic;
using System.Linq;
using FlickTrap.Domain;
using FlickTrap.Domain.Abstract;
using FlickTrap.Domain.Exceptions;
using TheMovieDB;

namespace FlickTrap.Data
{
    public class FlickInfoWebServiceFacade : IFlickInfoWebServiceFacade
    {
        TmdbAPI _api;
        
        public FlickInfoWebServiceFacade()
        {
            _api = new TmdbAPI( "20775617b505949e2d11b870e87cf1d6" );
        }

        public Flick DownloadFlickInfo(string imdbId)
        {
            if( imdbId == null )
                return null;

            var movie = _api.MovieSearchByImdb(imdbId);
            if( movie == null || movie.Count() == 0 )
                return null;

            return MapFromMovie(movie[0], imdbId);
            
        }

        public IEnumerable<Flick> Search(string searchText)
        {
            var movies = _api.MovieSearch(searchText);
            return movies.Select(x => MapFromMovie(x, x.ImdbId));
        }

        static Flick MapFromMovie(TmdbMovie movie, string imdbId)
        {
            var image = movie.Images == null 
                ? null 
                : movie.Images.FirstOrDefault(x => 
                    x.Size == TmdbImageSize.cover 
                    && x.Type == TmdbImageType.poster);
                                    
            return new Flick
                       {
                           Name = movie.Name,
                           Budget = movie.Budget == null ? 0 : Convert.ToDecimal(movie.Budget),
                           Description = movie.Overview,
                           ImdbId = imdbId,
                           Rating = movie.Certification,
                           RentalReleaseDate = movie.Released.HasValue ? (DateTime?) movie.Released.Value.AddMonths(6) : null,
                           TheaterReleaseDate = movie.Released,
                           Revenue = movie.Revenue == null ? 0 : Convert.ToDecimal(movie.Revenue),
                           ThumbnailUrl = image == null ? "" : image.Url
                        };
        }
    
    }

}