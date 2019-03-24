using System;

namespace Waves.Services.Exceptions.Base
{
    public class CustomBaseException : Exception
    {

        private const String MESSAGE = "Bad request.";

        public CustomBaseException()
            : base(MESSAGE) { }

        public CustomBaseException(String message)
            : base(message) { }
    }
}
