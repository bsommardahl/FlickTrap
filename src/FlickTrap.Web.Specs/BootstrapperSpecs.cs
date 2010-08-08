using FlickTrap.Web.Controllers;
using Machine.Specifications;
using StructureMap;

namespace FlickTrap.Web.Specs
{
    namespace BootstrapperSpecs
    {
        [Subject(typeof (BootStrapper))]
        public class when_bootstrapper_is_run
        {
            static BootStrapper _bootStrapper;
            static Container _container;

            Establish context = () =>
                {
                    _container = new Container();
                    _bootStrapper = new BootStrapper(_container);
                };

            Because of = () => _bootStrapper.Run();

            It should_map_home_controller = () => _container.GetInstance(typeof (HomeController)).ShouldNotBeNull();
        }
    }
}