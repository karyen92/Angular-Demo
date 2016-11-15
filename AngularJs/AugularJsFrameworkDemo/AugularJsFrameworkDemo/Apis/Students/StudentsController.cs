using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AugularJsFrameworkDemo.Apis.Students.Models;
using AugularJsFrameworkDemo.Models;
using Demo.Core.Command;
using Demo.Core.Database.Model;
using Demo.Core.Dtos;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace AugularJsFrameworkDemo.Apis.Students
{
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        private readonly IMongoDatabase _db;
        public StudentsController(IMongoDatabase db)
        {
            _db = db;
        }
        //public HttpResponseMessage Get([ApiQuery] StudentsRequestModel m)
        //{
        //    return Request.CreateResponse(HttpStatusCode.OK, new { data = "" });
        //}

        public HttpResponseMessage Get()
        {
            var students = _db.GetCollection<StudentIdentity>("students").AsQueryable();

            var data = students.Select(x => new StudentModel
            {
                Name = x.Name,
                StudentId = x.StudentId,
                Class = x.Class,
                Courses = x.Courses.Select(y => y.CourseName + "-" + y.CourseCode)
            }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, new { data});
        }

        public HttpResponseMessage Get(string id)
        {
            if (id == "0")
            {
                var courses = _db.GetCollection<Courses>("courses").AsQueryable();
                var model = new StudentAddEditModel
                {
                    Courses = courses.Select(x => new SelectCourseModel
                    {
                        CourseCode = x.CourseCode,
                        CourseName = x.CourseName
                    }).ToList()
                };
                return Request.CreateResponse(HttpStatusCode.OK, new { model });
            }

            return Request.CreateResponse(HttpStatusCode.OK, new {  });
        }

        public HttpResponseMessage Post([FromBody]SaveStudentDto data)
        {
            var command = new CreateStudentCommand(_db);
            var output = command.Create(data);
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                data = new CommonResultModel
                {
                    Success = output.Result.Success,
                    Errors = output.Result.ValidationResults.Errors().Select(x => new ValidationError
                    {
                        PropertyName = x.Key,
                        ErrorMessage = x.Value
                    })
                }
            });
        }

        //[HttpPost]
        //[Route("Post")]
        //public HttpResponseMessage Post([FromBody]SaveStudentDto data)
        //{
        //    try
        //    {
        //        CreateStudentCommand command = new CreateStudentCommand(_db);
        //        command.Create(data);
        //    }
        //    catch(BsonException)
        //    {
                
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, new { data = true });
        //}
    }
}
