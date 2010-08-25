using Machine.Specifications;

namespace FlickTrap.Domain.Specs.UserProfileServiceSpecs
{
    [Subject( typeof( UserProfileService ) )]
    public class when_retrieving_a_user_profile_with_username : given_a_user_profile_service_context
    {
        Establish context = () => _mockUserProfileRepository
                                      .Setup(x => x.GetUserProfile(Moq.It.IsAny<string>()))
                                      .Returns(new UserProfile
                                                   {
                                                   });

        Because of = () => _result = _userProfileService.GetUserProfile( "username");

        It should_return_a_user_profile = () => _result.ShouldNotBeNull();

        It should_get_the_profile_from_the_respository = () => _mockUserProfileRepository.Verify( x => x.GetUserProfile( Moq.It.IsAny<string>() ) );

        static UserProfile _result;
    }
}