using System.Linq;
using System.Web.Mvc;
using FlickTrap.Domain;
using FlickTrap.Domain.Abstract;
using Machine.Specifications;
using StructureMap;

namespace FlickTrap.Web.Specs.Bootstrapper
{
    [Subject(typeof (BootStrapper))]
    public class when_bootstrapper_is_run
    {
        Because of = BootStrapper.Run;

        It should_map_controllers = () =>
                                    ObjectFactory.GetAllInstances<IController>()
                                        .Where(x => x.GetType().Equals(typeof (Controllers.HomeController)))
                                        .ShouldNotBeNull();

        It should_map_the_proper_controller_factory = () =>
                                                      ObjectFactory.GetInstance<IControllerFactory>().ShouldBeOfType(typeof (StructureMapControllerFactory));

        It should_map_a_domain_service_properly = () =>
                                                  ObjectFactory.GetInstance<IFlickInfoService>().GetType().ShouldEqual(typeof (FlickInfoService));
    }
}