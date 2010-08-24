using System;
using System.Web.Security;

namespace FlickTrap.Web
{
    class WebFormsAuthorizer : IAuthorizer
    {
        public void DoAuth(string username, bool remember)
        {
            FormsAuthentication.SetAuthCookie(username, remember);
        }

        public void DeAuth()
        {
            FormsAuthentication.SignOut();
        }
    }
}