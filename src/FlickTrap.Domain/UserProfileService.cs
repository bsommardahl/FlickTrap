using System;

namespace FlickTrap.Domain
{
    public class UserProfileService
    {
        readonly IUserProfileRepository _userProfileRepository;

        public UserProfileService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public UserProfile Get(int id)
        {
            var userProfile = _userProfileRepository.Get(id);
            if( userProfile == null )
                return null;

            return userProfile;
        }
    }
}