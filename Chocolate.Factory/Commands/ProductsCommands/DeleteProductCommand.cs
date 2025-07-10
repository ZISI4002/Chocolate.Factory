using Chocolate.Factory.Models;
using Chocolate.Factory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.ProductsCommands
{
    public class DeleteProductCommand : ICommand
    {
        private readonly ProductViewModel _viewModel;

        public DeleteProductCommand(ProductViewModel viewModel)
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

            ProductModel model = _viewModel.ProductModels[_viewModel.SelectedProductIndex];

            if (model == null)
            {
                return;
            }

            ApplicationContext.UnitOfWork.ProductRepository.Delete(model.Id);
            _viewModel.ProductModels.Remove(model);
        }
    }
}
