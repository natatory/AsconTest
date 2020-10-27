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
    class AddCatFormVM
    {
        public bool? DialogResult { get; set; }

        private IRepo<Category> _catRepo;
        public IList<Category> Categories { get; private set; }
        private readonly IFactory _factory;
        public Category NewCategory { get; private set; }
        public AddCatFormVM(IFactory factoey)
        {
            _factory = factoey;
            Categories = _factory.CreateCategoryObservableCollection();
            _catRepo = _factory.CreateCategoryRepo();
            NewCategory = GetNewCategory();
            CloseAddDialogEventSubscribe();
        }
        //generate a part of a new category entity,  
        //this will be send to the form as some initial data fields
        //to allow Model Validation-based check input
        private Category GetNewCategory()
        {
            return new Category()
            {
                Name = "Категория"
            };
        }
        private ICommand _addCatCmd = null;
        public ICommand AddCatCmd =>

             _addCatCmd ?? (_addCatCmd = new AddCatCommand(_factory));

        private void CloseAddDialogEventSubscribe()
        {
            if (AddCatCmd != null)
            {
                ((AddCatCommand)AddCatCmd).CloseDialog +=
                    (object sender, EventArgs e) => DialogResult = true;
            }
        }
    }
}
