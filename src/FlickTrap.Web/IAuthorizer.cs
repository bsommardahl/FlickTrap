using System;
using FlickTrap.Domain;

namespace FlickTrap.Web
{
    public interface IAuthorizer
    {
        void DoAuth(string username, bool remember);
        void DeAuth();
    }
}