using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Core.DataAccess
{
    public class EfEntityRepostoryBase<TEntity, TContext> : IEfEntityRepositoryBase<TEntity> where TEntity : class,IEntity , new()
        where TContext : DbContext,new()
    {
        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var result = context.Entry(entity);
                result.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public bool Any(Expression<Func<TEntity, bool>> filter)
        {
            // any bir tablo üzerinde sorgu yapar sonucunda değer dönüyorsa true dönmüyorsa false döndürür.
            using (var context = new TContext())
            {
               return context.Set<TEntity>().Any(filter);   

            }
        }

        public bool Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var result = context.Entry(entity);
                result.State = EntityState.Deleted;
                return context.SaveChanges() > 0 ;
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                if (filter == null)
                {
                    return context.Set<TEntity>().ToList();
                }
                else
                {
                   return context.Set<TEntity>().Where(filter).ToList();
                }
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var result = context.Entry(entity);
                result.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
		}
    }
}
