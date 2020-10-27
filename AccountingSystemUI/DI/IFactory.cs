using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingSystemDAL.Repos;
using AccountingSystemDAL.Model;
using AccountingSystemUI.ViewModel;
using AccountingSystemUI.Application;

namespace AccountingSystemUI.DI
{
    public interface IFactory
    {
        IRepo<User> CreateUserRepo();
        IRepo<Category> CreateCategoryRepo();
        IRepo<Data> CreateDataRepo();
        IRepo<Recipient> CreateRecipientRepo();
        IList<Category> CreateCategoryObservableCollection();
        IList<Recipient> CreateRecipientObservableCollection();
        IList<User> CreateUserObservableCollection();
        IList<Data> CreateDataObservableCollection();
        IWinHelper CreateWinHelper();
        IDBInteract CreateDBInteract();
        IExcelExporter CreateExcelExporter();

    }
}
