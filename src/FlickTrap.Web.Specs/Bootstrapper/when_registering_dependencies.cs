using System.Linq;
using System.Web.Mvc;
using FlickTrap.Domain;
using FlickTrap.Domain.Abstract;
using Machine.Specifications;
using StructureMap;

namespace FlickTrap.Web.Specs.Bootstrapper
{
    [Subject(typeof (DependencyRegistry))]
    public class when_registering_dependencies
    {
        Establish context = () =>
            {
                _container = ObjectFactory.Container;

                _container.Configure(x => x.AddRegistry<DependencyRegistry>());
            };
        It should_map_bootstrapper_tasks =
            () => _container.GetAllInstances<IBootstrapperTask>().Count().ShouldBeGreaterThan( 0 );

        It should_map_the_proper_controller_factory = () =>
                                                      _container.GetInstance<IControllerFactory>().ShouldBeOfType(typeof (StructureMapControllerFactory));

        static IContainer _container;
    }
}