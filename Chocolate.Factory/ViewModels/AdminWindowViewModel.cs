using Chocolate.Factory.Commands.AdminCommands;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chocolate.Factory.ViewModels
{
    public class AdminWindowViewModel : BaseWindowViewModel
    {
        public AdminWindowViewModel(Window window) : base(window)
        {
            this.OpenProducts = new OpenProductCommand(this);
            this.OpenIngredients=new OpenIngredientCommand(this);
            this.OpenDosages=new OpenDosageCommand(this);
            this.OpenMachines=new OpenMachineCommand(this);
            this.OpenWorkTimes=new OpenWorkTimesCommand(this);  
            this.OpenCars=new OpenCarsCommand(this);
            this.OpenCarWorkTimes=new OpenCarWorkTimesCommand(this);
            this.CloseWindowCommand = new CloseWindowCommand(this);
        }

       

        public ICommand OpenProducts {  get; set; }
        public ICommand OpenIngredients { get; set; }
        public ICommand OpenDosages { get; set; }
        public ICommand OpenMachines { get; set; }
        public ICommand OpenWorkTimes { get; set; }
        public ICommand OpenCars { get; set; }
        public ICommand OpenCarWorkTimes { get; set; }
        public ICommand CloseWindowCommand { get; set; }
        public Grid CenterGrid { get; set; }



        
    }
}
