﻿using System.Collections.Generic;
using System.Windows;
using AccountingSystemDAL.Model;
using AccountingSystemUI.ViewModel;
using AccountingSystemDAL.Repos;
using AccountingSystemUI.DI;


namespace AccountingSystemUI.View
{
    /// <summary>
    /// Логика взаимодействия для AddRecipientForm.xaml
    /// </summary>
    public partial class AddRecipientForm : Window
    {
        private AddRecipientFormVM addRecFormVM;
        public AddRecipientForm(IFactory factory, IList<Recipient> recipients)
        {
            addRecFormVM = new AddRecipientFormVM(factory, recipients);
            this.DataContext = addRecFormVM;
            InitializeComponent();
    }
}
}
