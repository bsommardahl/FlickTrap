using System.Web.Mvc;
using MvcTurbine.ComponentModel;
using MvcTurbine.StructureMap;
using MvcTurbine.Web;
using StructureMap;

namespace FlickTrap.Web
{
    public class MvcApplication : TurbineApplication
    {
        public MvcApplication()
        {
            //configure container
            var container = new Container(new DependencyRegistry());

            //BootStrapper.Run();
            ServiceLocatorManager.SetLocatorProvider(() => new StructureMapServiceLocator(container));
        }

        public void Application_Start()
        {
        }
    }
}