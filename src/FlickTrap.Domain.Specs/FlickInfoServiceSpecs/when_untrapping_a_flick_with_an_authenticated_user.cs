using System.Collections.Generic;
using Machine.Specifications;

namespace FlickTrap.Domain.Specs.FlickInfoServiceSpecs
{
    [Subject(typeof (FlickInfoService))]
    public class when_untrapping_a_flick_with_an_authenticated_user : given_a_flick_info_service_context
    {
        Establish additional_context = () => _mockUserProfileRepository.Setup(x => x.GetUserProfile("username"))
                                                 .Returns(new UserProfile
                                                              {
                                                                  Trapped = new List<Flick> { new Flick { RemoteId = "123" } }
                                                              });

        Because of = () => _flickInfoService.Untrap("username", "123");

        It should_remove_the_flick_from_the_users_trapped_list = () => _mockUserProfileRepository.Verify(x => x.Save(Moq.It.IsAny<UserProfile>()));
    }
}