using Chocolate.Factory.Commands.WorkTimeCommands;
using Chocolate.Factory.Core.Domain.Entities;
using Chocolate.Factory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chocolate.Factory.ViewModels
{
    public class SaveWorkTimeViewModel : BaseWindowViewModel
    {
        public SaveWorkTimeViewModel(Window window, WorkTimeViewModel workTimeViewModel) : base(window)
        {

            List<Machine> machines = ApplicationContext.UnitOfWork.MachineRepository.GetAll();

            List<int> startHours  = Enumerable.Range(0, 24).ToList();
            List<int> startMinutes  = Enumerable.Range(0, 60).ToList();
            List<int> stopHours = Enumerable.Range(0, 24).ToList();
            List<int> stopMinutes = Enumerable.Range(0, 60).ToList();

            this.Machines = machines.Select(x => new MachineModel
            {   Id = x.Id,                             
                MachineType = x.MachineType,           
                BrandName = x.BrandName,               
                SerialNumber = x.SerialNumber,         
                HourlyElectricWaste=x.HourlyElectricWaste,
                UsePeriod=x.UsePeriod,
                PurchaseDate=x.PurchaseDate,
            }).ToList();

             this.StartHours = startHours;
            this.StartMinutes = startMinutes;
            this.StopHours = stopHours;
            this.StopMinutes = stopMinutes;

            this.WorkTimeModel = new WorkTimeModel 
            {
                ThisDay=DateTime.Now,
               
            };
            

            WorkTimeViewModel = workTimeViewModel;

            this.SaveWorkTime = new SaveWorkTimeCommand(this);

        }

        public WorkTimeModel WorkTimeModel { get; set; }
        public ICommand SaveWorkTime { get; set; }
      
        public List<MachineModel> Machines { get; set; }
        public List<int> StartHours { get; set; }
        public List<int> StartMinutes { get; set; }
        public List<int> StopHours { get; set; }
        public List<int> StopMinutes { get; set; }

        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public int StopHour { get; set; }
        public int StopMinute { get; set; }
        public int SelectedMachineId { get; set; }

       
        public WorkTimeViewModel WorkTimeViewModel { get; set; }
    }
}
