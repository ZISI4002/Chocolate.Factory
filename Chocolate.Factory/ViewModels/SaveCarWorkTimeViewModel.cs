using Chocolate.Factory.Commands.CarWorkTimeCommands;
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
    public class SaveCarWorkTimeViewModel : BaseWindowViewModel
    {
        public SaveCarWorkTimeViewModel(Window window, CarWorkTimeViewModel carWorkTimeViewModel) : base(window)
        {
            List<Car> cars = ApplicationContext.UnitOfWork.CarRepository.GetAll();

            List<int> startHours = Enumerable.Range(0, 24).ToList();
            List<int> startMinutes = Enumerable.Range(0, 60).ToList();
            List<int> stopHours = Enumerable.Range(0, 24).ToList();
            List<int> stopMinutes = Enumerable.Range(0, 60).ToList();

            this.Cars = cars.Select(x => new CarModel
            {
                Id = x.Id,
                CarType = x.CarType,
                BrandName = x.BrandName,
                SerialNumber = x.SerialNumber,
                UsePeriod = x.UsePeriod,
                PurchaseDate = x.PurchaseDate,
            }).ToList();

            this.StartHours = startHours;
            this.StartMinutes = startMinutes;
            this.StopHours = stopHours;
            this.StopMinutes = stopMinutes;

            this.CarWorkTimeModel = new CarWorkTimeModel
            {
                ThisDay = DateTime.Now,
            };

            CarWorkTimeViewModel = carWorkTimeViewModel;

            this.SaveCarWorkTime = new SaveCarWorkTimeCommand(this);
        }

        public CarWorkTimeModel CarWorkTimeModel { get; set; }
        public ICommand SaveCarWorkTime { get; set; }

        public List<CarModel> Cars { get; set; }
        public List<int> StartHours { get; set; }
        public List<int> StartMinutes { get; set; }
        public List<int> StopHours { get; set; }
        public List<int> StopMinutes { get; set; }

        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public int StopHour { get; set; }
        public int StopMinute { get; set; }
        public int SelectedCarId { get; set; }

        public CarWorkTimeViewModel CarWorkTimeViewModel { get; set; }
    }

}
