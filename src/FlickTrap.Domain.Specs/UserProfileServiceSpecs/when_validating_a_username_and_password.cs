using Machine.Specifications;

namespace FlickTrap.Domain.Specs.UserProfileServiceSpecs
{
    [Subject(typeof (UserProfileService))]
    public class when_validating_a_username_and_password : given_a_user_profile_service_context
    {
        static bool _result;

        Establish context = () => _mockUserProfileRepository.Setup(x => x.GetUserProfile(Moq.It.IsAny<string>())).Returns(new UserProfile
                                                                                                                                 {
                                                                                                                                     Password = "password"
                                                                                                                                 });

        Because of = () => _result = _userProfileService.Validate("username", "password");

        It should_return_true = () => _result.ShouldBeTrue();

        It should_request_a_profile_from_the_repository = () => _mockUserProfileRepository.Verify(x => x.GetUserProfile(Moq.It.IsAny<string>()));
    }
}