using FlickTrap.Domain.Abstract;
using Machine.Specifications;
using Moq;

namespace FlickTrap.Domain.Specs.UserProfileServiceSpecs
{
    public abstract class given_a_user_profile_service_context
    {
        protected static UserProfileService _userProfileService;
        protected static Mock<IUserProfileRepository> _mockUserProfileRepository;

        Establish a_user_profile_service = () =>
            {
                _mockUserProfileRepository = new Mock<IUserProfileRepository>();
            
                _userProfileService = new UserProfileService( _mockUserProfileRepository.Object );
            };
    }
}