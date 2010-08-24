using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using FlickTrap.Data;
using FlickTrap.Domain;
using FlickTrap.Domain.Abstract;
using StructureMap.Configuration.DSL;
using TheMovieDB;

namespace FlickTrap.Web
{
    public class DependencyRegistry : Registry
    {
        public DependencyRegistry()
        {
            var callingAssembly = Assembly.GetCallingAssembly();
            var assemblies =
                Assembly.GetCallingAssembly().GetReferencedAssemblies().Where(x => x.Name.StartsWith("FlickTrap"));

            Scan( x =>
            {
                x.Assembly(callingAssembly);
                assemblies.ToList().ForEach(assembly => x.Assembly(assembly.Name));
                x.AddAllTypesOf<IBootstrapperTask>();
                x.WithDefaultConventions();
            } );


            For<IControllerFactory>().Use<StructureMapControllerFactory>();
            For<IFlickInfoWebServiceFacade>().Use<TmdbApiFacade>();
            For<IAuthorizer>().Use<WebFormsAuthorizer>();
            
            const string tmdbApiKey = "20775617b505949e2d11b870e87cf1d6";
            For<TmdbAPI>().UseSpecial(x => x.ConstructedBy(() => new TmdbAPI(tmdbApiKey)));
            
        }
    }
}