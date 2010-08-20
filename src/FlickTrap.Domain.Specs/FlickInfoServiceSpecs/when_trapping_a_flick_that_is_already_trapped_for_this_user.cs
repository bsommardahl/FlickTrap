using System.Collections.Generic;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace FlickTrap.Domain.Specs.FlickInfoServiceSpecs
{
    [Subject(typeof (FlickInfoService))]
    public class when_trapping_a_flick_that_is_already_trapped_for_this_user : given_a_flick_info_service_context
    {
        static Flick _result;

        Establish additional_context = () => _mockUserProfileRepository.Setup(x => x.GetUserProfile("username")).Returns(new UserProfile
                                                                                                                             {
                                                                                                                                 Trapped = new List<Flick> {new Flick {ImdbId = "123"}}
                                                                                                                             });

        Because of = () => _flickInfoService.Trap("username", "123");

        It should_not_add_the_flick_to_the_profile = () => _mockUserProfileRepository.Verify(x => x.Save(Moq.It.IsAny<UserProfile>()), Times.Never());
    }
}