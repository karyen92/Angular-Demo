using System.Collections.Generic;
using Demo.Framework.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Demo.Core.Database.Model
{
    [CollectionName(Name = "students")]
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