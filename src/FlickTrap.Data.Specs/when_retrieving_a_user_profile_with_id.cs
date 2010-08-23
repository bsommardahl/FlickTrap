using System.Collections.Generic;
using System.Linq;
using FlickTrap.Domain;
using Machine.Specifications;

namespace FlickTrap.Data.Specs
{
    [Subject( typeof( UserProfileRepository ) )]
    public class when_retrieving_a_user_profile_with_id
    {
        static UserProfileRepository _userProfileRepository;
        static UserProfile _result;

        Establish context = () =>
            {
                var session = SessionFactorySingleton.Current().OpenSession();

                SessionFactorySingleton.FluentNHibernateConfiguration.CreateDatabase( session );

                session.Save( new UserProfile
                                  {
                                      Username = "jason"
                                  } );
                session.Save( new UserProfile
                                  {
                                      Username = "byron",
                                      Trapped = new List<Flick>
                                                    {
                                                        new Flick{},
                                                        new Flick{},
                                                        new Flick{},
                                                    }

                                  } );

                session.Flush();

                _userProfileRepository = new UserProfileRepository( session );
            };

        Because of = () => _result = _userProfileRepository.GetUserProfile(2);

        It should_return_a_user_profile = () => _result.ShouldNotBeNull();
        It should_return_the_correct_user_profile = () => _result.Username.ShouldEqual( "byron" );
        It should_return_three_trapped_flicks = () => ShouldExtensionMethods.ShouldEqual(_result.Trapped.Count(), 3 );
    }
}