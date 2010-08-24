using System.Linq;
using System.Web.Mvc;
using FlickTrap.Domain;
using FlickTrap.Domain.Abstract;
using Machine.Specifications;
using MvcTurbine.Web.Controllers;
using StructureMap;

namespace FlickTrap.Web.Specs.Bootstrapper
{
    [Subject(typeof (DependencyRegistry))]
    public class when_registering_dependencies
    {
        static IContainer _container;

        Establish context = () =>
        {
            _container = new Container(x=>
                {
                    x.Scan(y=>
                        {
                            y.Assembly("FlickTrap.Web");
                            y.AddAllTypesOf<IBootstrapperTask>();
                            y.WithDefaultConventions();
                        });
                    x.For<IControllerFactory>().Use<TurbineControllerFactory>();
                });
        };

        It should_map_bootstrapper_tasks = 
            () => _container.GetAllInstances<IBootstrapperTask>().Count().ShouldBeGreaterThan(0);

        It should_map_controllers = () =>
                                    _container.GetAllInstances<IController>()
                                        .Any( x => x.GetType().Equals( typeof( Controllers.HomeController ) ) )
                                        .ShouldBeTrue();

        //It should_map_the_proper_controller_factory = () =>
        //                                              _container.GetInstance<IControllerFactory>().ShouldBeOfType(typeof (StructureMapControllerFactory));

        It should_map_a_domain_service_properly = () =>
                                                  _container.GetInstance<IFlickInfoService>().GetType().ShouldEqual( typeof( FlickInfoService ) );
    }
}