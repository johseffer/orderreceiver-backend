using Microsoft.EntityFrameworkCore;
using OrderReceiver.Data.Context;
using OrderReceiver.Domain.Interfaces;
using System;
using System.Linq;

namespace OrderReceiver.Data.Repository
{
    public class ORRepository<TEntity> : IORRepository<TEntity> where TEntity : class
    {
        protected readonly ORContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public ORRepository(ORContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            try
            {
                DbSet.Add(obj);
                this.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual TEntity GetById(Guid id)
        {
            try
            {
                return DbSet.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            try
            {
                Db.Entry<TEntity>(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Remove(Guid id)
        {
            try
            {
                DbSet.Remove(DbSet.Find(id));
                this.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
