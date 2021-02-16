using System;
using System.Windows;
using AccountingSystemUI.View;
using AccountingSystemDAL.Repos;
using AccountingSystemDAL.Model;
using AccountingSystemUI.Application;
using Ninject;
using AccountingSystemUI.DI;
using System.Linq;

namespace AccountingSystemUI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        //test git stashes 3
        StartWindow startWindow;

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            ///test git master 4
            App.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            var ninjectKernel = new StandardKernel();
            ninjectKernel.Load(new CommonModule());
            startWindow = new StartWindow(ninjectKernel.Get<IFactory>());
            startWindow.Show();
        }
    }
}


