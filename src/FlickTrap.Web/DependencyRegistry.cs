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
            Scan( x =>
            {
                x.TheCallingAssembly();
                x.AddAllTypesOf<IBootstrapperTask>();
                x.WithDefaultConventions();
            } );

            Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.IncludeNamespace("FlickTrap.Domain");
                    x.WithDefaultConventions();
                });

            For<IControllerFactory>().Use<StructureMapControllerFactory>();
            For<IFlickInfoService>().Use<FlickInfoService>();
            For<IFlickInfoWebServiceFacade>().Use<TmdbApiFacade>();
            For<IFlickRepository>().Use<FlickRepository>();
            For<IUserProfileRepository>().Use<UserProfileRepository>();

            const string tmdbApiKey = "20775617b505949e2d11b870e87cf1d6";
            For<TmdbAPI>().UseSpecial(x => x.ConstructedBy(() => new TmdbAPI(tmdbApiKey)));
            
        }
    }
}