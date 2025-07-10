using Chocolate.Factory.Models;
using Chocolate.Factory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Chocolate.Factory.Commands.CarWorkTimeCommands
{
    public class DeleteCarWorkTimeCommand : ICommand
    {
        private readonly CarWorkTimeViewModel _viewModel;

        public DeleteCarWorkTimeCommand(CarWorkTimeViewModel viewModel)
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

            CarWorkTimeModel model = _viewModel.CarWorkTimeModels[_viewModel.SelectedCarWorkTimeIndex];

            if (model == null)
            {
                return;
            }

            ApplicationContext.UnitOfWork.CarWorkTimeRepository.Delete(model.Id);
            _viewModel.CarWorkTimeModels.Remove(model);
        }
    }
}
