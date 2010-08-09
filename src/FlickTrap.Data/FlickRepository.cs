using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlickTrap.Domain;

namespace FlickTrap.Data
{
    public class FlickRepository : IFlickRepository
    {
        public IEnumerable<Flick> GetRecentlyReleased()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flick> GetUnreleasedFlicks()
        {
            throw new NotImplementedException();
        }
    }
}
