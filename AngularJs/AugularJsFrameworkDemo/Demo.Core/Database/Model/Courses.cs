using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Demo.Core.Database.Model
{
    public class Courses
    {
        public ObjectId Id { get; set; }

        [BsonElement("courseName")]
        public string CourseName { get; set; }

        [BsonElement("courseCode")]
        public string CourseCode { get; set; }
    }
}
