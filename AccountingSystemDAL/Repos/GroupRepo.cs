using System;
using System.Data.Entity;
using AccountingSystemDAL.Model;
using System.Threading.Tasks;

namespace AccountingSystemDAL.Repos
{
    class GroupRepo : BaseRepo<Group>, IRepo<Group>
    {
        public GroupRepo()
        {
            Table = Context.Groups;
        }
        public int Delete(Guid id, byte[] timeStamp)
        {
            Context.Entry(new Group()
            {
                GroupId = id,
                Timestamp = timeStamp
            }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(Guid id, byte[] timeStamp)
        {
            Context.Entry(new Group()
            {
                GroupId = id,
                Timestamp = timeStamp
            }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }

    }
}
