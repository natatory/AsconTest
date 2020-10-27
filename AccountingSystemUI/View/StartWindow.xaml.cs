using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using AccountingSystemUI.ViewModel;
using System.Collections.Generic;
using AccountingSystemUI.DI;

namespace AccountingSystemUI.View
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        StartWindowVM startWindowVM;
        private readonly IFactory _repoFactory;

        public StartWindow(IFactory repoFactory)
        {
            _repoFactory = repoFactory;
            startWindowVM = new StartWindowVM(_repoFactory);
            this.DataContext = startWindowVM;
            InitializeComponent();
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
