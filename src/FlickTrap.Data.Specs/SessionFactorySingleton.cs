using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlickTrap.Web;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using StructureMap;

namespace FlickTrap.Infrastructure.Specs
{
    public static class SessionFactorySingleton
    {
        static ISessionFactory _sessionFactory;
        public static FluentNHibernateConfiguration FluentNHibernateConfiguration;

        static SessionFactorySingleton()
        {
            var persistenceConfigurer = SQLiteConfiguration.Standard.InMemory();
            FluentNHibernateConfiguration = new FluentNHibernateConfiguration( persistenceConfigurer );

            ObjectFactory.Configure( x =>
            {
                x.For<ISessionFactory>()
                    .Singleton()
                    .Use( FluentNHibernateConfiguration.BuildSessionFactory );

                x.For<ISession>()
                    .Use( context => context.GetInstance<ISessionFactory>().OpenSession() );
            } );
        }

        public static ISessionFactory Current()
        {
            return _sessionFactory ?? ( _sessionFactory = ObjectFactory.GetInstance<ISessionFactory>() );
        }
    }
}
