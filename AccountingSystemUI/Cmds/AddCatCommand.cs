using System.Collections.Generic;
using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using System.Windows;
using System.Linq;
using System;
using AccountingSystemUI.DI;

namespace AccountingSystemUI.Cmds
{
    public class AddCatCommand : CommandBase
    {
        private IRepo<Category> _catRepo;

        private IList<Category> _categories;

        public event EventHandler CloseDialog;
        private readonly IFactory _factory;

        public AddCatCommand(IFactory factory, IList<Category> categories)
        {
            _factory = factory;
            _catRepo = _factory.CreateCategoryRepo();
            _categories = categories;
            CheckNullInputParams(_catRepo, _categories);
        }

        public override void Execute(object parameter)
        {
            var category = parameter as Category;
            if (!IsExist(category))
            {
                _catRepo.Add(category);
                _categories.Add(category);
                CloseDialog?.Invoke(this, new EventArgs());
            }
            else
            {
                MessageBox.Show(
                         $"Категория \"{category}\"\n" +
                         $"уже содержится в базе\n\n",
                         "Дублирование данных",
                         MessageBoxButton.OK,
                         MessageBoxImage.Information
                         );
            }
        }

        public override bool CanExecute(object parameter)
        {
            return (parameter as Category) != null
                //todo: удалить эту строку и разобраться валидацией текстового поля
                && !string.IsNullOrEmpty(((Category)parameter).Name)

                && !((Category)parameter).HasErrors
                && _categories != null;
        }
        private void CheckNullInputParams(object catRepo, object categories)
        {
            if (catRepo == null || categories == null)
            {
                MessageBox.Show(
                         "Непредвиденные данные контекста",
                         "Ошибка",
                         MessageBoxButton.OK,
                         MessageBoxImage.Exclamation
                         );
                CloseDialog?.Invoke(this, new EventArgs());
            }
        }
        private bool IsExist(Category category)
        {
            return _categories.Any(c => c.Name == category.Name);
        }
    }
}
