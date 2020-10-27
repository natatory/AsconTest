using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using PropertyChanged;
using System.Windows.Input;
using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using System.Collections.ObjectModel;
using AccountingSystemUI.Cmds;
using AccountingSystemUI.DI;
using System.ComponentModel;
using AccountingSystemUI.Application;


namespace AccountingSystemUI.ViewModel
{
    public class MoneyManagementVM
    {

        public Visibility VisibilityMenu { get; set; } = Visibility.Collapsed;
        public Visibility VisibilityNewCatBtn { get; set; } = Visibility.Hidden;
        public Visibility VisibilityConnectDBWarning { get; set; } = Visibility.Hidden;
        public IList<Category> Categories { get; set; }
        public IList<Recipient> Recipients { get; set; }
        public IList<User> Users { get; set; }
        public IList<Data> Transactions { get; set; }
        public User CurrentUser { get; set; }
        public IList<Data> CurrentUserTransactions { get => _currentUserTransactions; }
        private IList<Data> _currentUserTransactions = null;

        //some data as started value for binding user input controls
        public Data NewData { get; set; }

        public IList<Data.OperationType> OpTypes
        {
            get => Enum.GetValues(typeof(Data.OperationType))
            .OfType<Data.OperationType>().ToList();
        }
        public string Mode { get; set; } = "Пользователь";

        private readonly IFactory _factory;

        //todo: DependencyInjection!!
        public MoneyManagementVM(IFactory factory, bool guest)
        {
            _factory = factory;
            if (!guest)
            {
                Categories = _factory.CreateCategoryObservableCollection();
                Recipients = _factory.CreateRecipientObservableCollection();
                Users = _factory.CreateUserObservableCollection();
                Transactions = _factory.CreateDataObservableCollection();
            }
            else
            {
                VisibilityConnectDBWarning = Visibility.Visible;
            }
            UserInit(_factory.CreateWinHelper().GetCurrentWinAccount());
            ConfigureUserInterface(_factory.CreateWinHelper().GetCurrentWinAccount());
            NewData = GetNewData(CurrentUser);
        }

        private ICommand _openAddCategoryForm = null;
        public ICommand OpenAddCategoryFormCmd =>
                _openAddCategoryForm ?? (_openAddCategoryForm = new OpenAddCategoryFormCommand(_factory));

        private ICommand _openAddRecipientForm = null;
        public ICommand OpenAddRecipientFormCmd =>
                _openAddRecipientForm ?? (_openAddRecipientForm = new OpenAddRecipientFormCommand(_factory));

        private ICommand _addData = null;
        public ICommand AddDataCmd =>
                _addData ?? (_addData = new AddDataCommand(_factory, _currentUserTransactions, CurrentUser));

        private ICommand _openUserManagementForm = null;
        public ICommand OpenUserManagementForm =>
                _openUserManagementForm ?? (_openUserManagementForm = new OpenUserManagementFormCommand(_factory));

        private ICommand _excelExport = null;
        public ICommand ExcelExport =>
                _excelExport ?? (_excelExport = new ExcelExportCommand(_factory));

        private void UserInit(IWinAccount currentUser)
        {
            if (currentUser == null)
            {
                MessageBox.Show("Ошибка идентификации пользователя\n" +
                        "Управление недоступно",
                        "Ошибка",
                         MessageBoxButton.OK,
                         MessageBoxImage.Error);
            }
            if (Users != null)
            {
                CurrentUser = Users.FirstOrDefault(u => u.WinUserName == currentUser.Name);
                _currentUserTransactions = CurrentUser != null ?
                    new ObservableCollection<Data>(CurrentUser.Transactions.OrderBy(x => x.Date))
                    : null;
            }
        }
        private void ConfigureUserInterface(IWinAccount winAccount)
        {
            if (winAccount != null)
            {
                VisibilityMenu = winAccount.IsAdmin ?
             Visibility.Visible : Visibility.Collapsed;
                VisibilityNewCatBtn = winAccount.IsAdmin ?
                    Visibility.Visible : Visibility.Hidden;
                Mode = winAccount.IsAdmin ? "Администратор" : "Пользователь";
            }
        }

        //generate a part of a new Data entity,  
        //this will be send to the form as some initial data fields
        //to allow Model Validation-based check input
        private Data GetNewData(User currentUser)
        {
            if (currentUser == null) return null;
            var d = new Data
            {
                UserId = CurrentUser.UserId,
                CategoryId = Categories.First().CategoryId,
                Description = "Описание операции",
                OpType = Data.OperationType.Расходы,
                RecipientId = Recipients.First().RecipientId,
                TransactionAmount = 1m,
            };
            return d;
        }

    }
}
