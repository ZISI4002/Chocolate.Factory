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

        private  void WindowLoaded(object sender, RoutedEventArgs e)
        {

            Task.Run(() =>
            {
                this.CheckServer();

                ApplicationContext.Initialize();

            });
        }

        private void CheckServer()
        {
            if (ApplicationContext.UnitOfWork.CheckConnection())
            {
                //TODO:open login window
                return;
            }

            Application.Current.Dispatcher.Invoke(() => 
            { 
                ConfigurationWindows windows = new ConfigurationWindows();
                ConfigurationViewModel viewModel = new ConfigurationViewModel();
                viewModel.Window = windows;
                windows.DataContext= viewModel;
                windows.DataContext = new ConfigurationViewModel();
                windows.Show();

                this.Close();
            });


           
        }




    }
}
