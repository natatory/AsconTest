using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using AccountingSystemUI.View;
using System.Collections.Generic;

namespace AccountingSystemUI.Cmds
{
    public class OpenAddCategoryFormCommand : CommandBase
    {
        private IList<Category> _categories;
        private IRepo<Category> _catRepo;
        public OpenAddCategoryFormCommand(IList<Category> categories, IRepo<Category> catRepo)
        {
            _categories = categories;
            _catRepo = catRepo;
        }
        public override bool CanExecute(object parameter)
        {
            return _categories != null && _catRepo != null;
        }

        public override void Execute(object parameter)
        {
            var addCatForm = new AddCatForm(_categories, _catRepo);
            addCatForm.ShowDialog();
        }
    }
}
