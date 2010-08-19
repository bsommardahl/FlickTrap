using System.Collections.Generic;
using Machine.Specifications;

namespace FlickTrap.Domain.Specs.FlickInfoServiceSpecs
{
    [Subject(typeof (FlickInfoService))]
    public class when_trapped_flick_is_requested_by_authenticated_user : given_a_flick_info_service_context
    {
        static UserProfile userProfile;
        static Flick _result;

        Establish additional_context = () =>
            {
                userProfile = new UserProfile
                                  {
                                      Trapped = new List<Flick> {new Flick {ImdbId = "123", Name = "Avatar"}}
                                  };
                _mockUserProfileRepository.Setup(x => x.GetUserProfile("username")).Returns(userProfile);
            };

        Because of = () => _result = _flickInfoService.GetFlick("username", "123");

        It should_return_correct_flick = () => _result.Name.ShouldEqual("Avatar");
    }
}