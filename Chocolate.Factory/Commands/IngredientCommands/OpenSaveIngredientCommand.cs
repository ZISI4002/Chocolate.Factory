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
    public class OpenSaveIngredientCommand : ICommand
    {
        private readonly IngredientViewModel _viewModel;

        public OpenSaveIngredientCommand(IngredientViewModel viewModel)
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
            SaveIngredientWindow window = new SaveIngredientWindow();
            SaveIngredientViewModel viewModel = new SaveIngredientViewModel(window, _viewModel);
            window.DataContext = viewModel;

            window.ShowDialog();

            
        }
    }
}
