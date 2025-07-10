using Chocolate.Factory.Core.Domain.Entities;
using Chocolate.Factory.Models;
using Chocolate.Factory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.DosageCommands
{
    public class SaveDosageCommand : ICommand
    {
        private readonly SaveDosageViewModel _viewModel;

        public SaveDosageCommand(SaveDosageViewModel viewModel)
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
            ProductModel product = _viewModel.Products.FirstOrDefault(p => p.Id == _viewModel.SelectedProductId);

            IngredientModel ingredient = _viewModel.Ingredients.FirstOrDefault(i => i.Id == _viewModel.SelectedIngredientId);

            // Проверка на null, если продукт или ингредиент не выбраны
            if (product == null || ingredient == null)
            {
                System.Windows.MessageBox.Show("Please select a product and an ingredient before saving.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Дополнительные проверки на поля Dosage перед созданием
            if (string.IsNullOrWhiteSpace(product.Name) || product.StandartWeight <= 0 ||
                string.IsNullOrWhiteSpace(ingredient.Name) || ingredient.InStock <= 0 || ingredient.UseTime <= 0 ||
                _viewModel.SelectedQuantity <= 0 || _viewModel.SelectedDeviation <= 0)
            {
                System.Windows.MessageBox.Show("Please ensure all required fields are filled correctly.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Dosage dosage = new Dosage
            { 

                Product = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    CompanyName = product.CompanyName,
                    StandartWeight = product.StandartWeight,
                },
                Ingredient = new Ingredient
                {
                    Id = ingredient.Id,
                    Name = ingredient.Name,
                    InStock = ingredient.InStock,
                    UseTime = ingredient.UseTime,
                    
                },
                
                  Quantity = _viewModel.SelectedQuantity,
                  Deviation = _viewModel.SelectedDeviation 
              };

            ApplicationContext.UnitOfWork.DosageRepository.Add(dosage);


            _viewModel.BaseViewModel.DosageModels
                .Add(new DosageModel
                {
                    Id = dosage.Id,
                    Quantity = _viewModel.SelectedQuantity, 
                    Deviation = _viewModel.SelectedDeviation,
                    ProductName = product.Name,
                    IngredientName = ingredient.Name,
                });

            _viewModel.Window.Close();
        }
    }
}