using System;
using System.Windows;
using AccountingSystemUI.View;
using AccountingSystemDAL.Repos;
using AccountingSystemDAL.Model;
using AccountingSystemUI.Application;

namespace AccountingSystemUI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        StartWindow startWindow;
        //MoneyManagementWindow moneyManagementWindow;
        //IRepo<Category> _categoryRepo;
        //IRepo<Recipient> _recipientRepo;
        //IRepo<User> _userRepo;
        //IRepo<Data> _dataRepo;
        //IWinAccount _currentUser;

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            //App.Current.MainWindow = moneyManagementWindow;
            App.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            startWindow = new StartWindow();
            startWindow.Show();

            //App.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            //App.Current.MainWindow = moneyManagementWindow;
            //appGeneral = new AppGeneral(moneyManagementWindow);
            //appGeneral.Configure();
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
            //        App.Current.Shutdown();
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

            //    moneyManagementWindow.Show();

        }
    }
}


