using Chocolate.Factory.Core.Domain.Entities;
using Chocolate.Factory.Helper;
using Chocolate.Factory.ViewModels;
using Chocolate.Factory.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.LoginCommands
{
    internal class LoginCommand : ICommand
    {
        private readonly LoginWindowViewModel _viewModel;
        public LoginCommand(LoginWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }   

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string username=_viewModel.LoginModel.Username;
            if (username == null)
            {
                _viewModel.ErrorVisibility = Visibility.Visible;
                return;
            }

            User user=ApplicationContext.UnitOfWork.UserRepository.GetByUsername(username);
              if (user == null)
            {
                _viewModel.ErrorVisibility = Visibility.Visible;
                return;
            } 
               
            string password=((PasswordBox)parameter).Password;
            string passwordHash=HashHelper.Hash(password);
            if (passwordHash == user.PasswordHash)
            {
                AdminWindow adminWindow=new AdminWindow();
                AdminWindowViewModel viewModel=new AdminWindowViewModel(adminWindow);
                adminWindow.DataContext = viewModel;
                //Somthing different from all pages
                viewModel.CenterGrid = adminWindow.grdCenter;
                adminWindow.Show();

                _viewModel.Window.Close();
                return;
            }

            _viewModel.ErrorVisibility = Visibility.Visible;  
        
        }
    }
}
