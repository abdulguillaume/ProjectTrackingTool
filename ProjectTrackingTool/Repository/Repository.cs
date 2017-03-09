using ProjectTrackingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingTool.Repository
{
    public class Repository<E>: IDisposable, IRepository<E> where E : class
    {
        protected readonly ProjectContext context;

        public Repository(ProjectContext context)
        {
            this.context = context;
        }
        public E Get(int id)
        {
            return context.Set<E>().Find(id);
            //throw new NotImplementedException();
        }

        public IEnumerable<E> GetAll()
        {
            return context.Set<E>().ToList();
            //throw new NotImplementedException();
        }

        public void Add(E e)
        {
            context.Set<E>().Add(e);
            //throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<E> e)
        {
            context.Set<E>().AddRange(e);
            //throw new NotImplementedException();
        }

        public E Remove(E e)
        {
            return context.Set<E>().Remove(e);
            //throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<E> e)
        {
            context.Set<E>().RemoveRange(e);
            //throw new NotImplementedException();
        }

        public IEnumerable<E> Find(System.Linq.Expressions.Expression<Func<E, bool>> predicate)
        {
            return context.Set<E>().Where(predicate);
            //throw new NotImplementedException();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing) context.Dispose();
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            //garbage collector
            GC.SuppressFinalize(this);
            //throw new NotImplementedException();
        }
    }
}