using Machine.Specifications;

namespace FlickTrap.Domain.Specs.UserProfileServiceSpecs
{
    [Subject(typeof (UserProfileService))]
    public class when_updating_a_user_profile : given_a_user_profile_service_context
    {
        Establish context = () => _mockUserProfileRepository.Setup(x => x.Save(Moq.It.IsAny<UserProfile>())).Returns(new UserProfile
                                                                                                                            {
                                                                                                                            });

        Because of = () => _result = _userProfileService.UpdateUserProfile(new UserProfile
                                                                               {
                                                                               });

        It should_return_a_user_profile = () => _result.ShouldNotBeNull();

        It should_save_the_profile_to_the_respository = () => _mockUserProfileRepository.Verify(x => x.Save(Moq.It.IsAny<UserProfile>()));
        
        static UserProfile _result;
    }
}