using Chocolate.Factory.Commands.CarWorkTimeCommands;
using Chocolate.Factory.Core.Domain.Entities;
using Chocolate.Factory.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chocolate.Factory.ViewModels
{
    public class CarWorkTimeViewModel
    {
        public CarWorkTimeViewModel()
        {
            List<CarWorkTime> carWorkTimes = ApplicationContext.UnitOfWork.CarWorkTimeRepository.GetAll();

            CarWorkTimeModels = new ObservableCollection<CarWorkTimeModel>();

            foreach (CarWorkTime carWorkTime in carWorkTimes)
            {
                CarWorkTimeModel model = new CarWorkTimeModel
                {
                    Id = carWorkTime.Id,
                    ThisDay = carWorkTime.ThisDay,
                    StartTime = carWorkTime.StartTime,
                    StopTime = carWorkTime.StopTime,
                    TranslateProduction = carWorkTime.TranslateProduction,
                    WastedGas = carWorkTime.WastedGas,
                    IsInspected = carWorkTime.IsInspected,
                     CarSerialNumber=carWorkTime.Car.SerialNumber,
                };

                CarWorkTimeModels.Add(model);
            }

            this.OpenAddCarWorkTime = new OpenAddCarWorkTimeCommand(this);
            this.DeleteCarWorkTime = new DeleteCarWorkTimeCommand(this);
            this.ExportCarWorkTime = new ExportCarWorkTimeCommand(this);
        }

        public ObservableCollection<CarWorkTimeModel> CarWorkTimeModels { get; set; }
        public ICommand OpenAddCarWorkTime { get; set; }
        public ICommand OpenUpdateCarWorkTime { get; set; }
        public ICommand DeleteCarWorkTime { get; set; }
        public ICommand ExportCarWorkTime { get; set; }
        public int SelectedCarWorkTimeIndex { get; set; }
    }

}
