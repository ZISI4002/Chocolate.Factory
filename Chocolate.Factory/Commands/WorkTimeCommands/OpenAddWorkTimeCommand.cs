using Chocolate.Factory.ViewModels;
using Chocolate.Factory.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.WorkTimeCommands
{
    public class OpenAddWorkTimeCommand : ICommand
    {
        private readonly WorkTimeViewModel _viewModel;

        public OpenAddWorkTimeCommand(WorkTimeViewModel viewModel)
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
            SaveWorkTimeWindow window = new SaveWorkTimeWindow();
            SaveWorkTimeViewModel viewModel = new SaveWorkTimeViewModel(window, _viewModel);

            window.DataContext = viewModel;

            window.ShowDialog();
        }
    }

}
