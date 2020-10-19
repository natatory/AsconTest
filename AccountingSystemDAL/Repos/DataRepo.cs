using System;
using System.Data.Entity;
using AccountingSystemDAL.Model;
using System.Threading.Tasks;

namespace AccountingSystemDAL.Repos
{
    public class DataRepo : BaseRepo<Data>, IRepo<Data>
    {
        public DataRepo()
        {
            Table = Context.Transactions;
        }
        public int Delete(Guid id, byte[] timeStamp)
        {
            Context.Entry(new Data()
            {
                DataId = id,
                Timestamp = timeStamp
            }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(Guid id, byte[] timeStamp)
        {
            Context.Entry(new Data()
            {
                DataId = id,
                Timestamp = timeStamp
            }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }

    }
}
