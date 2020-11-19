﻿using System.Windows;
using AccountingSystemUI.View;
using Ninject;
using AccountingSystemUI.DI;

namespace AccountingSystemUI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        StartWindow startWindow;

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            App.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            var ninjectKernel = new StandardKernel();
            ninjectKernel.Load(new CommonModule());
            startWindow = new StartWindow(ninjectKernel.Get<IFactory>());
            startWindow.Show();
        }
    }
}


