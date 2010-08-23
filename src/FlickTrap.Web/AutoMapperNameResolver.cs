using AutoMapper;
using FlickTrap.Domain;

namespace FlickTrap.Web
{
    public class AutoMapperNameResolver : ValueResolver<UserProfile, string>
    {
        protected override string ResolveCore( UserProfile source )
        {
            return string.Format("{0} {1}", source.FirstName, source.LastName);
        }
    }
}