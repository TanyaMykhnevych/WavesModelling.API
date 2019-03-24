using System;
using Waves.Services.Exceptions.Base;

namespace Waves.Services.Exceptions.User
{
    public class InvalidUserPasswordException : CustomBaseException
    {
        private const String MESSAGE = "Invalid user password.";

        public InvalidUserPasswordException()
            : base(MESSAGE) { }

        public InvalidUserPasswordException(String message)
            : base(message) { }
    }
}
