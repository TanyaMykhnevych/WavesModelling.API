using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace Waves.WebAPI.Filters
{
    public class CustomValidateModelAttribute : ActionFilterAttribute
    {
        private readonly ILoggerFactory _loggerFactory;
        public CustomValidateModelAttribute(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ModelStateDictionary modelState = context.ModelState;
            ILogger logger = _loggerFactory.CreateLogger(context.ActionDescriptor.DisplayName);
            if (!modelState.IsValid)
            {
                logger.LogError($"Bad Request: {ModelStateErrorCollector.GetErrors(modelState)}");
                context.Result = new BadRequestObjectResult(modelState);
                return;
            }
            base.OnActionExecuting(context);
        }
    }
}
