using System.Collections.Generic;
using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using System.Windows;
using System.Linq;
using System;
using System.Windows.Input;
using AccountingSystemUI.Application;
using AccountingSystemUI.DI;
using System.Collections.ObjectModel;

namespace AccountingSystemUI.Cmds
{
    public class AddWinUserCommand : CommandBase
    {
        private IList<IWinAccount> _winUsers;
        //private IWinHelper _winhelper;
        private readonly IFactory _factory;

        public event EventHandler CloseDialog;

        public AddWinUserCommand(IList<IWinAccount> winUsers, IFactory factory)
        {
            _factory = factory;
            //_winhelper = _factory.CreateWinHelper();
            _winUsers = winUsers;
            CheckNullInputParams(_winUsers);
        }

        public override void Execute(object parameter)
        {
            var resultWinUser = parameter as IWinAccount;
            if (IsExist(resultWinUser))
            {
                MessageBox.Show(
                           $"Пользователь с win-логином \"{resultWinUser.Name}\" уже существует",
                           "Дублирование данных",
                           MessageBoxButton.OK,
                           MessageBoxImage.Information
                           );
            }
            else
            {
                var winUserCreated = false;
                try
                {
                    winUserCreated = _factory.CreateWinHelper().CreateWinAccount(resultWinUser);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                if (winUserCreated)
                {
                    MessageBox.Show($"Пользователь создан!",
                           "Успех",
                           MessageBoxButton.OK,
                           MessageBoxImage.Information);
                    _winUsers.Add(resultWinUser);
                    CloseDialog?.Invoke(this, new EventArgs());
                }
            }
        }

        public override bool CanExecute(object parameter)
        {
            return (parameter as IWinAccount) != null
                && !string.IsNullOrEmpty(((IWinAccount)parameter).Name)
                && _winUsers != null;
        }
        private void CheckNullInputParams(object winUsers)
        {
            if (winUsers == null)
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
        private bool IsExist(IWinAccount winUser)
        {
            return _winUsers.Any(u => u.Name == winUser.Name);
        }
    }
}
