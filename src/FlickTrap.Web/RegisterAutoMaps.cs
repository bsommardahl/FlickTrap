using System;
using AutoMapper;
using FlickTrap.Domain;
using FlickTrap.Web.Models;

namespace FlickTrap.Web
{
    public class RegisterAutoMaps : IBootstrapperTask
    {
        public void Execute()
        {
            Mapper.CreateMap<Flick, FlickListingViewModel>();
            Mapper.CreateMap<Flick, FlickDetailsViewModel>();
        }
    }
}