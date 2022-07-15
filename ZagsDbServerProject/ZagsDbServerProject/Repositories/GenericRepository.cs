using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZagsDbServerProject.Interfaces;

namespace ZagsDbServerProject.Repositories
{
    public class GenericRepository<TGeneric> : IGenericRepository<TGeneric> where TGeneric : class
    {
        public readonly AppDbContext context;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
        }

        public virtual async Task<IEnumerable<TGeneric>> GetAllData()
        {
            return await Task.FromResult(context.Set<TGeneric>().ToList());
        }

        public virtual async Task<TGeneric> GetByID(int? id)
        {
            return await Task.FromResult(context.Set<TGeneric>().Find(id));
        }

        public virtual async Task<IEnumerable<TGeneric>> GetManyByID(long id)
        {
            return (IEnumerable<TGeneric>) await Task.FromResult( context.Set<TGeneric>().Find(id)); ;
        }

        public virtual async Task<TGeneric> GetByPredicate(Expression<Func<TGeneric, bool>> predicate)
        {
               var st =  Task.FromResult(context.Set<TGeneric>().FirstOrDefault(predicate));
            return await st;
        }

        public virtual async Task<IEnumerable<TGeneric>> GetManyByPredicate(Expression<Func<TGeneric, bool>> predicate)
        {
            return await Task.FromResult(context.Set<TGeneric>().Where(predicate)); ;
        }

        public virtual async void InsertData(TGeneric data)
        {
            await Task.FromResult(context.Set<TGeneric>().Add(data));
        }


        public virtual async void UpdateData(TGeneric data)
        {
            await Task.FromResult(context.Entry(data).State = EntityState.Modified);
        }


        public virtual async Task<bool> DeleteData(long dataID)
        {
            try
            {
                await Task.FromResult(context.Set<TGeneric>().Remove(await GetByID((int)dataID)));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
