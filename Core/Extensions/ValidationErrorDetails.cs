using FluentValidation.Results;
using System.Collections.Generic;

namespace Core.Extensions
{
    internal class ValidationErrorDetails : ErrorDetails
    {
       
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}