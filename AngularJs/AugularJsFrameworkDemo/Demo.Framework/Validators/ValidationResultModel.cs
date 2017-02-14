using System.Collections.Generic;

namespace Demo.Framework.Validators
{
    public class ValidationResultModel
    {
        public bool Success { get; set; }
        public IEnumerable<ValidationError> Errors { get; set; }
    }
}