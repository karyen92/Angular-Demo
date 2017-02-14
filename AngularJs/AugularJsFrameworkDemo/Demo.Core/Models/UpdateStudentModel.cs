using Demo.Framework.Mediators;

namespace Demo.Core.Models
{
    public class UpdateStudentModel : IAsyncRequest<CommonResultModel>
    {
        public string Id { get; set; }
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string RegisterClass { get; set; }
    }
}
