using Chocolate.Factory.ViewModels;
using Chocolate.Factory.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.IngredientCommands
{
    public class OpenUpdateIngredientCommand : ICommand
    {
        private readonly IngredientViewModel _viewModel;

        public OpenUpdateIngredientCommand(IngredientViewModel viewModel)
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
            SaveIngredientWindow saveIngredient = new SaveIngredientWindow();
            SaveIngredientViewModel viewModel = new SaveIngredientViewModel(saveIngredient, _viewModel);
            saveIngredient.DataContext = viewModel;
            //the difference in update
            viewModel.IngredientModel = _viewModel.IngredientModels[_viewModel.SelectedIngredientIndex];

            saveIngredient.ShowDialog();
        }
    }
}
