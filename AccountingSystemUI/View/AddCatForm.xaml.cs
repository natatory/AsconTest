using System.Collections.Generic;
using System.Windows;
using AccountingSystemDAL.Model;
using AccountingSystemUI.ViewModel;
using AccountingSystemDAL.Repos;
using AccountingSystemUI.DI;

namespace AccountingSystemUI.View
{
    /// <summary>
    /// Логика взаимодействия для AddCatForm.xaml
    /// </summary>
    public partial class AddCatForm : Window
    {
        private AddCatFormVM addCatFormVM;
        private readonly IFactory _factory;

        public AddCatForm(IFactory factory, IList<Category> categories)
        {
            _factory = factory;
            addCatFormVM = new AddCatFormVM(_factory, categories);
            this.DataContext = addCatFormVM;
            InitializeComponent();
        }
    }
}
