using System;

namespace GMBAcademy.Web.Exceptions
{
    public class BadRequestException : Exception
    {
        public override string Message { get; }

        public BadRequestException(string message)
        {
            Message = message;
        }
    }
}
