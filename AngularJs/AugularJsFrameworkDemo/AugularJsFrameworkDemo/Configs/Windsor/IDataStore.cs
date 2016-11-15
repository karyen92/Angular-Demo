using MongoDB.Driver;

namespace AugularJsFrameworkDemo.Configs.Windsor
{
    public interface IDataStore
    {
        IMongoDatabase DataBase { get; }
    }
}