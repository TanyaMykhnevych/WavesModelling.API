using System;
using System.ComponentModel.DataAnnotations;
using Waves.Services.Extensions.Base;

namespace Waves.Services.Models.Shared
{
    public class ItemPageSearchBaseModel
    {
        [Required]
        [Range(0, Int32.MaxValue)]
        public Int32 Page { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public Int32 PerPage { get; set; }

        public void ValidatePagination()
        {
            if (Page < 0 || PerPage < 0)
            {
                throw new InvalidPaginationParametersException();
            }
        }
    }
}
