using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using AccountingSystemUI.ViewModel;

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
            App.Current.Shutdown();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Dispatcher.Invoke(StartAcync);
            //startWindowVM.Start();
            StartAcync();
        }

        private async void StartAcync()
        {
            await Task.Run(() => startWindowVM.Start());
        }

    }
}
