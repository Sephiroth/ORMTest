using IRepository.Interface;
using LinqToDB;
using Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Linq2DB.Repository.Impl
{
    public class UserRepository : IRepository<TUserinfo>
    {
        public async Task<bool> AddEntity(TUserinfo t)
        {
            bool rs = false;
            using (DbElectricityNetworkDB db = new DbElectricityNetworkDB())
            {
                rs = await db.InsertAsync(t) == 1;
            }
            return rs;
        }

        public async Task<bool> AddList(IList<TUserinfo> list)
        {
            bool rs = false;
            using (DbElectricityNetworkDB db = new DbElectricityNetworkDB())
            {
                rs = await db.InsertAsync(list) == list.Count;
            }
            return rs;
        }

        public async Task<bool> DeleteEntity(Expression<Func<TUserinfo, bool>> predicate)
        {
            bool rs = false;
            using (DbElectricityNetworkDB db = new DbElectricityNetworkDB())
            {
                rs = await db.TUserinfoes.DeleteAsync(predicate) > 0;
            }
            return rs;
        }

        public async Task<TUserinfo> GetEntity(Expression<Func<TUserinfo, bool>> predicate)
        {
            TUserinfo obj = null;
            using (DbElectricityNetworkDB db = new DbElectricityNetworkDB())
            {
                obj = await db.TUserinfoes.FirstOrDefaultAsync(predicate);
            }
            return obj;
        }

        public async Task<IList<TUserinfo>> GetList(Expression<Func<TUserinfo, bool>> predicate, int firstRow, int pageSize)
        {
            IList<TUserinfo> list = null;
            using (DbElectricityNetworkDB db = new DbElectricityNetworkDB())
            {
                list = await db.TUserinfoes.CreateQuery<TUserinfo>(predicate).ToListAsync();
            }
            return list;
        }

        public async Task<bool> ModifyEntity(TUserinfo t)
        {
            bool rs = false;
            using (DbElectricityNetworkDB db = new DbElectricityNetworkDB())
            {
                rs = await db.UpdateAsync(t) == 1;
            }
            return rs;
        }
    }
}