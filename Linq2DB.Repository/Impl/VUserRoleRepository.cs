using IRepository.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using LinqToDB;
using System.Threading.Tasks;

namespace Linq2DB.Repository.Impl
{
    public class VUserRoleRepository : IRepository<VUserRole>
    {
        public async Task<bool> AddEntity(VUserRole t)
        {
            bool rs = false;
            using (DbElectricityNetworkDB db = new DbElectricityNetworkDB())
            {
                using (var transaction = await db.BeginTransactionAsync())
                {
                    rs = await db.InsertAsync(t) == 1;
                    await transaction.CommitAsync();
                }
            }
            return rs;
        }

        public Task<bool> AddList(IList<VUserRole> list)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEntity(Expression<Func<VUserRole, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<VUserRole> GetEntity(Expression<Func<VUserRole, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IList<VUserRole>> GetList(Expression<Func<VUserRole, bool>> predicate, int firstRow, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ModifyEntity(VUserRole t)
        {
            bool rs = false;
            
            return rs;
        }

    }
}
