﻿using System.Collections.Generic;
using System.Windows;
using AccountingSystemDAL.Model;
using AccountingSystemUI.ViewModel;
using AccountingSystemDAL.Repos;
using System.Windows.Input;
using AccountingSystemUI.DI;

namespace AccountingSystemUI.View
{
    /// <summary>
    /// Логика взаимодействия для AddUserForm.xaml
    /// </summary>
    public partial class AddUserForm : Window
    {
        private AddUserFormVM _addUserFormVM;
        private UserDataInfoForm _userDataInfoForm;
        public AddUserForm(IFactory factory, IList<User> users)
        {
            _addUserFormVM = new AddUserFormVM(factory, users);
            this.DataContext = _addUserFormVM;
            InitializeComponent();
        }


        private void dgUserTransactions_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedUser = dgUserTransactions.SelectedItem as User;
            if (selectedUser != null)
            {
                _userDataInfoForm = new UserDataInfoForm(selectedUser);
                _userDataInfoForm.Show();
            }
        }
    }
}
