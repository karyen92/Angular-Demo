using System.Threading.Tasks;
using Demo.Core.Database.Model;
using Demo.Core.Dtos;
using Demo.Core.Validators;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Demo.Core.Command
{
    public class CreateStudentCommand
    {
        private readonly IMongoDatabase _db;

        public CreateStudentCommand(IMongoDatabase db)
        {
            _db = db;
        }

        public async Task<CommonResultDto> Create(SaveStudentDto dto)
        {
            var studentCol = _db.GetCollection<StudentIdentity>("students");

            var searchCollection = _db.GetCollection<StudentIdentity>("students");

            var query = (from e in searchCollection.AsQueryable()
                where e.StudentId == dto.StudentId
                select e)
                .Any();

            if (!query)
            {
                var student = new StudentIdentity
                {
                    StudentId = dto.StudentId,
                    Name = dto.Name,
                    Class = dto.RegisterClass
                };
                await studentCol.InsertOneAsync(student);
                return new CommonResultDto
                {
                    Success = true
                };
            }

            var validationResults = new ValidationResults();
            validationResults.AddError("studentId", "This Student ID has been taken.");
            return new CommonResultDto
            {
                Success = false,
                ValidationResults = validationResults
            };
        }

        //public async void Delete(string id)
        //{
        //    var filter = Builders<BsonDocument>.Filter.Eq("id", id);
        //    await _students.DeleteOneAsync(filter);
        //}
    }
}
