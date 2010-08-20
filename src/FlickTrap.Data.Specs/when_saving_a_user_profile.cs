using FlickTrap.Domain;
using Machine.Specifications;

namespace FlickTrap.Data.Specs
{
    [Subject(typeof (UserProfileRepository))]
    public class when_saving_a_user_profile
    {
        static UserProfileRepository _userProfileRepository;
        static UserProfile _result;

        Establish context = () =>
            {
                var session = SessionFactorySingleton.Current().OpenSession();

                SessionFactorySingleton.FluentNHibernateConfiguration.CreateDatabase( session );

                _userProfileRepository = new UserProfileRepository( session );
            };

        Because of = () => _result = _userProfileRepository.Save(new UserProfile());

        It should_should_return_a_user_profile = () => _result.ShouldNotBeNull();
        It should_return_a_user_profile_with_an_id = () => _result.Id.ShouldNotEqual(0);
    }
}