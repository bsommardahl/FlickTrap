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

            Mapper.CreateMap<UserProfileCreateRequest, UserProfile>()
                .ForMember(x => x.Id, opts => opts.Ignore())
                .ForMember(x => x.Trapped, opts => opts.Ignore())
                .ForMember(x=>x.Password, opts => opts.MapFrom(x=>x.Password1))
                .WithProfile("UserProfileCreateRequest_to_UserProfile");

            Mapper.CreateMap<UserProfileUpdateRequest, UserProfile>()
                .ForMember( x => x.Trapped, opts => opts.Ignore() )
                .ForMember( x => x.Password, opts => opts.MapFrom( x => x.Password1 ) )
                .WithProfile( "UserProfileUpdateRequest_to_UserProfile" );

            Mapper.CreateMap<UserProfile, UserProfileViewModel>()
                .ForMember(x => x.Name, opts => opts.ResolveUsing<AutoMapperNameResolver>())
                .WithProfile("UserProfile_to_UserProfileViewModel");
            
        }
    }
}