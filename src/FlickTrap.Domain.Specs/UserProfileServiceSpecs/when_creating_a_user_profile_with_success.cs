using Machine.Specifications;
using Parameter = Moq.It;

namespace FlickTrap.Domain.Specs.UserProfileServiceSpecs
{
    [Subject(typeof (UserProfileService))]
    public class when_creating_a_user_profile_with_success : given_a_user_profile_service_context
    {
        static UserProfile _result;

        Establish context = () => _mockUserProfileRepository.Setup(x => x.Save(Parameter.IsAny<UserProfile>())).Returns(new UserProfile
                                                                                                                     {
                                                                                                                         Id = 1
                                                                                                                     });

        Because we_attempt_to_create_a_user_profile = () => _result = _userProfileService.CreateUserProfile(new UserProfile());

        It should_return_a_result = () => _result.ShouldNotBeNull();

        It should_return_a_saved_profile = () => _result.Id.ShouldNotEqual(0);

        It should_save_the_profile_to_the_respository = () => _mockUserProfileRepository.Verify( x => x.Save( Parameter.IsAny<UserProfile>() ) );
        
    }
}