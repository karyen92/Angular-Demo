using FluentValidation.Results;

namespace Demo.Core.Models
{
    public class CommonResultModel
    {
        public bool Success { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
