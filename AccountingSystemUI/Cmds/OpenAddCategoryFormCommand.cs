using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using AccountingSystemUI.DI;
using AccountingSystemUI.View;
using Ninject;
using System.Collections.Generic;

namespace AccountingSystemUI.Cmds
{
    public class OpenAddCategoryFormCommand : CommandBase
    {
        private IList<Category> _categories;
        private IRepo<Category> _catRepo;
        private readonly IFactory _factory;
        public OpenAddCategoryFormCommand(IFactory factory, IList<Category> categories)
        {
            _factory = factory;
            _categories = categories;
            _catRepo = _factory.CreateCategoryRepo();
        }
        public override bool CanExecute(object parameter)
        {
            return _categories != null && _catRepo != null;
        }

        public override void Execute(object parameter)
        {
            var addCatForm = new AddCatForm(_factory, _categories);
            addCatForm.ShowDialog();
        }
    }
}
