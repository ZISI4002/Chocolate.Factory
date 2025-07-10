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
    public class OpenUpdateMachineCommand : ICommand
    {
        private readonly MachineViewModel _viewModel;

        public OpenUpdateMachineCommand(MachineViewModel viewModel)
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
            SaveMachineWindow saveMachine = new SaveMachineWindow();
            SaveMachineViewModel viewModel = new SaveMachineViewModel(saveMachine, _viewModel);
            saveMachine.DataContext = viewModel;
            //the difference in update
            viewModel.MachineModel = _viewModel.MachineModels[_viewModel.SelectedMachineIndex];

            saveMachine.ShowDialog();
        }
    }
}
