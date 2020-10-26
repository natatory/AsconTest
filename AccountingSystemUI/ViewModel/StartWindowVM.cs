using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingSystemUI.View;
using AccountingSystemDAL.Repos;
using AccountingSystemDAL.Model;
using AccountingSystemUI.Application;
using System.Collections.ObjectModel;


namespace AccountingSystemUI.ViewModel
{
    class StartWindowVM
    {
        IRepo<Category> _categoryRepo;
        IRepo<Recipient> _recipientRepo;
        IRepo<User> _userRepo;
        IRepo<Data> _dataRepo;
        IWinAccount _currentUser;
        MoneyManagementWindow moneyManagementWindow;
        public IList<string> Messages { get; set; }

        public StartWindowVM()
        {
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
            _currentUser = WinHelper.GetCurrentWinAccount();
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
                    _categoryRepo = new CategoryRepo();
                    _recipientRepo = new RecipientRepo();
                    _userRepo = new UserRepo();
                    _dataRepo = new DataRepo();
                }
                catch (Exception ex)
                {
                    AddMsg(ex.Message);
                    return;
                }
                AddMsg("Успешно!");
                //try (just in case) to set access right read/write db for user-group accounts
                DBInteract.SetAccessRights("AccountingSystem");

                App.Current.Dispatcher.Invoke(() =>
                              moneyManagementWindow = new MoneyManagementWindow(_categoryRepo, _recipientRepo, _userRepo, _dataRepo, _currentUser)
                );
            }
            else
            {
                AddMsg("Подключение к БД..");
                if (DBInteract.IsDBExist("AccountingSystem")) //connectionString now is hardcodet in DBInteract
                {
                    //for user-account just create entities from existing db
                    try
                    {
                        _categoryRepo = new CategoryRepo();
                        _recipientRepo = new RecipientRepo();
                        _userRepo = new UserRepo();
                        _dataRepo = new DataRepo();
                    }
                    catch (Exception ex)
                    {
                        AddMsg(ex.Message);
                        return;
                    }
                    AddMsg("Успешно!");
                    App.Current.Dispatcher.Invoke(() =>
                               moneyManagementWindow = new MoneyManagementWindow(_categoryRepo, _recipientRepo, _userRepo, _dataRepo, _currentUser)
                    );
                }

                //user-accounts have no authority to create a database
                else
                {
                    AddMsg("Ошибка подключения. Гостевой вход.");
                    App.Current.Dispatcher.Invoke(() =>
                                moneyManagementWindow = new MoneyManagementWindow(_currentUser)
                    );
                }
            }
            AddMsg("Запуск");

            App.Current.Dispatcher.Invoke(() =>
            {
                App.Current.MainWindow = moneyManagementWindow;
                moneyManagementWindow.Show();
            });
        }
    }
}
