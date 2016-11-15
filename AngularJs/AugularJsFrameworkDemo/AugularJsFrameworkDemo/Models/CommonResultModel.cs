using System.Collections.Generic;

namespace AugularJsFrameworkDemo.Models
{
    public class CommonResultModel
    {
        public bool Success { get; set; }
        public IEnumerable<ValidationError> Errors { get; set; }
    }
}