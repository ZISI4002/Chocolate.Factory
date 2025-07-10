using Chocolate.Factory.Commands.CarCommands;
using Chocolate.Factory.Core.Domain.Enums;
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
    public class SaveCarViewModel : BaseWindowViewModel
    {
        public SaveCarViewModel(Window window, CarViewModel carViewModel) : base(window)
        {

            this.CarModel = new CarModel
            {
                PurchaseDate = DateTime.Now
            };

            this.CarTypes = Enum.GetValues(typeof(CarType))
                .Cast<CarType>().ToList();

            this.CarsViewModel = carViewModel;
            this.SaveCar = new SaveCarCommand(this);
        }

        public CarModel CarModel { get; set; }
        public ICommand SaveCar { get; set; }
        public List<CarType> CarTypes { get; set; }
        public CarViewModel CarsViewModel { get; set; }
    }

}
