﻿using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace FlickTrap.Domain.Specs.FlickInfoServiceSpecs
{
    [Subject(typeof (FlickInfoService))]
    public class when_unauthenticated_user_requests_a_flick : given_a_flick_info_service_context
    {
        static Flick _result;

        Establish context = () => _mockFlickInfoWebServiceFacade
                                      .Setup(x => x.DownloadFlickInfo("1"))
                                      .Returns(new Flick
                                                   {
                                                       RemoteId = "1"
                                                   });

        Because of = () => _result = _flickInfoService.GetFlick(string.Empty, "1");

        It should_return_a_flick = () => _result.ShouldNotBeNull();
        It should_return_the_correct_flick = () => _result.RemoteId.ShouldEqual("1");
        It should_not_request_a_user_profile = () => _mockUserProfileRepository.Verify(x => x.GetUserProfile("username"), Times.Never());
        It should_request_a_flick_from_the_info_service = () => _mockFlickInfoWebServiceFacade.Verify(x => x.DownloadFlickInfo("1"));
    }
}