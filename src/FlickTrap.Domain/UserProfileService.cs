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
            var userProfile = _userProfileRepository.Read(id);
            if( userProfile == null )
                return null;

            return userProfile;
        }

        public UserProfile Save(UserProfile userProfile)
        {
            if(userProfile.Id==0)
            {
                //creating a new profile
                return _userProfileRepository.Create(userProfile);
            }
            
            //updating existing profile
            return _userProfileRepository.Update(userProfile);
            
        }

        public bool Delete(UserProfile userProfile)
        {
            if( userProfile.Id == 0 )
                return false;

            _userProfileRepository.Delete(userProfile);
            return true;
        }
    }
}