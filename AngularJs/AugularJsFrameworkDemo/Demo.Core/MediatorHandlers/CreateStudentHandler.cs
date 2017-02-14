using System.Threading.Tasks;
using Demo.Core.Database.Model;
using Demo.Core.Models;
using Demo.Core.Validators;
using Demo.Framework.Extensions;
using Demo.Framework.Mediators;
using MongoDB.Driver;

namespace Demo.Core.MediatorHandlers
{
    public class CreateStudentHandler : IAsyncRequestHandler<CreateStudentModel, CommonResultModel>
    {
        private readonly IMongoDatabase _db;
        private readonly CreateStudentValidator _validator;

        public CreateStudentHandler(IMongoDatabase db, CreateStudentValidator validator)
        {
            _db = db;
            _validator = validator;
        }

        public async Task<CommonResultModel> Handle(CreateStudentModel message)
        {
            var result = _validator.Validate(message);

            if (result.IsValid)
            {
                var students = _db.GetCollection<StudentIdentity>(typeof(StudentIdentity).CollectionName());
                var student = new StudentIdentity
                {
                    StudentId = message.StudentId,
                    Name = message.Name,
                    Class = message.RegisterClass
                };
                await students.InsertOneAsync(student);
            }

            return new CommonResultModel
            {
                Success = result.IsValid,
                ValidationResult = result
            };
        }
    }
}
