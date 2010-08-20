using System;
using System.Linq;
using FlickTrap.Domain;
using FlickTrap.Domain.Abstract;
using NHibernate;
using NHibernate.Linq;

namespace FlickTrap.Data
{
    public class UserProfileRepository : IUserProfileRepository
    {
        readonly ISession _session;

        public UserProfileRepository(ISession session)
        {
            _session = session;
        }

        public UserProfile GetUserProfile(int userProfileId)
        {
            return _session.Get<UserProfile>(userProfileId);
        }

        public UserProfile GetUserProfile(string username)
        {
            return _session.Linq<UserProfile>().SingleOrDefault( x => x.Username == username );
        }

        public UserProfile Save(UserProfile userProfile)
        {
            using(var transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(userProfile);
                transaction.Commit();
            }

            return userProfile;
        }
    }
}