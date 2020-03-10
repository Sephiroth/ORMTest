using IRepository.Interface;
using LinqToDB;
using Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Linq2DB.Repository.Impl
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        public async Task<bool> AddEntity(T t)
        {
            bool rs = false;
            using (DbElectricityNetworkDB db = new DbElectricityNetworkDB())
            {
                rs = await db.InsertAsync(t) == 1;
            }
            return rs;
        }

        public Task<bool> AddList(IList<T> list)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEntity(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetEntity(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> GetList(Expression<Func<T, bool>> predicate, int firstRow, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ModifyEntity(T t)
        {
            throw new NotImplementedException();
        }
    }
}