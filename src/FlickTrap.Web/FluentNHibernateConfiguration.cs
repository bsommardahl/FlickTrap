using System;
using FlickTrap.Domain;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace FlickTrap.Web
{
    public class FluentNHibernateConfiguration
    {
        readonly IPersistenceConfigurer _persistenceConfigurer;
        public FluentConfiguration FluentConfiguration
        {
            get;
            set;
        }

        public FluentNHibernateConfiguration( IPersistenceConfigurer persistenceConfigurer )
        {
            _persistenceConfigurer = persistenceConfigurer;
            FluentConfiguration = BuildConfiguration();
        }

        public FluentConfiguration BuildConfiguration()
        {
            return Fluently.Configure()
                .Database(_persistenceConfigurer)
                .Mappings(m =>
                          m.AutoMappings
                              .Add(AutoMap.AssemblyOf<EntityBase>()
                                       .IgnoreBase<EntityBase>()
                                       .Where(t => t.BaseType != null && t.BaseType.Equals(typeof (EntityBase)))
                                       .Override<UserProfile>(x => x.HasMany(y => y.Trapped).Cascade.SaveUpdate())
                                       .UseOverridesFromAssemblyOf<FlickOverride>()

                              ));
        }

        public void CreateDatabase( ISession session )
        {
            new SchemaExport( FluentConfiguration.BuildConfiguration() ).Execute(
                /* script to console is */ false,
                /* export to database is */ true,
                /* drop only is */ false,
                                           session.Connection,
                /* TextWriter is */ null );

            session.Flush();
        }

        public ISessionFactory BuildSessionFactory()
        {
            var sessionFactory = FluentConfiguration.BuildSessionFactory();
            return sessionFactory;
        }
    }
}