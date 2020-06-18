using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCore.IRepository.Interface
{
    /// <summary>
    /// EFCore查询接口,通过泛型和依赖注入实现
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<TDbContext, T> where T : class, new() where TDbContext : DbContext
    {
        /// <summary>
        /// 批量新增(异步)
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> AddListAsync([NotNull] params T[] list);

        /// <summary>
        /// 获取单个实例(异步)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<T> GetEntityAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> selector = null);

        /// <summary>
        /// 获取多个实例(异步)
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="firstRow"></param>
        /// <param name="count"></param>
        /// <param name="sum">异步不支持ref,in,out</param>
        /// <param name="keyExpression">排序关键字</param>
        /// <param name="sequenceDirection">排序方向:ESC/DESC</param>
        /// <param name="selector">查询字段选择器</param>
        /// <returns></returns>
        Task<List<T>> GetListAsync<Key>(Expression<Func<T, bool>> predicate, int firstRow, int count, object sum,
           Expression<Func<T, Key>> keyExpression = null, string sequenceDirection = "ESC", Expression<Func<T, T>> selector = null);

        /// <summary>
        /// 批量删除(异步)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync([NotNull] params T[] list);

        /// <summary>
        /// sql执行增/删/改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        Task<int> ExecuteSqlAsync([NotNull] FormattableString sql, params object[] parameters);

        /// <summary>
        /// 修改(异步)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<bool> ModifyAsync([NotNull] params T[] list);

        /// <summary>
        /// sql执行查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<List<T>> QueryAsync([NotNull] string sql, params object[] parameters);
    }
}
