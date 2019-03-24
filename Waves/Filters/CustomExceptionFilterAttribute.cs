using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Waves.Services.Exceptions.Base;
using Waves.WebAPI.Filters.Models;

namespace Waves.WebAPI.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILoggerFactory _loggerFactory;
        public CustomExceptionFilterAttribute(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public override void OnException(ExceptionContext context)
        {
            ILogger logger = _loggerFactory.CreateLogger(context.ActionDescriptor.DisplayName);
            logger.LogError(context.Exception, "Action Error");

            ObjectResult result;
            if (context.Exception is CustomBaseException)
            {
                result = new ObjectResult(new ErrorModel(context.Exception.Message))
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            else
            {
                result = new ObjectResult(null)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }

            context.Result = result;
        }
    }
}
