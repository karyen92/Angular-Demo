using System.Web;
using Demo.Framework.Mediators;

namespace Demo.Core.Models
{
    public class CompressFileModel : IAsyncRequest<FileResultModel>
    {
        public HttpPostedFile File { get; set; }
    }

    public class FileResultModel
    {
        public string Base64String { get; set; }
        public int OriHeight { get; set; }
        public int OriWidth { get; set; }
        public int NewHeight { get; set; }
        public int NewWidth { get; set; }
        public int OriSize { get; set; }
        public int NewSize { get; set; }
    }
}
