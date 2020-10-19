using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountingSystemDAL.Repos
{
    public interface IRepo<T>
    {
        int Add(T entity);
        Task<int> AddAsync(T entity);
        int AddRange(IList<T> entities);
        Task<int> AddRangeAsync(IList<T> entities);
        int Save(T entity);
        Task<int> SaveAsync(T entity);
        int Delete(Guid id, byte[] timeStamp);
        Task<int> DeleteAsync(Guid id, byte[] timeStamp);
        int Delete(T entity);
        Task<int> DeleteAsync(T entity);
        T GetOne(Guid id);
        Task<T> GetOneAsync(Guid id);
        IList<T> GetAll();
        Task<List<T>> GetAllAsync();

    }
}
