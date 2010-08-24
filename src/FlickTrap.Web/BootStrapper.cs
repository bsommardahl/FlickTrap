using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            var tasks = _container.GetAllInstances<IBootstrapperTask>();
            foreach( var task in tasks )
                task.Execute();
        }
    }
}