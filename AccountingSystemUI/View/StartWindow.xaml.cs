using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using AccountingSystemUI.ViewModel;
using System.Collections.Generic;

namespace AccountingSystemUI.View
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        StartWindowVM startWindowVM;

        public StartWindow()
        {
            startWindowVM = new StartWindowVM();
            this.DataContext = startWindowVM;
            InitializeComponent();
            //
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            startWindowVM.Start();
        }


    }
}
