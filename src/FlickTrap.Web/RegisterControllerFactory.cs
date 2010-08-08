using System.Web.Mvc;

namespace FlickTrap.Web
{
    public class RegisterControllerFactory : IBootstrapperTask
    {
        readonly IControllerFactory _controllerFactory;

        public RegisterControllerFactory( IControllerFactory controllerFactory )
        {
            _controllerFactory = controllerFactory;
        }

        public void Execute()
        {
            ControllerBuilder.Current.SetControllerFactory(_controllerFactory);
        }
    }
}