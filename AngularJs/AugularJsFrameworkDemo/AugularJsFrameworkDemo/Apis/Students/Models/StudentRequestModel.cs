using System.Collections.Generic;

namespace AugularJsFrameworkDemo.Apis.Students.Models
{
    public class StudentModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string StudentId { get; set; }
        public string Class { get; set; }
        public IEnumerable<string> Courses { get; set; }
    }

    public class StudentAddEditModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string StudentId { get; set; }
        public string Class { get; set; }
        public IEnumerable<SelectCourseModel> Courses { get; set; }
    }

    public class SelectCourseModel
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public bool IsTick { get; set; }
    }
}