using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AugularJsFrameworkDemo.Apis.Students.Models;
using Demo.Core.Database.Model;
using Demo.Core.Models;
using Demo.Framework.Extensions;
using Demo.Framework.Mediators;
using MongoDB.Driver;
using MongoDB.Bson;

namespace AugularJsFrameworkDemo.Apis.Students
{
    [RoutePrefix("api/files")]
    public class FilesController : ApiController
    {
        private readonly IMongoDatabase _db;
        private readonly IMediator _mediator;

        public FilesController(IMongoDatabase db,
            IMediator mediator)
        {
            _db = db;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }


            HttpPostedFile file = HttpContext.Current.Request.Files.Count > 0 ?
                HttpContext.Current.Request.Files[0] : null;
            if (file != null)
            {
                var model = new CompressFileModel
                {
                    File = file
                };
                var output = await _mediator.SendAsync(model);

                return Request.CreateResponse(HttpStatusCode.OK, new { result = output });
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }


    }
}
