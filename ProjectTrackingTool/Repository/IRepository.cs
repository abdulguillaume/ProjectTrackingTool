using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectTrackingTool.Repository
{
    public interface IRepository<E>: IDisposable
    {
        E Get(int id);
        IEnumerable<E> GetAll();

        void Add(E e);
        void AddRange(IEnumerable<E> e);
        E Remove(E e);
        void RemoveRange(IEnumerable<E> e);

        IEnumerable<E> Find(Expression<Func<E, bool>> predicate);
    }
}