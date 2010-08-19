using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.SessionState;
using FlickTrap.Domain;
using FlickTrap.Domain.Abstract;
using NHibernate;
using NHibernate.Linq;

namespace FlickTrap.Infrastructure
{
    public class UserProfileRepository : IUserProfileRepository
    {
        readonly ISession _session;

        public UserProfileRepository(ISession session)
        {
            _session = session;
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