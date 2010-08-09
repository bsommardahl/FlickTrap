using System;
using System.Collections.Generic;
using System.Linq;

namespace FlickTrap.Domain
{
    public class UserProfile
    {
        public IEnumerable<Flick> Trapped { get; set; }

        public string Username { get; set; }

        public void AddTrappedFlick(Flick flickToTrap)
        {
            if( Trapped == null )
                Trapped = new List<Flick>();

            var list = Trapped.ToList();
            list.Add(flickToTrap);
            Trapped = list;
        }

        public void RemoveTrappedFlick(Flick flickToRemove)
        {
            if( Trapped == null )
                return;

            var list = Trapped.ToList();
            list.Remove(flickToRemove);
            Trapped = list;            
        }
    }
}