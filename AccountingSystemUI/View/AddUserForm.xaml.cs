using System.Collections.Generic;
using System.Windows;
using AccountingSystemDAL.Model;
using AccountingSystemUI.ViewModel;
using AccountingSystemDAL.Repos;

namespace AccountingSystemUI.View
{
    /// <summary>
    /// Логика взаимодействия для AddUserForm.xaml
    /// </summary>
    public partial class AddUserForm : Window
    {
        private AddUserFormVM _addUserFormVM;
        private IRepo<User> _userRepo;
        private IList<User> _users;
        public AddUserForm(IRepo<User> userRepo, IList<User> users)
        {
            _userRepo = userRepo;
            _users = users;
            _addUserFormVM = new AddUserFormVM(_userRepo, _users);
            this.DataContext = _addUserFormVM;
            InitializeComponent();
        }
    }
}
