using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FlickTrap.Domain.Abstract;
using FlickTrap.Domain.Exceptions;

namespace FlickTrap.Domain
{
    public class FlickInfoService : IFlickInfoService
    {
        readonly IFlickInfoWebServiceFacade _flickInfoWebServiceFacade;
        readonly IUserProfileRepository _userProfileRepository;
        readonly IFlickRepository _flickRepository;

        public FlickInfoService(IFlickInfoWebServiceFacade flickInfoWebServiceFacade, 
                                IUserProfileRepository userProfileRepository, 
                                IFlickRepository flickRepository)
        {
            _flickInfoWebServiceFacade = flickInfoWebServiceFacade;
            _userProfileRepository = userProfileRepository;
            _flickRepository = flickRepository;
        }

        public IEnumerable<Flick> GetRecentlyReleasedFlicks()
        {
            return _flickRepository.GetRecentlyReleased();
        }

        public IEnumerable<Flick> GetUnreleasedFlicks()
        {
            return _flickRepository.GetUnreleasedFlicks();
        }

        public Flick GetFlick(string username, string imdbId)
        {
            //try to get flick from trapped flicks
            if( !string.IsNullOrEmpty( username ) )
            {
                var userProfile = _userProfileRepository.GetUserProfile(username);
                if(userProfile==null)
                    throw new UserProfileNotFoundException();

                if (userProfile.Trapped != null)
                    return userProfile.Trapped.SingleOrDefault(x => x.ImdbId == imdbId);
            }

            //try to get flick from web service
            var downloadedFlick = _flickInfoWebServiceFacade.DownloadFlickInfo(imdbId);
            return downloadedFlick;            
        }

        public void Trap(string username, string imdbId)
        {
            //get user profile
            var userProfile = _userProfileRepository.GetUserProfile(username);
            if( userProfile == null )
                throw new UserProfileNotFoundException();

            //don't add if already present
            if( userProfile.Trapped != null && userProfile.Trapped.Any( x => x.ImdbId == imdbId ) )
                return;

            //get flick from web service
            var flickToTrap = _flickInfoWebServiceFacade.DownloadFlickInfo(imdbId);
            if( flickToTrap == null )
                throw new FlickNotFoundException();

            userProfile.AddTrappedFlick(flickToTrap);

            _userProfileRepository.Save(userProfile);
        }

        public void Untrap(string username, string imdbId)
        {
            var userProfile = _userProfileRepository.GetUserProfile( username );
            if(userProfile==null)
                throw new UserProfileNotFoundException();

            var flickToRemove = userProfile.Trapped.SingleOrDefault(x => x.ImdbId == imdbId);
            if(flickToRemove==null)
                throw new FlickNotFoundException();

            userProfile.RemoveTrappedFlick(flickToRemove);

            _userProfileRepository.Save(userProfile);
        }

        public IEnumerable<Flick> Search(string searchText)
        {
            if( string.IsNullOrEmpty( searchText.Trim() ) )
                return new List<Flick>();

            var flicks = _flickInfoWebServiceFacade.Search(searchText);
            return flicks ?? new List<Flick>();
        }
    }
}