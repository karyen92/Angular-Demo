using Demo.Core.Validators;

namespace Demo.Core.Dtos
{
    public class CommonResultDto
    {
        public bool Success { get; set; }
        public ValidationResults ValidationResults { get; set; }
    }
}
