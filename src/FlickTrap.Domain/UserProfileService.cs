using System;
using FlickTrap.Domain.Abstract;

namespace FlickTrap.Domain
{
    public class UserProfileService : IUserProfileService
    {
        readonly IUserProfileRepository _userProfileRepository;

        public UserProfileService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public UserProfile CreateUserProfile(UserProfile userProfile)
        {
            return _userProfileRepository.Save(userProfile);
        }

        public UserProfile GetUserProfile(int userProfileId)
        {
            throw new NotImplementedException();
        }

        public UserProfile UpdateUserProfile(UserProfile userProfile)
        {
            throw new NotImplementedException();
        }

        public bool Validate(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
