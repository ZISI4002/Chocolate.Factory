using Chocolate.Factory.Commands.MachineCommands;
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
    public class SaveMachineViewModel : BaseWindowViewModel
    {
        public SaveMachineViewModel(Window window, MachineViewModel machineViewModel) : base(window)
        {

            this.MachineModel = new MachineModel
            {
                PurchaseDate = DateTime.Now
            };

            this.MachinTypes = Enum.GetValues(typeof(MachinType))
               .Cast<MachinType>().ToList();

            this.MachinesViewModel = machineViewModel;
            this.SaveMachine = new SaveMachineCommand(this);
        }

        public MachineModel MachineModel { get; set; }
        public ICommand SaveMachine { get; set; }
        public List<MachinType> MachinTypes { get; set; }
        public MachineViewModel MachinesViewModel { get; set; }
    }

}
