using System;
using System.Collections.Generic;

namespace FlickTrap.Domain
{
    public class DefaultFlickInfoService : IFlickInfoService
    {
        public IEnumerable<Flick> GetRecentlyReleasedFlicks()
        {
            return new List<Flick>
                       {
                            new Flick { Name = "Hitch", Rating = "PG-13", TheaterReleaseDate = new DateTime(2010, 1, 1) },
                            new Flick { Name = "Immortal", Rating = "PG-13", TheaterReleaseDate = new DateTime(2010, 1, 1) },
                            new Flick { Name = "Airbender", Rating = "PG", TheaterReleaseDate = new DateTime(2010, 1, 1) },
                            new Flick { Name = "Avatar", Rating = "PG-13", TheaterReleaseDate = new DateTime(2010, 1, 1) },
                            new Flick { Name = "Handy", Rating = "PG", TheaterReleaseDate = new DateTime(2010, 1, 1) },
                            new Flick { Name = "The Horse", Rating = "G", TheaterReleaseDate = new DateTime(2010, 1, 1) },
                            new Flick { Name = "Revenge of the Nerds VIII", Rating = "PG-13", TheaterReleaseDate = new DateTime(2010, 1, 1) },
                            new Flick { Name = "Alien vs Predator", Rating = "R", TheaterReleaseDate = new DateTime(2010, 1, 1) },
                            new Flick { Name = "Love Hurts", Rating = "PG", TheaterReleaseDate = new DateTime(2010, 1, 1) },
                       };
        }

        public IEnumerable<Flick> GetUnreleasedFlicks()
        {
            return new List<Flick>
                       {
                            new Flick { Name = "Avatar II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1) },
                            new Flick { Name = "My Movie II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1) },
                            new Flick { Name = "Love Hurts II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1) },
                            new Flick { Name = "Karate Kid VII", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1) },
                            new Flick { Name = "Star Wars X", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1) },
                            new Flick { Name = "Hitch II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1) },
                            new Flick { Name = "Hannibal II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1) },
                            new Flick { Name = "Epic Movie", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1) },
                       };
        }
    }
}