using System;
using Waves.Services.Exceptions.Base;

namespace Waves.Services.Exceptions.User
{
    public class EmailAlreadyTakenException : CustomBaseException
    {
        private const String MESSAGE = "Email was already taken.";

        public EmailAlreadyTakenException()
            : base(MESSAGE) { }

        public EmailAlreadyTakenException(String message)
            : base(message) { }
    }
}
