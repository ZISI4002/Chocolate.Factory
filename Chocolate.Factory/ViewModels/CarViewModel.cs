using Chocolate.Factory.Commands.CarCommands;
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
    public class CarViewModel
    {
        public CarViewModel()
        {
            List<Car> cars = ApplicationContext.UnitOfWork.CarRepository.GetAll();

            CarModels = new ObservableCollection<CarModel>();

            foreach (Car car in cars)
            {
                CarModel model = new CarModel
                {
                    Id = car.Id,
                    CarType = car.CarType,
                    BrandName = car.BrandName,
                    SerialNumber = car.SerialNumber,
                    UsePeriod = car.UsePeriod,
                    PurchaseDate = car.PurchaseDate
                };

                CarModels.Add(model);
            }

            this.OpenSaveCar = new OpenSaveCarCommand(this);
            this.OpenUpdateCar = new OpenUpdateCarCommand(this);
            this.DeleteCar = new DeleteCarCommand(this);
            this.ExportCar = new ExportCarCommand(this);
        }

        public ObservableCollection<CarModel> CarModels { get; set; }
        public ICommand OpenSaveCar { get; set; }
        public ICommand OpenUpdateCar { get; set; }
        public ICommand DeleteCar { get; set; }
        public ICommand ExportCar { get; set; }
        public int SelectedCarIndex { get; set; }
    }

}
