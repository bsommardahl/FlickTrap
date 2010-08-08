using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using FlickTrap.Domain;
using StructureMap.Configuration.DSL;

namespace FlickTrap.Web
{
    public class DependencyRegistry : Registry
    {
        public DependencyRegistry()
        {
            Scan( x =>
            {
                x.TheCallingAssembly();
                x.AddAllTypesOf<IBootstrapperTask>();
                x.WithDefaultConventions();
            } );

            Scan(x =>
                {
                    x.IncludeNamespace("FlickTrap.Domain");
                    x.WithDefaultConventions();
                });

            For<IControllerFactory>().Use<StructureMapControllerFactory>();
            For<IFlickInfoService>().Use<FlickInfoService>();
        }
    }
}