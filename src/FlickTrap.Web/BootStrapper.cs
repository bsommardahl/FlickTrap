using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using FlickTrap.Web;
using StructureMap;

namespace FlickTrap.Web
{
    public static class BootStrapper
    {
        static BootStrapper()
        {
            ConfigureContainer();
        }

        static void ConfigureContainer()
        {
            ObjectFactory.Configure(x => x.AddRegistry(new DependencyRegistry()));
        }

        public static void Run()
        {
            var tasks = ObjectFactory.GetAllInstances<IBootstrapperTask>();
            foreach(var task in tasks)
                task.Execute();
        }
    }
}