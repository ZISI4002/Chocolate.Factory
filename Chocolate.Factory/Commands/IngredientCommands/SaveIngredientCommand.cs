using Chocolate.Factory.Core.Domain.Entities;
using Chocolate.Factory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.IngredientCommands
{
    public class SaveIngredientCommand : ICommand
    {
        private readonly SaveIngredientViewModel _viewModel;

        public SaveIngredientCommand(SaveIngredientViewModel viewModel)
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
            Ingredient ingredient = new Ingredient
            {
                Id = _viewModel.IngredientModel.Id,
                Name = _viewModel.IngredientModel.Name,
                UseTime = _viewModel.IngredientModel.UseTime,
                InStock = _viewModel.IngredientModel.InStock,
                
            };

            // Проверка на пустоту
            if (string.IsNullOrWhiteSpace(ingredient.Name) ||
                ingredient.UseTime <= 0 ||
                ingredient.InStock <= 0)
            {
                MessageBox.Show("Please fill in all the fields before saving.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (ingredient.Id > 0)
            {
                ApplicationContext.UnitOfWork.IngredientRepository.Update(ingredient);
                _viewModel.Window.Close();
                return;
            }

            ApplicationContext.UnitOfWork.IngredientRepository.Add(ingredient);

            _viewModel.IngredientModel.Id = ingredient.Id;
            _viewModel.IngredientsViewModel.IngredientModels.Add(_viewModel.IngredientModel);
            _viewModel.Window.Close();
        }
    }
}
