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
            return _userProfileRepository.GetUserProfile(userProfileId);
        }

        public UserProfile UpdateUserProfile(UserProfile userProfile)
        {
            return _userProfileRepository.Save(userProfile);
        }

        public bool Validate(string username, string password)
        {
            var userProfile = _userProfileRepository.GetUserProfile(username);
            return userProfile.Password == password;
        }

        public UserProfile GetUserProfile(string userName)
        {
            return _userProfileRepository.GetUserProfile(userName);
        }
    }
}
