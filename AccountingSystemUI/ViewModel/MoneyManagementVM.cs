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
using AccountingSystemUI.Application;
using Microsoft.Office.Interop.Excel;

namespace AccountingSystemUI.ViewModel
{
    public class MoneyManagementVM : DependencyObject
    {

        public Visibility VisibilityMenu { get; set; } = Visibility.Collapsed;

        //todo: create dependency prop?
        //public Visibility VisibilityBalanceWarning
        //{
        //    get
        //    {
        //        CurrentUser.Balance < 0 ? Visibility.Visible : Visibility.Hidden
        //    }
        //}
        public Visibility VisibilityBalanceWarning { get; set; } = Visibility.Hidden;
        public Visibility VisibilityNewCatBtn { get; set; } = Visibility.Hidden;
        public IRepo<Category> CategoryRepo { get;}
        public IRepo<Recipient> RecipientRepo { get; }
        public IRepo<User> UserRepo { get; }
        public IRepo<Data> DataRepo { get; }
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
        public bool IsFormEnable { get; set; } = true;

        //todo: DependencyInjection!!
        public MoneyManagementVM(IRepo<Category> categoryRepo, IRepo<Recipient> recipientRepo, IRepo<User> userRepo, IRepo<Data> dataRepo, IWinAccount currentUser)
        {
            //ReposInit(categoryRepo, recipientRepo, userRepo, dataRepo);
            CategoryRepo = categoryRepo;
            RecipientRepo = recipientRepo;
            UserRepo = userRepo;
            DataRepo = dataRepo;
            Categories = new ObservableCollection<Category>(CategoryRepo.GetAll());
            Recipients = new ObservableCollection<Recipient>(RecipientRepo.GetAll());
            Users = new ObservableCollection<User>(UserRepo.GetAll());
            Transactions = new ObservableCollection<Data>(DataRepo.GetAll());
            //CollectionsInit();
            UserInit(currentUser);
            ConfigureUserInterface(currentUser);
            NewData = GetNewData(CurrentUser);
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

        private ICommand _openUserManagementForm = null;
        public ICommand OpenUserManagementForm =>
                _openUserManagementForm ?? (_openUserManagementForm = new OpenUserManagementFormCommand(Users, UserRepo));

        private void ReposInit(IRepo<Category> categoryRepo, IRepo<Recipient> recipientRepo, IRepo<User> userRepo, IRepo<Data> dataRepo)
        {
            //if (categoryRepo == null
            //    || recipientRepo == null
            //    || userRepo == null
            //    || dataRepo == null)
            //{
            //    MessageBox.Show(
            //             "Непредвиденные данные контекста:",
            //             "Ошибка",
            //             MessageBoxButton.OK,
            //             MessageBoxImage.Exclamation
            //             );
            //}
            //else
            //{
                //CategoryRepo = categoryRepo;
                //RecipientRepo = recipientRepo;
                //UserRepo = userRepo;
                //DataRepo = dataRepo;
            //}
        }
        private void CollectionsInit()
        {
            //try
            //{
            //    Categories = new ObservableCollection<Category>(CategoryRepo.GetAll());
            //    Recipients = new ObservableCollection<Recipient>(RecipientRepo.GetAll());
            //    Users = new ObservableCollection<User>(UserRepo.GetAll());
            //    Transactions = new ObservableCollection<Data>(DataRepo.GetAll());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Непредвиденные данные контекста",
            //             MessageBoxButton.OK,
            //             MessageBoxImage.Error
            //             );
            //}
        }

        private void UserInit(IWinAccount currentUser)
        {
            if (currentUser == null)
            {
                MessageBox.Show("Ошибка идентификации пользователя\n" +
                        "Управление недоступно",
                        "Ошибка",
                         MessageBoxButton.OK,
                         MessageBoxImage.Error);
                IsFormEnable = false;
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
                Mode = winAccount.IsAdmin ? "Администратор" : "Пользоватеь";
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
