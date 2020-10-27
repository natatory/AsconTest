using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using AccountingSystemUI.DI;
using AccountingSystemUI.View;
using System.Collections.Generic;

namespace AccountingSystemUI.Cmds
{
    public class OpenAddCategoryFormCommand : CommandBase
    {
        private IList<Category> _categories;
        private IRepo<Category> _catRepo;
        private readonly IFactory _factory;
        public OpenAddCategoryFormCommand(IFactory factory)
        {
            _factory = factory;
            _categories = _factory.CreateCategoryObservableCollection();
            _catRepo = _factory.CreateCategoryRepo();
        }
        public override bool CanExecute(object parameter)
        {
            return _categories != null && _catRepo != null;
        }

        public override void Execute(object parameter)
        {
            var addCatForm = new AddCatForm(_factory);
            addCatForm.ShowDialog();
        }
    }
}
