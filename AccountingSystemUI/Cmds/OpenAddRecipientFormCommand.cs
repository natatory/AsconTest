using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using AccountingSystemUI.DI;
using AccountingSystemUI.View;
using System.Collections.Generic;

namespace AccountingSystemUI.Cmds
{
    public class OpenAddRecipientFormCommand : CommandBase
    {
        private IList<Recipient> _recipients;
        private IRepo<Recipient> _recipientRepo;
        private readonly IFactory _factory;
        public OpenAddRecipientFormCommand(IFactory factory, IList<Recipient> recipients)
        {
            _factory = factory;
            _recipients = recipients;
            _recipientRepo = _factory.CreateRecipientRepo();
        }
        public override bool CanExecute(object parameter)
        {
            return _recipients != null && _recipientRepo != null;
        }

        public override void Execute(object parameter)
        {
            var addCatForm = new AddRecipientForm(_factory, _recipients);
            addCatForm.ShowDialog();
        }
    }
}
