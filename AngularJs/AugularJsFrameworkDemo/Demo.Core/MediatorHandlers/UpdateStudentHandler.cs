using System.Threading.Tasks;
using Demo.Core.Database.Model;
using Demo.Core.Models;
using Demo.Core.Validators;
using Demo.Framework.Extensions;
using Demo.Framework.Mediators;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Demo.Core.MediatorHandlers
{
    public class UpdateStudentHandler : IAsyncRequestHandler<UpdateStudentModel, CommonResultModel>
    {
        private readonly IMongoDatabase _db;
        private readonly UpdateStudentValidator _validator;

        public UpdateStudentHandler(IMongoDatabase db, UpdateStudentValidator validator)
        {
            _db = db;
            _validator = validator;
        }

        public async Task<CommonResultModel> Handle(UpdateStudentModel message)
        {
            var result = _validator.Validate(message);

            if (result.IsValid)
            {
                var students = _db.GetCollection<StudentIdentity>(typeof(StudentIdentity).CollectionName());

                var objectId = ObjectId.Parse(message.Id);

                var builder = Builders<StudentIdentity>.Filter.Eq(x => x.Id, objectId);
                var update = Builders<StudentIdentity>.Update
                    .Set(x => x.Name, message.Name)
                    .Set(x => x.StudentId, message.StudentId)
                    .Set(x => x.Class, message.RegisterClass);

                await students.UpdateOneAsync(builder, update);
            }

            return new CommonResultModel
            {
                Success = result.IsValid,
                ValidationResult = result
            };
        }
    }
}
