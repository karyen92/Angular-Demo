using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Demo.Core.Database.Model
{
    public class StudentIdentity
    {
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("studentID")]
        public string StudentId { get; set; }

        [BsonElement("registerClass")]
        public string Class { get; set; }

        [BsonElement("enrollCourses")]
        public ICollection<Courses> Courses { get; set; }
    }
}