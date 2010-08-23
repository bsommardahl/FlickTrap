using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using StructureMap;

namespace FlickTrap.Web.Controllers
{
    public class ConfigController : Controller
    {
        public ActionResult CreateDatabase()
        {
            var persistenceConfigurer = MsSqlConfiguration.MsSql2008
                .ConnectionString( c => c.FromConnectionStringWithKey( "FlickTrap" ) );

            new FluentNHibernateConfiguration( persistenceConfigurer ).CreateDatabase( ObjectFactory.GetInstance<ISession>() );

            return Content("Created.");
        }
    }
}
