using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AugularJsFrameworkDemo.Apis.Students.Models;
using Demo.Core.Database.Model;
using Demo.Core.Domains.Model;
using Demo.Core.Models;
using Demo.Framework.Extensions;
using Demo.Framework.Mediators;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AugularJsFrameworkDemo.Apis.Material
{
    [RoutePrefix("api/material")]
    public class MaterialController : ApiController
    {
        private readonly IMongoDatabase _db;
        private readonly IMediator _mediator;

        public MaterialController(IMongoDatabase db,
            IMediator mediator)
        {
            _db = db;
            _mediator = mediator;
        }

        public HttpResponseMessage Get()
        {
            var collectionName = typeof(Demo.Core.Domains.Model.Material).CollectionName();
            var materials = _db.GetCollection<Demo.Core.Domains.Model.Material>(collectionName).AsQueryable();

            var data = materials.Select(x => new
            {
                x.Date
            }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, new { collection = data });
        }

        public HttpResponseMessage Get(string id)
        {
            var courses = _db.GetCollection<Courses>(typeof(Courses).CollectionName()).AsQueryable();
            StudentAddEditModel model;
            if (id == "0")
            {
                model = new StudentAddEditModel
                {
                    Courses = courses.Select(x => new SelectCourseModel
                    {
                        CourseCode = x.CourseCode,
                        CourseName = x.CourseName
                    }).ToList()
                };
                return Request.CreateResponse(HttpStatusCode.OK, new { model });
            }

            var student =
                _db.GetCollection<StudentIdentity>(
                    typeof(StudentIdentity).CollectionName())
                    .FindAsync(x => x.Id == new ObjectId(id))
                    .Result.SingleOrDefault();

            model = new StudentAddEditModel
            {
                Courses = courses.Select(x => new SelectCourseModel
                {
                    CourseCode = x.CourseCode,
                    CourseName = x.CourseName
                }).ToList(),
                Id = student.Id,
                Name = student.Name,
                StudentId = student.StudentId,
                Class = student.Class
            };
            return Request.CreateResponse(HttpStatusCode.OK, new { model });
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody]CreateMaterialElementModel data)
        {
            var output = await _mediator.SendAsync(data);
            return Request.CreateResponse(output.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("dropdown")]
        public async Task<HttpResponseMessage> Dropdown()
        {
            var collectionName = typeof(Dropdown).CollectionName();
            var dropdowns = _db.GetCollection<Dropdown>(collectionName).AsQueryable();

            var data = dropdowns.Select(x => new
            {
                x.Id,
                x.Name
            }
            ).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, new { collection = data });
        }

        //update
        public async Task<HttpResponseMessage> Put([FromBody]UpdateStudentModel data)
        {
            var output = await _mediator.SendAsync(data);
            var response = output.ValidationResult.ValidationResponse();

            return Request.CreateResponse(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest, response);
        }

        public async Task<HttpResponseMessage> Delete(string id)
        {
            var data = new DeleteStudentModel
            {
                Id = id
            };
            var output = await _mediator.SendAsync(data);
            var response = output.ValidationResult.ValidationResponse();
            return Request.CreateResponse(HttpStatusCode.OK, new { data = true });
        }
    }
}
