using System;

namespace Waves.Services.Constants
{
    public static class ErrorMessagesConstants
    {
        public const String DELETE_SUPER_USER_ERROR = "Super User can not be deleted.";
        public const String MODIFY_SUPER_USER_ERROR = "Super User can not be modified.";
        public const String NOT_ALL_PASS_FIELDS_FILLED = "Not all password fields are filled.";
        public const String PASSWORDS_DO_NOT_MATCH = "New password and confirm password must be equal.";

        public const String EMAIL_ALREADY_TAKEN = "emailAlreadyTaken";
        public const String INVALID_PASSWORD = "invalidPassword";
    }
}
