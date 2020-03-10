using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IRepository.Interface
{
    public interface IRepository<T> where T : class, new()
    {
        Task<T> GetEntity(Expression<Func<T, bool>> predicate);

        Task<IList<T>> GetList(Expression<Func<T, bool>> predicate, int firstRow, int pageSize);

        Task<bool> AddEntity(T t);

        Task<bool> AddList(IList<T> list);

        Task<bool> DeleteEntity(Expression<Func<T, bool>> predicate);

        Task<bool> ModifyEntity(T t);
    }
}