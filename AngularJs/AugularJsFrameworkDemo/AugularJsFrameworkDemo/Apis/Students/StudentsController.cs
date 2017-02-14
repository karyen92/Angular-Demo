using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        private readonly IMongoDatabase _db;
        private readonly IMediator _mediator;

        public StudentsController(IMongoDatabase db,
            IMediator mediator)
        {
            _db = db;
            _mediator = mediator;
        }

        //public HttpResponseMessage Get([ApiQuery] StudentsRequestModel m)
        //{
        //    return Request.CreateResponse(HttpStatusCode.OK, new { data = "" });
        //}
        public HttpResponseMessage Get()
        {
            var collectionName = typeof(StudentIdentity).CollectionName();
            var students = _db.GetCollection<StudentIdentity>(collectionName).AsQueryable();

            var data = students.Select(x => new StudentModel
            {
                Id = x.Id,
                Name = x.Name,
                StudentId = x.StudentId,
                Class = x.Class,
                Courses = x.Courses.Select(y => y.CourseName + "-" + y.CourseCode)
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

        //update
        public async Task<HttpResponseMessage> Put([FromBody]UpdateStudentModel data)
        {
            var output = await _mediator.SendAsync(data);
            var response = output.ValidationResult.ValidationResponse();
            
            return Request.CreateResponse(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest, response);
        }

        //create
        public async Task<HttpResponseMessage> Post([FromBody]CreateStudentModel data)
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
