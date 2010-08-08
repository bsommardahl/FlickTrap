using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;
using IContainer = System.ComponentModel.IContainer;

namespace FlickTrap.Web
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance( RequestContext requestContext, Type controllerType)
        {
            try
            {
                return ObjectFactory.GetInstance( controllerType ) as Controller;

            }
            catch( StructureMapException )
            {
                System.Diagnostics.Debug.WriteLine( ObjectFactory.WhatDoIHave() );
                throw;
            }
        }
    }
}