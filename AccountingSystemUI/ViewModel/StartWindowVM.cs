using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingSystemUI.View;
using AccountingSystemUI.Application;
using System.Collections.ObjectModel;
using AccountingSystemUI.DI;
using AccountingSystemDAL.Repos;
using AccountingSystemDAL.Model;

namespace AccountingSystemUI.ViewModel
{
    class StartWindowVM
    {
        IWinAccount _currentUser;
        IDBInteract _dbInteract;
        private readonly IFactory _factory;
        MoneyManagementWindow moneyManagementWindow;
        bool _guest = false;
        public IList<string> Messages { get; set; }

        public StartWindowVM(IFactory factory)
        {
            _factory = factory;
            _currentUser = _factory.CreateWinHelper().GetCurrentWinAccount();
            _dbInteract = _factory.CreateDBInteract();
            Messages = new ObservableCollection<string>();
        }

        public void Start()
        {
            Task.Factory.StartNew(() =>
            {
                StartAsync();
            });
        }

        void AddMsg(string msg)
        {
            App.Current.Dispatcher.Invoke(() => Messages.Add(msg));
        }

        public void StartAsync()
        {
            if (_currentUser == null)
            {
                AddMsg("Ошибка идентификации пользователя. Останов");
                return;
            }
            if (_currentUser.IsAdmin)
            {
                //DataInitializer (EF subsystem) class will recreate and optionally re-seed
                //the database only if the database does not exist.
                AddMsg("Создание/подключение к БД..");
                try
                {
                    GetReposFromFactory();
                }
                catch (Exception ex)
                {
                    AddMsg(ex.Message);
                    return;
                }
                AddMsg("Успешно!");
                //try (just in case) to set access right read/write db for user-group accounts
                _dbInteract.SetAccessRights("AccountingSystem");
            }
            else
            {
                AddMsg("Подключение к БД..");
                if (_dbInteract.IsDBExist("AccountingSystem")) //connectionString now is hardcodet in DBInteract
                {
                    //for user-account just create Repos from existing db
                    try
                    {
                        GetReposFromFactory();
                    }
                    catch (Exception ex)
                    {
                        AddMsg(ex.Message);
                        return;
                    }
                    AddMsg("Успешно!");
                }

                //user-accounts have no authority to create a database
                else
                {
                    AddMsg("Ошибка подключения. Гостевой вход.");
                    _guest = true;
                }
            }
            AddMsg("Запуск");

            App.Current.Dispatcher.Invoke(() =>
            {
                App.Current.MainWindow = moneyManagementWindow;
                moneyManagementWindow = new MoneyManagementWindow(_factory, _guest);
                moneyManagementWindow.Show();
            });
        }

        private void GetReposFromFactory()
        {
            _factory.CreateCategoryRepo();
            _factory.CreateRecipientRepo();
            _factory.CreateUserRepo();
            _factory.CreateDataRepo();
        }
    }
}
