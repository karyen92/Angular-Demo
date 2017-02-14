using MongoDB.Driver;

namespace Demo.Core.Config.WIndsor
{
    public interface IDataStore
    {
        IMongoDatabase DataBase { get; }
    }
}