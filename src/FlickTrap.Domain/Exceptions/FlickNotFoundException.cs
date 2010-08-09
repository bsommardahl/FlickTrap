using System;

namespace FlickTrap.Domain.Exceptions
{
    public class FlickNotFoundException : Exception
    {
        public override string Message
        {
            get
            {
                return "That flick was not found.";
            }
        }
    }
}