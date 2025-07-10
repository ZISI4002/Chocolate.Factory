using Chocolate.Factory.Models;
using Chocolate.Factory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Xml.Linq;

namespace Chocolate.Factory.Commands.MachineCommands
{
    public class DeleteMachineCommand : ICommand
    {
        private readonly MachineViewModel _viewModel;

        public DeleteMachineCommand(MachineViewModel viewModel)
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
            MessageBoxResult result = MessageBox.Show("Deleting it will remove all other elements relying on it!", "Are you sure ? ", MessageBoxButton.YesNoCancel, MessageBoxImage
                 .Warning, MessageBoxResult.No);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }

            MachineModel model = _viewModel.MachineModels[_viewModel.SelectedMachineIndex];

            if (model == null)
            {
                return;
            }

            ApplicationContext.UnitOfWork.MachineRepository.Delete(model.Id);
            _viewModel.MachineModels.Remove(model);
        }
    }

}
