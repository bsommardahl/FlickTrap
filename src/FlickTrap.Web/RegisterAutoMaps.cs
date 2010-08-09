using AutoMapper;
using FlickTrap.Domain;
using FlickTrap.Web.Models;

namespace FlickTrap.Web
{
    public class RegisterAutoMaps : IBootstrapperTask
    {
        public void Execute()
        {
            Mapper.CreateMap(typeof (Flick), typeof (FlickListingViewModel));
            Mapper.CreateMap(typeof (Flick), typeof (FlickDetailsViewModel));
        }
    }
}