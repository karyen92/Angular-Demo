using Demo.Framework.Mediators;

namespace Demo.Core.Models
{
    public class CreateStudentModel : IAsyncRequest<CommonResultModel>
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string RegisterClass { get; set; }
    }
}
