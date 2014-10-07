using System;

namespace BusinessLogic.Exceptions
{
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException(string ex) : base(ex)
        {
        }
    }
}