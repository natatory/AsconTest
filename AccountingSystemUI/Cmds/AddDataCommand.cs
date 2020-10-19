using System.Collections.Generic;
using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using System.Windows;
using System.Linq;
using System;
using System.Windows.Input;

namespace AccountingSystemUI.Cmds
{
    public class AddDataCommand : CommandBase
    {
        private IRepo<Data> _dataRepo;
        private IRepo<User> _userRepo;
        private IList<Data> _transactions;
        private IList<Data> _currentUserTransactions;
        private User _currentUser;

        public AddDataCommand(IList<Data> transactions, IRepo<Data> dataRepo, IList<Data> currentUserTransactions, IRepo<User> userRepo, User currentUser)
        {
            _currentUser = currentUser;
            _dataRepo = dataRepo;
            _transactions = transactions;
            _userRepo = userRepo;
            _currentUserTransactions = currentUserTransactions;
            CheckNullInputParams(_dataRepo, _transactions);
        }

        public override void Execute(object parameter)
        {
            var inputUserData = parameter as Data;
            var resultData = CreateCompliteData(inputUserData);
            _currentUser.Balance = resultData.BalanceAfterTransact;
            try
            {
                _dataRepo.Add(resultData);
                _userRepo.Save(_currentUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                         MessageBoxButton.OK,
                         MessageBoxImage.Exclamation
                         );
                return;
            }
            _transactions.Add(resultData);
            _currentUserTransactions.Add(resultData);

        }

        public override bool CanExecute(object parameter)
        {
            return (parameter as Data) != null
                && !((Data)parameter).HasErrors
                && _transactions != null;
        }

        private Data CreateCompliteData(Data data)
        {
            return new Data
            {
                DataId = Guid.NewGuid(),
                UserId = _currentUser.UserId,
                OpType = data.OpType,
                CategoryId = data.CategoryId,
                RecipientId = data.RecipientId,
                Description = data.Description,
                TransactionAmount = data.TransactionAmount,
                BalanceAfterTransact = data.OpType == Data.OperationType.Расходы ?
                        _currentUser.Balance - data.TransactionAmount
                        : _currentUser.Balance + data.TransactionAmount
            };
        }
        private void CheckNullInputParams(object _dataRepo, object _transactions)
        {
            if (_dataRepo == null || _transactions == null)
            {
                MessageBox.Show(
                         "Непредвиденные данные контекста",
                         "Ошибка",
                         MessageBoxButton.OK,
                         MessageBoxImage.Exclamation
                         );
            }
        }
    }
}
