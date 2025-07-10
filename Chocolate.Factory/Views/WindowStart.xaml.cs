using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Chocolate.Factory.ViewModels;

namespace Chocolate.Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для WindowStart.xaml
    /// </summary>
    public partial class WindowStart : Window
    {
        public WindowStart()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                ApplicationContext.Initialize();

                this.CheckServer();
            });
        }

        private async void CheckServer()
        {
            await Task.Delay(2000);

            if (ApplicationContext.UnitOfWork.CheckConnection())
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoginWindow window = new LoginWindow();
                    LoginWindowViewModel loginWindowViewModel = new LoginWindowViewModel(window);
                    window.DataContext = loginWindowViewModel;
                    window.Show();
                    this.Close();
                });
                        return;
               
            }

            Application.Current.Dispatcher.Invoke(() =>
            {
                ConfigurationWindows window = new ConfigurationWindows();
                ConfigurationViewModel viewModel = new ConfigurationViewModel(window);
                window.DataContext = viewModel;
                window.Show();

                this.Close();
            });
            
           

        }
    }
}
