using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using FlickTrap.Data;
using FlickTrap.Domain;
using FlickTrap.Domain.Abstract;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.Interceptors;
using TheMovieDB;

namespace FlickTrap.Web
{
    public class DependencyRegistry : Registry
    {
        public DependencyRegistry()
        {
            string assemblyPrefix = GetThisAssembliesPrefix();

            Scan( x =>
            {
                x.TheCallingAssembly();
                x.AddAllTypesOf<IBootstrapperTask>();
                x.WithDefaultConventions();
            } );

            //Scan( x =>
            //{
            //    var enumerable = GetType().Assembly.GetReferencedAssemblies()
            //        .Where( name => name.Name.StartsWith( assemblyPrefix ) );
            //    enumerable.ToList().ForEach( name => x.Assembly( name.Name ) );
            //    x.WithDefaultConventions();
            //} );

            //Scan( x =>
            //{
            //    x.TheCallingAssembly();
            //    x.AddAllTypesOf<IController>()
            //        .NameBy( type => type.Name.Substring( 0, type.Name.Length - 10 ) );
            //    x.WithDefaultConventions();
            //} );

            Scan( x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                });

            //For<IControllerFactory>().Use<StructureMapControllerFactory>();
            //For<IFlickInfoWebServiceFacade>().Use<TmdbApiFacade>();
            
            const string tmdbApiKey = "20775617b505949e2d11b870e87cf1d6";
            //For<TmdbAPI>().UseSpecial(x => x.ConstructedBy(() => new TmdbAPI(tmdbApiKey)));

            //For<IFlickInfoService>().Use<FlickInfoService>();
            //For<IFlickRepository>().Use<FlickRepository>();
            //For<IUserProfileRepository>().Use<UserProfileRepository>();

        }

        string GetThisAssembliesPrefix()
        {
            string name = GetType().Assembly.GetName().Name;
            name = name.Substring( 0, name.LastIndexOf( "." ) );
            return name;
        }
    }
}