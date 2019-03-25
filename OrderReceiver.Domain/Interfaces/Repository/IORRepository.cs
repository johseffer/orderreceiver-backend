using OrderReceiver.Definitions.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderReceiver.Domain.Interfaces
{
    public interface IORRepository<TEntity> : IAutoInject, IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}
