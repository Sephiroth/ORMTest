using IRepository.SqlSugarInterface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SqlSugar.Repository.ImplBase
{
    public class SqlSugarRepository<T> : IRepository<T> where T : class, new()
    {
        public async Task<bool> AddEntity(T t)
        {
            bool rs = false;
            using (SqlSugarClient db = SqlClient.GetInstance())
            {
                rs = await db.Insertable(t).ExecuteCommandAsync() == 1;
            }
            return rs;
        }

        public async Task<bool> AddEntity(List<T> list)
        {
            bool rs = false;
            using (SqlSugarClient db = SqlClient.GetInstance())
            {
                try
                {
                    db.BeginTran();
                    rs = await db.Insertable(list).ExecuteCommandAsync() == list.Count;
                    if (rs)
                        db.CommitTran();
                    else
                        db.RollbackTran();
                }
                catch (Exception exp)
                {
                    db.RollbackTran();
                    throw exp;
                }
            }
            return rs;
        }

        public async Task<int> CountEntity(Expression<Func<T, bool>> expression)
        {
            int sum = 0;
            using (SqlSugarClient db = SqlClient.GetInstance())
            {
                sum = await db.Queryable<T>().Where(expression).CountAsync();
            }
            return sum;
        }

        public async Task<bool> DeleteEntity(Expression<Func<T, bool>> expression)
        {
            bool rs = false;
            using (SqlSugarClient db = SqlClient.GetInstance())
            {
                rs = await db.Deleteable(expression).ExecuteCommandAsync() == 1;
            }
            return rs;
        }

        public async Task<T> GetEntity(Expression<Func<T, bool>> expression)
        {
            T t = null;
            using (SqlSugarClient db = SqlClient.GetInstance())
            {
                t = await db.Queryable<T>().Where(expression).FirstAsync();
            }
            return t;
        }

        public async Task<T> GetEntity(string sql)
        {
            T t = null;
            using (SqlSugarClient db = SqlClient.GetInstance())
            {
                t = await db.SqlQueryable<T>(sql).FirstAsync();
            }
            return t;
        }

        public async Task<List<T>> GetList(string sql, int firstRow, int pageSize, string orderStr)
        {
            List<T> list = null;
            using (SqlSugarClient db = SqlClient.GetInstance())
            {
                list = await db.SqlQueryable<T>(sql).OrderBy(orderStr).ToPageListAsync(firstRow, pageSize);
            }
            return list;
        }

        public async Task<List<T>> GetList(Expression<Func<T, bool>> expression, int firstRow, int pageSize, string orderStr)
        {
            List<T> list = null;
            using (SqlSugarClient db = SqlClient.GetInstance())
            {
                list = await db.Queryable<T>().Where(expression).OrderBy(orderStr).ToPageListAsync(firstRow, pageSize);
            }
            return list;
        }

        public async Task<bool> UpdateEntity(T t, Expression<Func<T, object>> updateColumns, Expression<Func<T, bool>> conditions)
        {
            bool rs = false;
            using (SqlSugarClient db = SqlClient.GetInstance())
            {
                rs = await db.Updateable(t).UpdateColumns(updateColumns).Where(conditions).ExecuteCommandAsync() == 1;
            }
            return rs;
        }

        public async Task<bool> UpdateEntity(List<T> list, Expression<Func<T, object>> updateColumns, Expression<Func<T, bool>> conditions)
        {
            bool rs = false;
            using (SqlSugarClient db = SqlClient.GetInstance())
            {
                rs = await db.Updateable(list).UpdateColumns(updateColumns).Where(conditions).ExecuteCommandAsync() == list.Count;
            }
            return rs;
        }

        public async Task<bool> UpdateEntityByIgnore(T t, Expression<Func<T, object>> ignoreColumns, Expression<Func<T, bool>> conditions)
        {
            bool rs = false;
            using (SqlSugarClient db = SqlClient.GetInstance())
            {
                rs = await db.Updateable(t).IgnoreColumns(ignoreColumns).Where(conditions).ExecuteCommandAsync() == 1;
            }
            return rs;
        }

        public async Task<bool> UpdateEntityByIgnore(List<T> list, Expression<Func<T, object>> ignoreColumns, Expression<Func<T, bool>> conditions)
        {
            bool rs = false;
            using (SqlSugarClient db = SqlClient.GetInstance())
            {
                rs = await db.Updateable(list).IgnoreColumns(ignoreColumns).Where(conditions).ExecuteCommandAsync() == list.Count;
            }
            return rs;
        }
    }
}