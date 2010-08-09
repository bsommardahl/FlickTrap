using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.SessionState;
using FlickTrap.Domain;
using FlickTrap.Domain.Abstract;

namespace FlickTrap.Data
{
    public static class FakeUserProfileRepositoryContext
    {
        static FakeUserProfileRepositoryContext()
        {
            UserProfiles = new List<UserProfile>
                                      {
                                          new UserProfile
                                              {
                                                  Username = "byron",
                                                  Trapped = new List<Flick>
                                                                {
                                                                    new Flick{ ImdbId = "121", Name = "Avatar" },
                                                                    new Flick{ ImdbId = "122", Name = "Hitch" },
                                                                    new Flick{ ImdbId = "123", Name = "Stargate" },
                                                                    new Flick{ ImdbId = "123", Name = "Star Wars: The Empire Strikes Back" },
                                                                    new Flick{ ImdbId = "124", Name = "Die Hard" },
                                                                    new Flick{ ImdbId = "125", Name = "Black Beauty" },
                                                                }
                                              },
                                        new UserProfile
                                            {
                                                Username = "john",

                                            },

                                      };
        }

        static List<UserProfile> _currentUserProfiles;
        public static List<UserProfile> UserProfiles
        {
            get
            {
                if(_currentUserProfiles==null)
                    _currentUserProfiles = new List<UserProfile>();

                return _currentUserProfiles;
            }
            set
            {
                _currentUserProfiles = value;
            }
        }
    }

    public class FakeUserProfileRepository : IUserProfileRepository
    {
        public UserProfile GetUserProfile(string username)
        {
            return FakeUserProfileRepositoryContext
                .UserProfiles
                .SingleOrDefault(x => x.Username == username);
        }

        public void Save(UserProfile userProfile)
        {
            var profiles = FakeUserProfileRepositoryContext.UserProfiles;
            
            var removeThis = profiles.SingleOrDefault(x => x.Username == userProfile.Username);
            if(removeThis!=null)
                profiles.Remove(removeThis);
            
            profiles.Add(userProfile);
        }
    }
}