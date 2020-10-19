using System.Collections.Generic;
using System.Windows;
using AccountingSystemDAL.Model;
using AccountingSystemUI.ViewModel;
using AccountingSystemDAL.Repos;

namespace AccountingSystemUI.View
{
    /// <summary>
    /// Логика взаимодействия для AddCatForm.xaml
    /// </summary>
    public partial class AddCatForm : Window
    {
        private AddCatFormVM addCatFormVM;
        private IList<Category> _categories;
        private IRepo<Category> _catRepo;

        public AddCatForm(IList<Category> categories, IRepo<Category> catRepo)
        {
            _categories = categories;
            _catRepo = catRepo;
            addCatFormVM = new AddCatFormVM(_categories, _catRepo);
            this.DataContext = addCatFormVM;
            InitializeComponent();
        }
    }
}
