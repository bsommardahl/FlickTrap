using Machine.Specifications;
using NHibernate;
using StructureMap;

namespace FlickTrap.Web.Specs.Bootstrapper
{
    [Subject(typeof (ConfigureNHibernate))]
    public class when_registering_nhibernate_session_factory
    {
        Establish context = () =>
        {
            _configureNHibernate = new ConfigureNHibernate();
        };

        Because of = () =>
        {
            _container = ObjectFactory.Container;
            _configureNHibernate.Execute();
        };

        It should_register_the_session_factory = () => _container.GetInstance<ISessionFactory>().ShouldBeOfType( typeof( ISessionFactory ) );
        It should_not_return_a_null_session_factory = () => _container.GetInstance<ISessionFactory>().ShouldNotBeNull();
        It should_register_the_session = () => _container.GetInstance<ISession>().ShouldBeOfType( typeof( ISession ) );
        It should_not_return_a_null_session = () => _container.GetInstance<ISession>().ShouldNotBeNull();

        static ConfigureNHibernate _configureNHibernate;
        static IContainer _container;
    }
}