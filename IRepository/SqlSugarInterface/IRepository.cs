using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IRepository.SqlSugarInterface
{
    public interface IRepository<T> where T : class, new()
    {
        Task<bool> AddEntity(T t);

        Task<bool> AddEntity(List<T> list);

        Task<bool> UpdateEntity(T t, Expression<Func<T, object>> updateColumns, Expression<Func<T, bool>> conditions);

        Task<bool> UpdateEntity(List<T> list, Expression<Func<T, object>> updateColumns, Expression<Func<T, bool>> conditions);

        Task<bool> UpdateEntityByIgnore(T t, Expression<Func<T, object>> ignoreColumns, Expression<Func<T, bool>> conditions);

        Task<bool> UpdateEntityByIgnore(List<T> list, Expression<Func<T, object>> ignoreColumns, Expression<Func<T, bool>> conditions);

        Task<bool> DeleteEntity(Expression<Func<T, bool>> expression);

        Task<List<T>> GetList(string sql, int firstRow, int pageSize, string orderStr);

        Task<List<T>> GetList(Expression<Func<T, bool>> expression, int firstRow, int pageSize, string orderStr);

        Task<T> GetEntity(Expression<Func<T, bool>> expression);

        Task<T> GetEntity(string sql);

        Task<int> CountEntity(Expression<Func<T, bool>> expression);
    }
}