using System;
using System.Collections.Generic;
using AccountingSystemUI.Cmds;
using System.Windows.Input;
using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using PropertyChanged;
using System.Linq;
using AccountingSystemUI.DI;

namespace AccountingSystemUI.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    class AddRecipientFormVM
    {
        public bool? DialogResult { get; set; }

        private IRepo<Recipient> _recipientRepo;
        public IList<Recipient> Recipients { get; private set; }
        public Recipient NewRecipient { get; private set; }
        private readonly IFactory _factory;
        public AddRecipientFormVM(IFactory factory)
        {
            _factory = factory;
            Recipients = _factory.CreateRecipientObservableCollection(); ;
            _recipientRepo = _factory.CreateRecipientRepo();
            NewRecipient = GetNewRecipient();
            CloseAddDialogEventSubscribe();
        }
        //generate a part of a new recipient entity,  
        //this will be send to the form as some initial data fields
        //to allow Model Validation-based check input
        private Recipient GetNewRecipient()
        {
            return new Recipient()
            {
                Name = "Получатель"
            };
        }
        private ICommand _addRecCmd = null;
        public ICommand AddRecCmd =>

             _addRecCmd ?? (_addRecCmd = new AddRecCommand(_factory));

        private void CloseAddDialogEventSubscribe()
        {
            if (AddRecCmd != null)
            {
                ((AddRecCommand)AddRecCmd).CloseDialog +=
                    (object sender, EventArgs e) => DialogResult = true;
            }
        }
    }
}
