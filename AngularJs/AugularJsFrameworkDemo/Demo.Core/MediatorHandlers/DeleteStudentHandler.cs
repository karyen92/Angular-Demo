using System.Threading.Tasks;
using Demo.Core.Database.Model;
using Demo.Core.Models;
using Demo.Framework.Extensions;
using Demo.Framework.Mediators;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Demo.Core.MediatorHandlers
{
    public class DeleteStudentHandler : IAsyncRequestHandler<DeleteStudentModel, CommonResultModel>
    {
        private readonly IMongoDatabase _db;

        public DeleteStudentHandler(IMongoDatabase db)
        {
            _db = db;
        }

        public async Task<CommonResultModel> Handle(DeleteStudentModel message)
        {
            await _db.GetCollection<StudentIdentity>(typeof(StudentIdentity).CollectionName())
            .DeleteOneAsync(x => x.Id == ObjectId.Parse(message.Id));

            return new CommonResultModel
            {
                Success = true,
                ValidationResult = null
            };
        }
    }
}
