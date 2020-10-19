using System;
using System.Data.Entity;
using AccountingSystemDAL.Model;
using System.Threading.Tasks;

namespace AccountingSystemDAL.Repos
{
    public class UserRepo : BaseRepo<User>, IRepo<User>
    {
        public UserRepo()
        {
            Table = Context.Users;
        }
        public int Delete(Guid id, byte[] timeStamp)
        {
            Context.Entry(new User()
            {
                UserId = id,
                Timestamp = timeStamp
            }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(Guid id, byte[] timeStamp)
        {
            Context.Entry(new User()
            {
                UserId = id,
                Timestamp = timeStamp
            }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }

    }
}
