using System.Web.Mvc;
using FlickTrap.Domain;
using StructureMap.Configuration.DSL;

namespace FlickTrap.Web
{
    public class DependencyRegistry : Registry
    {
        public DependencyRegistry()
        {
            RegisterTypes();
        }

        void RegisterTypes()
        {
            For<IControllerFactory>().Use<StructureMapControllerFactory>();
            For<IFlickInfoService>().Use<DefaultFlickInfoService>();
            
        }
    }
}