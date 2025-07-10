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
using static System.IdentityModel.Tokens.SecurityTokenHandlerCollectionManager;

namespace Chocolate.Factory.Commands.WorkTimeCommands
{
    public class SaveWorkTimeCommand : ICommand
    {
        private readonly SaveWorkTimeViewModel _viewModel;
        public SaveWorkTimeCommand(SaveWorkTimeViewModel viewModel)
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
             MachineModel machine = _viewModel.Machines.FirstOrDefault(p => p.Id == _viewModel.SelectedMachineId);

           

            // Проверка обязательных полей
            if (_viewModel.WorkTimeModel.ThisDay == null ||
                _viewModel.StartHour < 0 || _viewModel.StartHour > 23 ||
                _viewModel.StartMinute < 0 || _viewModel.StartMinute > 59 ||
                _viewModel.StopHour <= 0 || _viewModel.StopHour > 23 ||
                _viewModel.StopMinute < 0 || _viewModel.StopMinute > 59 ||
                _viewModel.WorkTimeModel.Production <= 0)
            {
                MessageBox.Show("Please ensure all fields are filled correctly before saving.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            WorkTime worktime= new WorkTime { 
            
                ThisDay=_viewModel.WorkTimeModel.ThisDay,
                StartTime = new TimeSpan(_viewModel.StartHour,_viewModel.StartMinute, 0),
                StopTime = new TimeSpan(_viewModel.StopHour, _viewModel.StopMinute, 0),
                Production=_viewModel.WorkTimeModel.Production,
                IsInspected=_viewModel.WorkTimeModel.IsInspected,

               Machine =new Machine
               {
                  Id=machine.Id,
                  MachineType=machine.MachineType,
                  BrandName=machine.BrandName,
                  SerialNumber=machine.SerialNumber,
                  HourlyElectricWaste=machine.HourlyElectricWaste,
                  UsePeriod=machine.UsePeriod,
                  PurchaseDate=machine.PurchaseDate,
               }
            };

            // Добавить SerialNumber в WorkTimeModel для сохранения
            _viewModel.WorkTimeModel.MachineSerialNumber = machine.SerialNumber;
            ApplicationContext.UnitOfWork.WorkTimeRepository.Add(worktime);



            _viewModel.WorkTimeModel.Id = worktime.Id;


            _viewModel.WorkTimeViewModel.WorkTimeModels
               .Add(new WorkTimeModel
               {
                  Id = worktime.Id,
                  ThisDay=worktime.ThisDay,
                  StartTime=worktime.StartTime,
                  StopTime=worktime.StopTime,
                  Production=worktime.Production,
                  IsInspected=worktime.IsInspected,
                  MachineSerialNumber=worktime.Machine.SerialNumber,
               });

            _viewModel.Window.Close();
           
        }
    }
}
