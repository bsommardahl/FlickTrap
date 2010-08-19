using System;
using FlickTrap.Domain.Exceptions;
using Machine.Specifications;

namespace FlickTrap.Domain.Specs.FlickInfoServiceSpecs
{
    [Subject(typeof (FlickInfoService))]
    public class when_untrapped_flick_is_requested_by_invalid_user : given_a_flick_info_service_context
    {
        static UserProfile userProfile;
        static Flick _result;
        static Exception _exception;

        Establish additional_context = () =>
            {
                _mockFlickInfoWebServiceFacade.Setup(x => x.DownloadFlickInfo("123")).Returns(new Flick
                                                                                                  {
                                                                                                      Name = "Hitch"
                                                                                                  });
                userProfile = new UserProfile();
                _mockUserProfileRepository.Setup(x => x.GetUserProfile("username")).Returns(userProfile);
            };

        Because of = () => _exception = Catch.Exception(() => _result = _flickInfoService.GetFlick("username-bad", "123"));

        It should_throw_an_exception = () => _exception.ShouldNotBeNull();
        It should_throw_the_correct_exception = () => _exception.ShouldBeOfType(typeof (UserProfileNotFoundException));
    }
}