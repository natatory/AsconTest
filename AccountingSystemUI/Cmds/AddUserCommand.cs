using System.Collections.Generic;
using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using System.Windows;
using System.Linq;
using System;
using System.Windows.Input;

namespace AccountingSystemUI.Cmds
{
    public class AddUserCommand : CommandBase
    {
        private IRepo<User> _userRepo;

        private IList<User> _users;

        public event EventHandler CloseDialog;

        public AddUserCommand( IRepo<User> userRepo, IList<User> users)
        {
            _userRepo = userRepo;
            _users = users;
            CheckNullInputParams(_userRepo, _users);
        }

        public override void Execute(object parameter)
        {
            var user = parameter as User;
            if (!IsExist(user))
            {
                _userRepo.Add(user);
                _users.Add(user);
                CloseDialog?.Invoke(this, new EventArgs());
            }
            else
            {
                MessageBox.Show(
                         $"Пользователь \"{user}\"\n" +
                         $"уже содержится в базе\n\n",
                         "Дублирование данных",
                         MessageBoxButton.OK,
                         MessageBoxImage.Information
                         );
            }
        }

        public override bool CanExecute(object parameter)
        {
            return (parameter as User) != null
                && !((User)parameter).HasErrors
                && _users != null;
        }
        private void CheckNullInputParams(object catRepo, object categories)
        {
            if (catRepo == null || categories == null)
            {
                MessageBox.Show(
                         "Непредвиденные данные контекста",
                         "Ошибка",
                         MessageBoxButton.OK,
                         MessageBoxImage.Exclamation
                         );
                CloseDialog?.Invoke(this, new EventArgs());
            }
        }
        private bool IsExist(User user)
        {
            //todo: check WinUserName
            return _users.Any(u => u.FirstName == user.FirstName);
        }
    }
}
