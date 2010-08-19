using System;
using System.Collections.Generic;
using FlickTrap.Domain.Exceptions;
using Machine.Specifications;

namespace FlickTrap.Domain.Specs.FlickInfoServiceSpecs
{
    [Subject(typeof (FlickInfoService))]
    public class when_untrapping_a_flick_that_is_not_already_trapped : given_a_flick_info_service_context
    {
        static Exception _exception;

        Establish additional_context = () => _mockUserProfileRepository.Setup(x => x.GetUserProfile("username"))
                                                 .Returns(new UserProfile
                                                              {
                                                                  Trapped = new List<Flick> {new Flick {ImdbId = "123"}}
                                                              });

        Because of = () => _exception = Catch.Exception(() => _flickInfoService.Untrap("username", "123-bad"));

        It should_throw_an_exception = () => _exception.ShouldNotBeNull();
        It should_throw_the_correct_exception = () => _exception.ShouldBeOfType(typeof (FlickNotFoundException));
    }
}