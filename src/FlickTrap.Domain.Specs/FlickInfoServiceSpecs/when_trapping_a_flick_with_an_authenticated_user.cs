using Machine.Specifications;

namespace FlickTrap.Domain.Specs.FlickInfoServiceSpecs
{
    [Subject(typeof (FlickInfoService))]
    public class when_trapping_a_flick_with_an_authenticated_user : given_a_flick_info_service_context
    {
        static Flick _result;

        Establish additional_context = () =>
            {
                _mockUserProfileRepository.Setup(x => x.GetUserProfile("username")).Returns(new UserProfile());

                _mockFlickInfoWebServiceFacade.Setup(x => x.DownloadFlickInfo("123")).Returns(new Flick
                                                                                                  {
                                                                                                      Name = "Hitch"
                                                                                                  });
            };

        Because of = () => _flickInfoService.Trap("username", "123");

        It should_trap_the_flick_in_the_user_profile = () => _mockUserProfileRepository.Verify(x => x.Save(Moq.It.IsAny<UserProfile>()));
    }
}