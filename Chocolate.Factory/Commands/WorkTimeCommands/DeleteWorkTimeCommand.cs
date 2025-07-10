using Chocolate.Factory.Models;
using Chocolate.Factory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.WorkTimeCommands
{
    public class DeleteWorkTimeCommand : ICommand
    {
        private readonly WorkTimeViewModel _viewModel;

        public DeleteWorkTimeCommand(WorkTimeViewModel viewModel)
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

            WorkTimeModel model = _viewModel.WorkTimeModels[_viewModel.SelectedWorkTimeIndex];

            if (model == null)
            {
                return;
            }

            ApplicationContext.UnitOfWork.WorkTimeRepository.Delete(model.Id);
            _viewModel.WorkTimeModels.Remove(model);
        }
    }
}
