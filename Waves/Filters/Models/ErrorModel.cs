using System;

namespace Waves.WebAPI.Filters.Models
{
    public class ErrorModel
    {
        public String Error { get; set; }

        public ErrorModel(String error)
        {
            Error = error;
        }
    }
}
