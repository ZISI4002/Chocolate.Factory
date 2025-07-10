using Chocolate.Factory.Core.Domain.Entities;
using Chocolate.Factory.Models;
using Chocolate.Factory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.CarWorkTimeCommands
{
    public class SaveCarWorkTimeCommand : ICommand
    {
        private readonly SaveCarWorkTimeViewModel _viewModel;

        public SaveCarWorkTimeCommand(SaveCarWorkTimeViewModel viewModel)
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
            CarModel car = _viewModel.Cars.FirstOrDefault(p => p.Id == _viewModel.SelectedCarId);

           
            // Проверка на обязательные поля
            if (_viewModel.CarWorkTimeModel.ThisDay == null ||
                _viewModel.StartHour <= 0 || _viewModel.StartHour > 23 ||
                _viewModel.StartMinute < 0 || _viewModel.StartMinute > 59 ||
                _viewModel.StopHour < 0 || _viewModel.StopHour > 23 ||
                _viewModel.StopMinute < 0 || _viewModel.StopMinute > 59 ||
                _viewModel.CarWorkTimeModel.TranslateProduction <= 0 ||
                _viewModel.CarWorkTimeModel.WastedGas <= 0)
            {
                MessageBox.Show("Please ensure all fields are filled correctly before saving.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            CarWorkTime carWorkTime = new CarWorkTime
            {
                ThisDay = _viewModel.CarWorkTimeModel.ThisDay,
                StartTime = new TimeSpan(_viewModel.StartHour, _viewModel.StartMinute, 0),
                StopTime = new TimeSpan(_viewModel.StopHour, _viewModel.StopMinute, 0),
                TranslateProduction = _viewModel.CarWorkTimeModel.TranslateProduction,
                WastedGas = _viewModel.CarWorkTimeModel.WastedGas,
                IsInspected = _viewModel.CarWorkTimeModel.IsInspected,

                Car = new Car
                {
                    Id = car.Id,
                    CarType = car.CarType,
                    BrandName = car.BrandName,
                    SerialNumber = car.SerialNumber,
                    UsePeriod = car.UsePeriod,
                    PurchaseDate = car.PurchaseDate,
                }
            };

            // Добавим серийник в модель
            _viewModel.CarWorkTimeModel.CarSerialNumber = car.SerialNumber;

            ApplicationContext.UnitOfWork.CarWorkTimeRepository.Add(carWorkTime);

            _viewModel.CarWorkTimeModel.Id = carWorkTime.Id;

            _viewModel.CarWorkTimeViewModel.CarWorkTimeModels.Add(new CarWorkTimeModel
            {
                Id = carWorkTime.Id,
                ThisDay = carWorkTime.ThisDay,
                StartTime = carWorkTime.StartTime,
                StopTime = carWorkTime.StopTime,
                TranslateProduction = carWorkTime.TranslateProduction,
                WastedGas = carWorkTime.WastedGas,
                IsInspected = carWorkTime.IsInspected,
                CarSerialNumber = carWorkTime.Car.SerialNumber,
            });

            _viewModel.Window.Close();
        }
    }

}
