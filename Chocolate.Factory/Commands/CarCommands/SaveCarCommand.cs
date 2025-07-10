using Chocolate.Factory.Core.Domain.Entities;
using Chocolate.Factory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.CarCommands
{
    public class SaveCarCommand : ICommand
    {
        private readonly SaveCarViewModel _viewModel;

        public SaveCarCommand(SaveCarViewModel viewModel)
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
            Car car = new Car
            {
                Id = _viewModel.CarModel.Id,
                CarType = _viewModel.CarModel.CarType,
                BrandName = _viewModel.CarModel.BrandName,
                SerialNumber = _viewModel.CarModel.SerialNumber,
                UsePeriod = _viewModel.CarModel.UsePeriod,
                PurchaseDate = _viewModel.CarModel.PurchaseDate,
            };

            // Проверка на обязательные поля
            if (car.CarType <= 0 ||
                string.IsNullOrWhiteSpace(car.BrandName) ||
                string.IsNullOrWhiteSpace(car.SerialNumber) ||
                car.UsePeriod <= 0 ||
                car.PurchaseDate == null)
            {
                MessageBox.Show("Please make sure all car fields are filled correctly before saving.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (car.Id > 0)
            {
                ApplicationContext.UnitOfWork.CarRepository.Update(car);
                _viewModel.Window.Close();
                return;
            }

            ApplicationContext.UnitOfWork.CarRepository.Add(car);

            _viewModel.CarModel.Id = car.Id;
            _viewModel.CarsViewModel.CarModels.Add(_viewModel.CarModel);
            _viewModel.Window.Close();
        }
    }

}
