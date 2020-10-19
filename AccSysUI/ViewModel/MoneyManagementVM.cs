using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using PropertyChanged;
using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using System.Collections.ObjectModel;

namespace AccSysUI.ViewModel
{
    //[AddINotifyPropertyChangedInterface]
    public class MoneyManagementVM
    {
        public Visibility VisiblityMenuProp { get; set; } 
        public Visibility VisiblityBalanceWarningProp { get; set; }
        public IRepo<Category> CategoryRepo { get; }
        public IList<Category> Categories { get; set; }

        public MoneyManagementVM(IRepo<Category> categoryRepo)
        {
            CategoryRepo = categoryRepo;
            Categories = new ObservableCollection<Category>(CategoryRepo.GetAll());
        }
    }
}
