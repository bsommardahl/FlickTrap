using Machine.Specifications;
using It = Moq.It;

namespace FlickTrap.Domain.Specs.UserProfileServiceSpecs
{
    [Subject(typeof (UserProfileService))]
    public class when_validating_an_invalid_user : given_a_user_profile_service_context
    {
        private static bool _result;

        private Establish context =
            () => _mockUserProfileRepository
                      .Setup(x => x.GetUserProfile(It.IsAny<string>()))
                      .Returns((UserProfile) null);

        private Because of = () => _result = _userProfileService.Validate("bad-username", "password");

        private Machine.Specifications.It should_request_a_profile_from_the_repository =
            () => _mockUserProfileRepository.Verify(x => x.GetUserProfile(It.IsAny<string>()));

        private Machine.Specifications.It should_return_false = () => _result.ShouldBeFalse();
    }

    [Subject(typeof (UserProfileService))]
    public class when_validating_a_username_and_password : given_a_user_profile_service_context
    {
        private static bool _result;

        private Establish context =
            () => _mockUserProfileRepository.Setup(x => x.GetUserProfile(It.IsAny<string>())).Returns(new UserProfile
                                                                                                          {
                                                                                                              Password =
                                                                                                                  "password"
                                                                                                          });

        private Because of = () => _result = _userProfileService.Validate("username", "password");

        private Machine.Specifications.It should_request_a_profile_from_the_repository =
            () => _mockUserProfileRepository.Verify(x => x.GetUserProfile(It.IsAny<string>()));

        private Machine.Specifications.It should_return_true = () => _result.ShouldBeTrue();
    }
}