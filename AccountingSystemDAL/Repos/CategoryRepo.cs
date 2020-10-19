using System;
using System.Data.Entity;
using AccountingSystemDAL.Model;
using System.Threading.Tasks;

namespace AccountingSystemDAL.Repos
{
    public class CategoryRepo : BaseRepo<Category>, IRepo<Category>
    {
        public CategoryRepo()
        {
            Table = Context.Categories;
        }
        public int Delete(Guid id, byte[] timeStamp)
        {
            Context.Entry(new Category()
            {
                CategoryId = id,
                Timestamp = timeStamp
            }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(Guid id, byte[] timeStamp)
        {
            Context.Entry(new Category()
            {
                CategoryId = id,
                Timestamp = timeStamp
            }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }

    }
}
