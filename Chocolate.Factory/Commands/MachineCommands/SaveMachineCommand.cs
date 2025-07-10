using Chocolate.Factory.Core.Domain.Entities;
using Chocolate.Factory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.MachineCommands
{
    public class SaveMachineCommand : ICommand
    {
        private readonly SaveMachineViewModel _viewModel;

        public SaveMachineCommand(SaveMachineViewModel viewModel)
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
            Machine machine = new Machine
            {
                Id = _viewModel.MachineModel.Id,
                MachineType = _viewModel.MachineModel.MachineType,
                BrandName = _viewModel.MachineModel.BrandName,
                SerialNumber = _viewModel.MachineModel.SerialNumber,
                HourlyElectricWaste = _viewModel.MachineModel.HourlyElectricWaste,
                UsePeriod = _viewModel.MachineModel.UsePeriod,
                PurchaseDate = _viewModel.MachineModel.PurchaseDate,
            };
            // Проверка на пустые/некорректные поля
            if (
                string.IsNullOrWhiteSpace(machine.BrandName) ||
                string.IsNullOrWhiteSpace(machine.SerialNumber) ||
                machine.MachineType<=0 ||
                machine.HourlyElectricWaste <= 0 ||
                machine.UsePeriod <= 0 ||
                machine.PurchaseDate == null)
            {
                MessageBox.Show("Please make sure all machine fields are filled correctly before saving.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            if (machine.Id > 0)
            {
                ApplicationContext.UnitOfWork.MachineRepository.Update(machine);
                _viewModel.Window.Close();
                return;
            }

            ApplicationContext.UnitOfWork.MachineRepository.Add(machine);

            _viewModel.MachineModel.Id = machine.Id;
            _viewModel.MachinesViewModel.MachineModels.Add(_viewModel.MachineModel);
            _viewModel.Window.Close();
        }
    }

}
