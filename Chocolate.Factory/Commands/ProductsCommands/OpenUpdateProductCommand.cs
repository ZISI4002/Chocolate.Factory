using Chocolate.Factory.ViewModels;
using Chocolate.Factory.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.ProductsCommands
{
    public class OpenUpdateProductCommand : ICommand
    {
        private readonly ProductViewModel _viewModel;

        public OpenUpdateProductCommand(ProductViewModel viewModel)
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
            SaveProductWindow saveProduct = new SaveProductWindow();
            SaveProductViewModel viewModel = new SaveProductViewModel(saveProduct, _viewModel);
            saveProduct.DataContext = viewModel;
            //the difference in update
            viewModel.ProductModel = _viewModel.ProductModels[_viewModel.SelectedProductIndex];

            saveProduct.ShowDialog();
        }
    }
}
