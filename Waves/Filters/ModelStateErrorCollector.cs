using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace Waves.WebAPI.Filters
{
    public static class ModelStateErrorCollector
    {
        public static String GetErrors(ModelStateDictionary modelState)
        {
            return String.Join("; ", modelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
        }
    }
}
