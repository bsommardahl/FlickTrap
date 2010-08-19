using System;
using FlickTrap.Domain.Exceptions;
using Machine.Specifications;

namespace FlickTrap.Domain.Specs.FlickInfoServiceSpecs
{
    [Subject(typeof (FlickInfoService))]
    public class when_trapping_a_flick_with_unauthenticated_user : given_a_flick_info_service_context
    {
        static Exception _exception;

        Because of = () => { _exception = Catch.Exception(() => _flickInfoService.Trap(null, "123")); };

        It should_throw_an_exception = () => _exception.ShouldNotBeNull();
        It should_throw_the_correct_exception = () => _exception.ShouldBeOfType(typeof (UserProfileNotFoundException));
    }
}