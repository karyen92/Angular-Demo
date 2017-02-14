using System.Threading.Tasks;
using Demo.Core.Database.Model;
using Demo.Core.Domains.Model;
using Demo.Core.Models;
using Demo.Core.Validators;
using Demo.Framework.Extensions;
using Demo.Framework.Mediators;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Demo.Core.MediatorHandlers
{
    public class CreateMaterialElementHandler : IAsyncRequestHandler<CreateMaterialElementModel, CommonResultModel>
    {
        private readonly IMongoDatabase _db;

        public CreateMaterialElementHandler(IMongoDatabase db)
        {
            _db = db;
        }

        public async Task<CommonResultModel> Handle(CreateMaterialElementModel message)
        {
            var materials = _db.GetCollection<Material>(typeof(Material).CollectionName());
            var material = new Material
            {
                DropdownId = ObjectId.Parse(message.DropdownId),
                Date = message.Date
            };
            await materials.InsertOneAsync(material);

            return new CommonResultModel
            {
                Success = true,
                ValidationResult = null
            };
        }
    }
}
