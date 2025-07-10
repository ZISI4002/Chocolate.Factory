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
    public class OpenSaveProductsCommand : ICommand
    {
        private readonly ProductViewModel _viewModel;

        public OpenSaveProductsCommand(ProductViewModel viewModel)
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
            SaveProductWindow window = new SaveProductWindow();
            SaveProductViewModel viewModel=new SaveProductViewModel(window,_viewModel);
            window.DataContext = viewModel;

            window.ShowDialog();
        }
    }
}
