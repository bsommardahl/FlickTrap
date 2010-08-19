using FlickTrap.Domain.Abstract;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace FlickTrap.Domain.Specs.UserProfileServiceSpecs
{
    [Subject(typeof (UserProfileService))]
    public class when_creating_a_user_profile_with_success
    {
        static UserProfileService _userProfileService;
        static Mock<IUserProfileRepository> _mockUserProfileRepository;
        static UserProfile _result;

        Establish a_user_profile_service = () =>
            {
                _mockUserProfileRepository = new Mock<IUserProfileRepository>();
                _mockUserProfileRepository.Setup(x => x.Save(Moq.It.IsAny<UserProfile>())).Returns(new UserProfile
                                                                                                       {
                                                                                                           Id = 1
                                                                                                       });
                _userProfileService = new UserProfileService(_mockUserProfileRepository.Object);
            };

        Because we_attempt_to_create_a_user_profile = () => _result = _userProfileService.CreateUserProfile(new UserProfile());

        It should_return_a_result = () => _result.ShouldNotBeNull();
        It should_save_the_profile_to_the_repository = () => _result.Id.ShouldNotEqual(0);
    }
}