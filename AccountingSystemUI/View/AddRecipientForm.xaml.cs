using System.Collections.Generic;
using System.Windows;
using AccountingSystemDAL.Model;
using AccountingSystemUI.ViewModel;
using AccountingSystemDAL.Repos;


namespace AccountingSystemUI.View
{
    /// <summary>
    /// Логика взаимодействия для AddRecipientForm.xaml
    /// </summary>
    public partial class AddRecipientForm : Window
    {
        private AddRecipientFormVM addRecFormVM;
        private IList<Recipient> _recipients;
        private IRepo<Recipient> _recipientRepo;
        public AddRecipientForm(IList<Recipient> recipients, IRepo<Recipient> recipientRepo)
        {
            _recipients = recipients;
            _recipientRepo = recipientRepo;
            addRecFormVM = new AddRecipientFormVM(_recipients, _recipientRepo);
            this.DataContext = addRecFormVM;
            InitializeComponent();
    }
}
}
