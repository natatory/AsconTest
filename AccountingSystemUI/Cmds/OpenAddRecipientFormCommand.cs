using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using AccountingSystemUI.View;
using System.Collections.Generic;

namespace AccountingSystemUI.Cmds
{
    public class OpenAddRecipientFormCommand : CommandBase
    {
        private IList<Recipient> _recipients;
        private IRepo<Recipient> _recipientRepo;
        public OpenAddRecipientFormCommand(IList<Recipient> recipients, IRepo<Recipient> recipientRepo)
        {
            _recipients = recipients;
            _recipientRepo = recipientRepo;
        }
        public override bool CanExecute(object parameter)
        {
            return _recipients != null && _recipientRepo != null;
        }

        public override void Execute(object parameter)
        {
            var addCatForm = new AddRecipientForm(_recipients, _recipientRepo);
            addCatForm.ShowDialog();
        }
    }
}
