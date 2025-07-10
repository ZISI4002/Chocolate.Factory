using Chocolate.Factory.ViewModels;
using Chocolate.Factory.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.CarWorkTimeCommands
{
    public class OpenAddCarWorkTimeCommand : ICommand
    {
        private readonly CarWorkTimeViewModel _viewModel;

        public OpenAddCarWorkTimeCommand(CarWorkTimeViewModel viewModel)
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
            SaveCarWorkTimeWindow window = new SaveCarWorkTimeWindow();
            SaveCarWorkTimeViewModel viewModel = new SaveCarWorkTimeViewModel(window, _viewModel);

            window.DataContext = viewModel;

            window.ShowDialog();
        }
    }

}
