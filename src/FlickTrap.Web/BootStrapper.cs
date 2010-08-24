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
        public BootStrapper()
        {
            ObjectFactory.Configure(x => x.AddRegistry<DependencyRegistry>());
        }

        public void Run()
        {
            var tasks = ObjectFactory.GetAllInstances<IBootstrapperTask>();
            foreach( var task in tasks )
                task.Execute();
        }
    }
}