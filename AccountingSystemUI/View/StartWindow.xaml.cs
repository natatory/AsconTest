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
        IList<string> msgs;

        public StartWindow()
        {
            startWindowVM = new StartWindowVM();
            this.DataContext = startWindowVM;
            msgs = startWindowVM.Messages;
            InitializeComponent();
            //
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //StartAcync();
            startWindowVM.Start();
            lstbxMsg.ItemsSource = msgs;
        }

        private async void StartAcync()
        {
            await Task.Run(() => startWindowVM.Start());
        }

    }
}
