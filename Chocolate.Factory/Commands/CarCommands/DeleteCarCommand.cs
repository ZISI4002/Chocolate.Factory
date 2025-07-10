using Chocolate.Factory.Models;
using Chocolate.Factory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Chocolate.Factory.Commands.CarCommands
{
    public class DeleteCarCommand : ICommand
    {
        private readonly CarViewModel _viewModel;

        public DeleteCarCommand(CarViewModel viewModel)
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
            MessageBoxResult result = MessageBox.Show("Deleting it will remove all other elements relying on it!", "Are you sure?", MessageBoxButton.YesNoCancel, MessageBoxImage
                 .Warning, MessageBoxResult.No);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }

            CarModel model = _viewModel.CarModels[_viewModel.SelectedCarIndex];

            if (model == null)
            {
                return;
            }

            ApplicationContext.UnitOfWork.CarRepository.Delete(model.Id);
            _viewModel.CarModels.Remove(model);
        }
    }

}
