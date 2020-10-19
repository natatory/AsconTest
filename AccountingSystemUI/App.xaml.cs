using AccountingSystemUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Principal;
using AccountingSystemUI.View;
using AccountingSystemDAL.Repos;
using AccountingSystemDAL.Model;
using System.Security.Cryptography.Pkcs;

namespace AccountingSystemUI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        MoneyManagementWindow moneyManagementWindow;
        IRepo<Category> _categoryRepo;
        IRepo<Recipient> _recipientRepo;
        IRepo<User> _userRepo;
        IRepo<Data> _dataRepo;
        string _currentUserName;

        //App()
        //{
        //AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
        //M1 mw = new M1();
        //
        //}
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            _categoryRepo = new CategoryRepo();
            _recipientRepo = new RecipientRepo();
            _userRepo = new UserRepo();
            _dataRepo = new DataRepo();
            _currentUserName = "Петр";
            moneyManagementWindow = new MoneyManagementWindow(_categoryRepo, _recipientRepo, _userRepo, _dataRepo, _currentUserName);
            App.Current.MainWindow = moneyManagementWindow;
            moneyManagementWindow.Show();//

        }
        private void App_OnExit(object sender, ExitEventArgs e)
        {
            //Application.Current.Shutdown();
        }
    }
}
