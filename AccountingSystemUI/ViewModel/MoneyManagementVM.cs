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
using System.Dynamic;
using System.ComponentModel;

namespace AccountingSystemUI.ViewModel
{
    public class MoneyManagementVM
    {
        public Visibility VisibilityMenuProp { get; set; } = Visibility.Collapsed;

        //todo: realise propchange
        public Visibility VisibilityBalanceWarningProp
        {
            get => CurrentUser.Balance < 0 ?
                Visibility.Visible : Visibility.Hidden;
        }
        public Visibility VisibilityNewCatBtn { get; set; } = Visibility.Hidden;
        public IRepo<Category> CategoryRepo { get; }
        public IRepo<Recipient> RecipientRepo { get; }
        public IRepo<User> UserRepo { get; }
        public IRepo<Data> DataRepo { get; }
        public IList<Category> Categories { get; set; }
        public IList<Recipient> Recipients { get; set; }
        public IList<User> Users { get; set; }
        public IList<Data> Transactions { get; set; }

        public User CurrentUser { get; set; }
        public IList<Data> CurrentUserTransactions { get => _currentUserTransactions; }
        private IList<Data> _currentUserTransactions;

        //some data as started value for binding user input controls
        public Data NewData { get; set; }

        public IList<Data.OperationType> OpTypes
        {
            get => Enum.GetValues(typeof(Data.OperationType))
            .OfType<Data.OperationType>().ToList();
        }
        public string Mode { get; set; }
        public bool IsFormEnable { get; set; } = true;

        //todo: DependencyInjection!!
        public MoneyManagementVM(IRepo<Category> categoryRepo, IRepo<Recipient> recipientRepo, IRepo<User> userRepo, IRepo<Data> dataRepo, string currentUserName)
        {
            CategoryRepo = categoryRepo;
            RecipientRepo = recipientRepo;
            UserRepo = userRepo;
            DataRepo = dataRepo;
            IsFormEnable = FieldsInit(CategoryRepo, RecipientRepo, UserRepo, DataRepo, currentUserName);
            NewData = GetNewData(CurrentUser);
            ConfigureUserInterface(CurrentUser);
        }

        private ICommand _openAddCategoryForm = null;
        public ICommand OpenAddCategoryFormCmd =>
    _openAddCategoryForm ?? (_openAddCategoryForm = new OpenAddCategoryFormCommand(Categories, CategoryRepo));

        private ICommand _openAddRecipientForm = null;
        public ICommand OpenAddRecipientFormCmd =>
    _openAddRecipientForm ?? (_openAddRecipientForm = new OpenAddRecipientFormCommand(Recipients, RecipientRepo));

        private ICommand _addData = null;
        public ICommand AddDataCmd =>
    _addData ?? (_addData = new AddDataCommand(Transactions, DataRepo, _currentUserTransactions, UserRepo, CurrentUser));

        //private ICommand _openUserManagementForm = null;
        //public ICommand OpenUserManagementForm =>
        //    _openUserManagementForm ?? (_openUserManagementForm = new OpenUserManagementFormCommand());

        private bool FieldsInit(IRepo<Category> categoryRepo, IRepo<Recipient> recipientRepo, IRepo<User> userRepo, IRepo<Data> dataRepo, string currentUserName)
        {
            if (categoryRepo == null
                || recipientRepo == null
                || userRepo == null
                || dataRepo == null
                || string.IsNullOrEmpty(currentUserName))
            {
                ShowErrorMsg();
                return false;
            }
            else
                try
                {
                    Categories = new ObservableCollection<Category>(CategoryRepo.GetAll());
                    Recipients = new ObservableCollection<Recipient>(RecipientRepo.GetAll());
                    Users = new ObservableCollection<User>(UserRepo.GetAll());
                    Transactions = new ObservableCollection<Data>(DataRepo.GetAll());
                    CurrentUser = Users.First(u => u.FirstName == currentUserName);
                    _currentUserTransactions = new ObservableCollection<Data>(CurrentUser.Transactions);
                    return true;
                }
                catch (Exception ex)
                {
                    ShowErrorMsg();
                    return false;
                }
        }
        private Data GetNewData(User currentUser)
        {
            if (currentUser == null) return null;
            var d = new Data
            {
                DataId = Guid.NewGuid(),
                UserId = CurrentUser.UserId,
                CategoryId = Categories.First().CategoryId,
                Description = "Описание операции",
                OpType = Data.OperationType.Расходы,
                RecipientId = Recipients.First().RecipientId,
                TransactionAmount = 1,
            };
            return d;
        }
        private void ConfigureUserInterface(User currentUser)
        {
            if (currentUser == null) return;
            VisibilityMenuProp = CurrentUser.Group.CanManageEmployee ?
                Visibility.Visible : Visibility.Collapsed;
            VisibilityNewCatBtn = CurrentUser.Group.CanAddCategories ?
                Visibility.Visible : Visibility.Hidden;
            Mode = CurrentUser.Group.Name == "Администраторы" ?
                "Администратор" : "Пользоватеь";

        }
        private void ShowErrorMsg()
        {
            MessageBox.Show(
                         "Непредвиденные данные контекста:",
                         "Ошибка",
                         MessageBoxButton.OK,
                         MessageBoxImage.Exclamation
                         );
        }
    }
}
