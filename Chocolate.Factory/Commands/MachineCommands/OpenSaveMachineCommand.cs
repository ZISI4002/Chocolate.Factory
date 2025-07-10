using Chocolate.Factory.ViewModels;
using Chocolate.Factory.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.MachineCommands
{
    public class OpenSaveMachineCommand : ICommand
    {
        private readonly MachineViewModel _viewModel;

        public OpenSaveMachineCommand(MachineViewModel viewModel)
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
            SaveMachineWindow window = new SaveMachineWindow();
            SaveMachineViewModel viewModel = new SaveMachineViewModel(window, _viewModel);
            window.DataContext = viewModel;
            window.ShowDialog();
        }
    }
}
