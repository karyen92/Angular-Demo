using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AugularJsFrameworkDemo.Apis.Students.Models;
namespace AugularJsFrameworkDemo.Apis.Students
{
    [RoutePrefix("api/normalForm")]
    public class NormalFormController : ApiController
    {

        public HttpResponseMessage Get()
        {
            var model = new NormalFormModel();
            return Request.CreateResponse(HttpStatusCode.OK, new { model });
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] NormalFormModel model)
        {
            var errors = new List<Error>
            {
                new Error
                {
                    PropertyName = "UserName",
                    ErrorMessage = "This User Name is taken"
                }
            };
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors });
        }
    }
}
