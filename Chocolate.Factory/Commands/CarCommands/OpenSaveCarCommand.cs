using Chocolate.Factory.ViewModels;
using Chocolate.Factory.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.CarCommands
{
    public class OpenSaveCarCommand : ICommand
    {
        private readonly CarViewModel _viewModel;

        public OpenSaveCarCommand(CarViewModel viewModel)
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
            SaveCarWindow window = new SaveCarWindow();
            SaveCarViewModel viewModel = new SaveCarViewModel(window, _viewModel);
            window.DataContext = viewModel;
            window.ShowDialog();
        }
    }

}
