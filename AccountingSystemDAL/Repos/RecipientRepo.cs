using System;
using System.Data.Entity;
using AccountingSystemDAL.Model;
using System.Threading.Tasks;

namespace AccountingSystemDAL.Repos
{
    public class RecipientRepo : BaseRepo<Recipient>, IRepo<Recipient>
    {
        public RecipientRepo()
        {
            Table = Context.Recipients;
        }
        public int Delete(Guid id, byte[] timeStamp)
        {
            Context.Entry(new Recipient()
            {
                RecipientId = id,
                Timestamp = timeStamp
            }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(Guid id, byte[] timeStamp)
        {
            Context.Entry(new Recipient()
            {
                RecipientId = id,
                Timestamp = timeStamp
            }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }

    }
}
