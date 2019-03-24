using System;
using Waves.Services.Exceptions.Base;

namespace Waves.Services.Extensions.Base
{
    public class InvalidPaginationParametersException : CustomBaseException
    {
        private const String MESSAGE = "Pagination parameters are invalid. Page / PerPage parameters should be >= 0.";

        public InvalidPaginationParametersException()
            : base(MESSAGE) { }

        public InvalidPaginationParametersException(String message)
            : base(message) { }
    }
}
