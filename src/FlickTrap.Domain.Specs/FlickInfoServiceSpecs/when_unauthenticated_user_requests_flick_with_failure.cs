using Machine.Specifications;

namespace FlickTrap.Domain.Specs.FlickInfoServiceSpecs
{
    [Subject(typeof (FlickInfoService))]
    public class when_unauthenticated_user_requests_flick_with_failure : given_a_flick_info_service_context
    {
        static Flick _result;

        Because of = () => _result = _flickInfoService.GetFlick(null, "123-1");

        It should_return_null = () => _result.ShouldBeNull();
    }
}