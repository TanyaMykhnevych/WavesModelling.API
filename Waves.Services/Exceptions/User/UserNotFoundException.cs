using System;
using Waves.Services.Exceptions.Base;

namespace Waves.Services.Exceptions.User
{
    public class UserNotFoundException : CustomBaseException
    {
        private const String MESSAGE = "User was not found.";

        public UserNotFoundException()
            : base(MESSAGE) { }

        public UserNotFoundException(String message)
            : base(message) { }
    }
}
