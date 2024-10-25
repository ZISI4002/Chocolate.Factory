using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Chocolate.Factory.ViewModels;

namespace Chocolate.Factory.Commands.ConfigurationCommands
{
    internal class CancelCommand:ICommand
    {
        private readonly ConfigurationViewModel _viewModel;

        public CancelCommand(ConfigurationViewModel viewModel)
        {
            _viewModel = viewModel;
        }
         
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.Window.Close();
        }

        public event EventHandler CanExecuteChanged;
    }
}
