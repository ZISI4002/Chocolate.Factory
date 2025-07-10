using Chocolate.Factory.ViewModels;
using Chocolate.Factory.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.DosageCommands
{
    public class OpenAddDosageCommand : ICommand
    {
        private readonly DosageViewModel _viewModel;

        public OpenAddDosageCommand(DosageViewModel viewModel)
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

            SaveDosageWindow window = new SaveDosageWindow();
            SaveDosageViewModel viewModel = new SaveDosageViewModel(window, _viewModel);

            window.DataContext = viewModel;

            window.ShowDialog();
        }
    }
}
