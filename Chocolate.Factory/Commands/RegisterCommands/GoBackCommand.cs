using Chocolate.Factory.ViewModels;
using Chocolate.Factory.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.RegisterCommands
{
    public class GoBackCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly RegisterViewModel _viewModel;

        public GoBackCommand(RegisterViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;    
        }

        public void Execute(object parameter)
        {
            LoginWindow window = new LoginWindow();
            LoginWindowViewModel viewModel = new LoginWindowViewModel(window);
            window.DataContext = viewModel;
            window.Show();
            _viewModel.Window.Close();
        }
    }
}
