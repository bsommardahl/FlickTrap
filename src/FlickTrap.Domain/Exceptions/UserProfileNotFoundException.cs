using System;

namespace FlickTrap.Domain.Exceptions
{
    public class UserProfileNotFoundException : Exception
    {
        public override string Message
        {
            get
            {
                return "That user profile was not found.";
            }
        }
    }
}