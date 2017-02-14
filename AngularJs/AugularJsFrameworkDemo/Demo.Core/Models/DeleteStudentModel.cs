using Demo.Framework.Mediators;

namespace Demo.Core.Models
{
    public class DeleteStudentModel : IAsyncRequest<CommonResultModel>
    {
        public string Id { get; set; }
    }
}
