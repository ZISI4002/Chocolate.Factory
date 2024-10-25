using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Chocolate.Factory.Helper;
using Chocolate.Factory.Models;
using Chocolate.Factory.ViewModels;
using Chocolate.Factory.Views;
using Newtonsoft.Json;

namespace Chocolate.Factory.Commands.ConfigurationCommands
{
    public class SaveCommand : ICommand
    { 
        private readonly ConfigurationViewModel _viewModel;

        public SaveCommand(ConfigurationViewModel viewModel)
        {
            _viewModel= viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
             string password=((PasswordBox)parameter).Password;
            ConfigurationInfo configuration = new ConfigurationInfo()
            {
                

                ServerName = _viewModel.Configuration.ServerName,
                DatabaseName = _viewModel.Configuration.DatabaseName,
                DatabaseType = _viewModel.Configuration.DatabaseType,
                Password = password,
                Username = _viewModel.Configuration.Username,
                WindowsAuthentication = _viewModel.Configuration.WindowsAuthentication
            };


           ConfigurationHelper.Write(configuration);

          WindowStart windowStart= new WindowStart();
            windowStart.Show();

            _viewModel.Window.Close();


        }

       
    }
}
