using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AccountingSystemUI.View;
using AccountingSystemDAL.Repos;
using AccountingSystemDAL.Model;
using AccountingSystemUI.Application;
using AccountingSystemUI.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using PropertyChanged;
using System.Threading;


namespace AccountingSystemUI.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    class StartWindowVM
    {
        IRepo<Category> _categoryRepo;
        IRepo<Recipient> _recipientRepo;
        IRepo<User> _userRepo;
        IRepo<Data> _dataRepo;
        IWinAccount _currentUser;
        MoneyManagementWindow moneyManagementWindow;
        //public bool? DialogResult { get; set; }
        public IList<string> Messages { get; set; }

        public StartWindowVM()
        {
            Messages = new ObservableCollection<string>();
        }

        public void Start1()
        {
            ThreadPool.QueueUserWorkItem(
                op =>
                {
                    
                });
        }

         

        //public void Start()
        //{
        //    _currentUser = WinHelper.GetCurrentWinAccount();
        //    if (_currentUser == null)
        //    {
        //        MessageBox.Show("Ошибка идентификации пользователя\n" +
        //                "Продолжение невозможно",
        //                "Ошибка",
        //                 MessageBoxButton.OK,
        //                 MessageBoxImage.Error);
        //        //App.Current.Shutdown();
        //        return;
        //    }
        //    if (_currentUser.IsAdmin)
        //    {
        //        //DataInitializer (EF subsystem) class will recreate and optionally re-seed
        //        //the database only if the database does not exist.
        //        Messages.Add("Создание/подключение к БД..");
        //        try
        //        {
        //            _categoryRepo = new CategoryRepo();
        //            _recipientRepo = new RecipientRepo();
        //            _userRepo = new UserRepo();
        //            _dataRepo = new DataRepo();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message + "\nПродолжение невозможно");
        //            //App.Current.Shutdown();
        //            return;
        //        }
        //        Messages.Add("Успешно!");
        //        //try (just in case) to set access right read/write db for user-group accounts
        //        DBInteract.SetAccessRights("AccountingSystem");
        //        moneyManagementWindow = new MoneyManagementWindow(_categoryRepo, _recipientRepo, _userRepo, _dataRepo, _currentUser);
        //    }
        //    else
        //    {
        //        if (DBInteract.IsDBExist("AccountingSystem")) //connectionString now is hardcodet in DBInteract
        //        {
        //            //for user-account just create entities from existing db
        //            try
        //            {
        //                _categoryRepo = new CategoryRepo();
        //                _recipientRepo = new RecipientRepo();
        //                _userRepo = new UserRepo();
        //                _dataRepo = new DataRepo();
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message + "\nПродолжение невозможно");
        //                //App.Current.Shutdown();
        //                return;
        //            }
        //            moneyManagementWindow = new MoneyManagementWindow(_categoryRepo, _recipientRepo, _userRepo, _dataRepo, _currentUser);
        //        }
        //        //user-accounts have no authority to create a database
        //        else moneyManagementWindow = new MoneyManagementWindow(_currentUser);
        //    }
        //    Messages.Add("Запуск");
        //    App.Current.MainWindow = moneyManagementWindow;
        //    moneyManagementWindow.Show();

        //    //DialogResult = true;
        //}
    }
}
