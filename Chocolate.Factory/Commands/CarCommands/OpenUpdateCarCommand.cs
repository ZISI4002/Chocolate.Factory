using Chocolate.Factory.ViewModels;
using Chocolate.Factory.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.CarCommands
{
    public class OpenUpdateCarCommand : ICommand
    {
        private readonly CarViewModel _viewModel;

        public OpenUpdateCarCommand(CarViewModel viewModel)
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
            SaveCarWindow saveCar = new SaveCarWindow();
            SaveCarViewModel viewModel = new SaveCarViewModel(saveCar, _viewModel);
            saveCar.DataContext = viewModel;
            //the difference in update
            viewModel.CarModel = _viewModel.CarModels[_viewModel.SelectedCarIndex];

            saveCar.ShowDialog();
        }
    }

}
