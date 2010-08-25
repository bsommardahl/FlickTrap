using System;
using AutoMapper;
using FlickTrap.Domain;

namespace FlickTrap.Web
{
    public class FlickStarsResolver : ValueResolver<Flick, string>
    {
        protected override string ResolveCore(Flick source)
        {
            var stars = Convert.ToInt32(Math.Round(source.UserRating/2));
            switch (stars)
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
            }
            return string.Empty;
        }
    }
}