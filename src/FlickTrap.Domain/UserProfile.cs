using System;
using System.Collections.Generic;
using System.Linq;

namespace FlickTrap.Domain
{
    public class UserProfile : EntityBase
    {
        public virtual string Username { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual IEnumerable<Flick> Trapped { get; set; }
        public virtual string Password { get; set; }

        public virtual void AddTrappedFlick(Flick flickToTrap)
        {
            if (Trapped == null)
                Trapped = new List<Flick>();

            List<Flick> list = Trapped.ToList();
            list.Add(flickToTrap);
            Trapped = list;
        }

        public virtual void RemoveTrappedFlick(Flick flickToRemove)
        {
            if (Trapped == null)
                return;

            List<Flick> list = Trapped.ToList();
            list.Remove(flickToRemove);
            Trapped = list;
        }
    }
}