using System;
using System.Collections.Generic;

namespace FlickTrap.Domain
{
    public class UserProfile
    {
        public string Name { get; set; }

        public IEnumerable<Flick> Trapped { get; set; }
    }
}