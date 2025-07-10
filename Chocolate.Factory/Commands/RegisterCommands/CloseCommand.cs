using Chocolate.Factory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.RegisterCommands
{
    public class CloseCommand : ICommand
    {
        private readonly RegisterViewModel _viewModel;

        public CloseCommand(RegisterViewModel viewModel)
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
            _viewModel.Window.Close();
        }
    }
}
