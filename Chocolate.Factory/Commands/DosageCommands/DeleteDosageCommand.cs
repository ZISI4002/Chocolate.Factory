using Chocolate.Factory.Models;
using Chocolate.Factory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.DosageCommands
{
    public class DeleteDosageCommand : ICommand
    {
        private readonly DosageViewModel _viewModel;

        public DeleteDosageCommand(DosageViewModel viewModel)
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
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Delete ", MessageBoxButton.YesNoCancel, MessageBoxImage
                           .Warning, MessageBoxResult.No);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }

            DosageModel model = _viewModel.DosageModels[_viewModel.SelectedDosageId];

            if (model == null)
            {
                return;
            }

            ApplicationContext.UnitOfWork.DosageRepository.Delete(model.Id);
            _viewModel.DosageModels.Remove(model);
        }
    }
}
