using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Domain.Repository
{
    public interface IBaseRepository<T> : IDisposable where T : class, IEntity
    {
        void Add(T entity);

        void Update(T entity);

        T SelectById(int id);

        void Delete(int id);

        List<T> SelectAll();
    }
}