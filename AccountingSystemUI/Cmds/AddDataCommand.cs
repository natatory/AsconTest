using System.Collections.Generic;
using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using System.Windows;
using System.Linq;
using System;
using System.Windows.Input;
using AccountingSystemUI.DI;
using Ninject;

namespace AccountingSystemUI.Cmds
{
    public class AddDataCommand : CommandBase
    {
        private IRepo<Data> _dataRepo;
        private IRepo<User> _userRepo;
        private IList<Data> _transactions;
        private IList<Data> _currentUserTransactions;
        private User _currentUser;
        private readonly IFactory _factory;

        public AddDataCommand(IFactory factory, IList<Data> transactions, IList<Data> currentUserTransactions, User currentUser)
        {
            _factory = factory;
            _currentUser = currentUser;
            _dataRepo = _factory.CreateDataRepo();
            _transactions = transactions;
            _userRepo = _factory.CreateUserRepo();
            _currentUserTransactions = currentUserTransactions;
            CheckNullInputParams(_dataRepo, _transactions);
        }

        public override void Execute(object parameter)
        {
            var inputData = parameter as Data;
            var resultData = CreateCompliteData(inputData);
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
                Date = DateTime.Now,
                RecipientId = data.RecipientId,
                Description = data.Description,
                TransactionAmount = data.TransactionAmount,
                BalanceAfterTransact = data.OpType == Data.OperationType.Расходы ?
                        _currentUser.Balance - data.TransactionAmount
                        : _currentUser.Balance + data.TransactionAmount
            };
        }
        private void CheckNullInputParams(object dataRepo, object transactions)
        {
            if (dataRepo == null || transactions == null)
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
