using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Interfaces
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAllData();
        Task<T> GetByID(int? id);
        Task<IEnumerable<T>> GetManyByID(long id);
        Task<T> GetByPredicate(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetManyByPredicate(Expression<Func<T, bool>> predicate);

        void InsertData(T data);
        Task<bool> DeleteData(long dataID);
        void UpdateData(T data);
        void Save();
    }
}
