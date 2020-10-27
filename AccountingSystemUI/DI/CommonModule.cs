using System.Collections.Generic;
using AccountingSystemDAL.Repos;
using AccountingSystemDAL.Model;
using Ninject.Modules;
using Ninject.Extensions.Factory;
using AccountingSystemUI.Application;
using System.Collections.ObjectModel;
using AccountingSystemUI.Cmds;
using Ninject.Syntax;
using Ninject;

namespace AccountingSystemUI.DI
{
    class CommonModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepo<User>>().To<UserRepo>();
            Bind<IRepo<Category>>().To<CategoryRepo>();
            Bind<IRepo<Data>>().To<DataRepo>();
            Bind<IRepo<Recipient>>().To<RecipientRepo>();

            /// this not work..
            Bind<IList<Category>>().ToConstructor(ctx =>
                new ObservableCollection<Category>(ctx.Inject<IRepo<Category>>().GetAll()));
            Bind<IList<Recipient>>().ToConstructor(ctx =>
                new ObservableCollection<Recipient>(ctx.Inject<IRepo<Recipient>>().GetAll()));
            Bind<IList<User>>().ToConstructor(ctx =>
                new ObservableCollection<User>(ctx.Inject<IRepo<User>>().GetAll()));
            Bind<IList<Data>>().ToConstructor(ctx =>
                new ObservableCollection<Data>(ctx.Inject<IRepo<Data>>().GetAll()));

            Bind<IWinHelper>().To<WinHelper>();
            Bind<IDBInteract>().To<DBInteract>();
            Bind<IExcelExporter>().To<ExcelExporter>();


            Bind<IFactory>().ToFactory();
        }
        //private IList<T> GetObservableCollection<T>(IRepo<T> repo)
        //{
        //    return new ObservableCollection<T>(repo.GetAll());
        //}
    }
}
