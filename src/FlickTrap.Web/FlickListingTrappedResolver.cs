using AutoMapper;
using FlickTrap.Domain;

namespace FlickTrap.Web
{
    public class FlickListingTrappedResolver : ValueResolver<Flick, bool>
    {
        protected override bool ResolveCore(Flick source)
        {
            return source.Id > 0;
        }
    }
}