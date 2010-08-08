using System;
using System.Web.Mvc;
using FlickTrap.Web;
using StructureMap;

namespace FlickTrap.Web
{
    public class BootStrapper
    {
        readonly IContainer _container;

        public BootStrapper(IContainer container)
        {
            _container = container;
        }

        public void Run()
        {
            ConfigureDependencies();
            ConfigureControllerFactory();
        }

        void ConfigureControllerFactory()
        {
            ControllerBuilder.Current.SetControllerFactory( _container.GetInstance<IControllerFactory>() );
        }

        void ConfigureDependencies()
        {
            _container.Configure( x => x.AddRegistry<DependencyRegistry>() );
        }
    }
}