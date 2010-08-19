using FluentNHibernate.Cfg.Db;
using NHibernate;
using StructureMap;

namespace FlickTrap.Web
{
    public class ConfigureNHibernate : IBootstrapperTask
    {
        public void Execute()
        {
            var persistenceConfigurer = MsSqlConfiguration.MsSql2008
                .ConnectionString( c => c.FromConnectionStringWithKey( "FlickTrap" ) );

            ObjectFactory.Configure( x =>
            {
                x.For<ISessionFactory>()
                    .Singleton()
                    .Use( () => new FluentNHibernateConfiguration( persistenceConfigurer ).BuildSessionFactory() );

                x.For<ISession>()
                    .HybridHttpOrThreadLocalScoped()
                    .Use( context => context.GetInstance<ISessionFactory>().OpenSession() );
            } );
        }
    }
}