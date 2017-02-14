using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Config.WIndsor
{
    public interface IMongoSession
    {
        T SingleOrDefault<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : class, new();
        void Delete<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : class, new();
        void Delete<T>(T item) where T : class, new();
        IQueryable<T> All<T>() where T : class, new();
        void Add<T>(T item) where T : class, new();
        void Add<T>(IEnumerable<T> items) where T : class, new();
        void Update<T>(T item) where T : class, new();
    }

}
