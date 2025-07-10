using Chocolate.Factory.Core.Domain.Entities;
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
    public class SaveProductCommand : ICommand
    {
        private readonly SaveProductViewModel _viewModel;

        public SaveProductCommand(SaveProductViewModel viewModel)
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

            Product product = new Product
            {
                Id=_viewModel.ProductModel.Id,
                Name=_viewModel.ProductModel.Name,
                CompanyName=_viewModel.ProductModel.CompanyName,
                StandartWeight=_viewModel.ProductModel.StandartWeight,
                  
            };

            if (string.IsNullOrWhiteSpace(product.Name) ||
            string.IsNullOrWhiteSpace(product.CompanyName) ||
            product.StandartWeight <= 0)
            {
                MessageBox.Show("Please fill in all the fields before saving.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (product.Id > 0)
            {
                ApplicationContext.UnitOfWork.ProductRepository.Update(product);
                _viewModel.Window.Close();
                return;
            }

            

            ApplicationContext.UnitOfWork.ProductRepository.Add(product);




            _viewModel.ProductModel.Id = product.Id;       
            _viewModel.ProductsViewModel.ProductModels.Add(_viewModel.ProductModel);
            _viewModel.Window.Close();

        }
    }
}
