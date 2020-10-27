using AccountingSystemDAL.Repos;
using AccountingSystemDAL.Model;
using AccountingSystemUI.Application;
using AccountingSystemUI.Cmds;
using Ninject.Modules;
using Ninject.Extensions.Factory;


namespace AccountingSystemUI.DI
{
    class CommonModule : NinjectModule
    {
         
        public override void Load()
        {

            Bind<IRepo<User>>().To<UserRepo>().InScope(x=>App.Current);
            Bind<IRepo<Category>>().To<CategoryRepo>().InScope(x => App.Current);
            Bind<IRepo<Data>>().To<DataRepo>().InScope(x => App.Current);
            Bind<IRepo<Recipient>>().To<RecipientRepo>().InScope(x => App.Current);

            //Bind<IList<Category>>().ToConstructor(ctx =>
            //    new ObservableCollection<Category>(ctx.Context.Kernel.Get<IRepo<Category>>().GetAll()));
            //Bind<IList<Recipient>>().ToConstructor(ctx =>
            //    new ObservableCollection<Recipient>(ctx.Inject<IRepo<Recipient>>().GetAll()));
            //Bind<IList<User>>().ToConstructor(ctx =>
            //    new ObservableCollection<User>(ctx.Context.Kernel.Get<IRepo<User>>().GetAll()));
            //Bind<IList<Data>>().ToConstructor(ctx =>
            //    new ObservableCollection<Data>(ctx.Context.Kernel.Get<IRepo<Data>>().GetAll()));

            Bind<IWinHelper>().To<WinHelper>().InScope(x => App.Current);
            Bind<IDBInteract>().To<DBInteract>().InScope(x => App.Current);
            Bind<IExcelExporter>().To<ExcelExporter>().InScope(x => App.Current);

            Bind<IFactory>().ToFactory().InScope(x=>App.Current);
        }
    }
}
