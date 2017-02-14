using System.Collections.Generic;
using System.Linq;
using Demo.Framework.Validators;
using FluentValidation.Results;

namespace Demo.Framework.Extensions
{
    public static class ValidationResultExtension
    {
        public static ValidationResultModel ValidationResponse(this ValidationResult result)
        {
            var errors = new List<ValidationError>();
            foreach (var error in result.Errors)
            {
                if (errors.Any(x => x.PropertyName == error.PropertyName))
                {
                    var currentError = errors.Single(x => x.PropertyName == error.PropertyName);
                    var combinedMessage = currentError.ErrorMessage + ". " + error.ErrorMessage;
                    currentError.ErrorMessage = combinedMessage;
                }
                else
                {
                    errors.Add(new ValidationError
                    {
                        PropertyName = error.PropertyName,
                        ErrorMessage = error.ErrorMessage
                    });
                }
            }
            return new ValidationResultModel
            {
                Success = result.IsValid,
                Errors = errors
            };
        }
    }
}