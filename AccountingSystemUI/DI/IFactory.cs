using AccountingSystemDAL.Repos;
using AccountingSystemDAL.Model;
using AccountingSystemUI.Application;

namespace AccountingSystemUI.DI
{
    public interface IFactory
    {
        IRepo<User> CreateUserRepo();
        IRepo<Category> CreateCategoryRepo();
        IRepo<Data> CreateDataRepo();
        IRepo<Recipient> CreateRecipientRepo();
        //IList<Category> CreateCategoryObservableCollection();
        //IList<Recipient> CreateRecipientObservableCollection();
        //IList<User> CreateUserObservableCollection();
        //IList<Data> CreateDataObservableCollection();
        IWinHelper CreateWinHelper();
        IDBInteract CreateDBInteract();
        IExcelExporter CreateExcelExporter();

    }
}
