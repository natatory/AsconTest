using System.Collections.Generic;
using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using AccountingSystemUI.DI;
using System.Windows;
using System;
using System.Linq;


namespace AccountingSystemUI.Cmds
{
    public class AddRecCommand : CommandBase
    {
        private IRepo<Recipient> _recipientRepo;

        private IList<Recipient> _recipients;
        private readonly IFactory _factory;

        public event EventHandler CloseDialog;

        public AddRecCommand(IFactory factory, IList<Recipient> recipients)
        {
            _factory = factory;
            _recipientRepo = _factory.CreateRecipientRepo();
            _recipients = recipients;
            CheckNullInputParams(_recipientRepo, _recipients);
        }

        public override void Execute(object parameter)
        {
            var recipient = parameter as Recipient;
            if (!IsExist(recipient))
            {
                _recipientRepo.Add(recipient);
                _recipients.Add(recipient);
                CloseDialog?.Invoke(this, new EventArgs());
            }
            else
            {
                MessageBox.Show(
                         $"Получатель \"{recipient}\"\n" +
                         $"уже содержится в базе\n\n",
                         "Дублирование данных",
                         MessageBoxButton.OK,
                         MessageBoxImage.Information
                         );
            }
        }

        public override bool CanExecute(object parameter)
        {
            return (parameter as Recipient) != null
                //todo: удалить эту строку и разобраться с валидацией текстового поля
                && !string.IsNullOrEmpty(((Recipient)parameter).Name)

                && !((Recipient)parameter).HasErrors
                && _recipients != null;
        }
        private void CheckNullInputParams(object recipientRepo, object recipients)
        {
            if (recipientRepo == null || recipients == null)
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
        private bool IsExist(Recipient recipient)
        {
            return _recipients.Any(c => c.Name == recipient.Name);
        }
    }
}
