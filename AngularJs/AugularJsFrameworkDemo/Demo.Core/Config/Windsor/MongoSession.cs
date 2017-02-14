using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Demo.Core.Config.WIndsor
{
    public class MongoSession : IMongoSession
    {
        private readonly IMongoDatabase _database;

        public MongoSession(IMongoDatabase database)
        {
            _database = database;
        }

        public T SingleOrDefault<T>(Expression<Func<T, bool>> expression) where T : class, new()
        {
            T item = null;
            
            return item;
        }

        public void Delete<T>(Expression<Func<T, bool>> expression) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T item) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public void DeleteAll<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> All<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }

        public void Add<T>(T item) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public void Add<T>(IEnumerable<T> items) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T item) where T : class, new()
        {
            throw new NotImplementedException();
        }
    }
}
