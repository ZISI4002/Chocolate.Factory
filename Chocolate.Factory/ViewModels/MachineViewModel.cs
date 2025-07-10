using Chocolate.Factory.Commands.MachineCommands;
using Chocolate.Factory.Commands.ProductsCommands;
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
    public class MachineViewModel
    {
        public MachineViewModel()
        {
            List<Machine> machines = ApplicationContext.UnitOfWork.MachineRepository.GetAll();

            MachineModels = new ObservableCollection<MachineModel>();
            foreach (Machine machine in machines)
            {
                MachineModel model = new MachineModel
                {
                    Id = machine.Id,
                    MachineType=machine.MachineType,
                    BrandName=machine.BrandName,
                    SerialNumber=machine.SerialNumber,  
                    HourlyElectricWaste=machine.HourlyElectricWaste,
                    UsePeriod=machine.UsePeriod,
                    PurchaseDate=machine.PurchaseDate,
                };


                MachineModels.Add(model);
            }


            this.OpenSaveMachine = new OpenSaveMachineCommand(this);
            this.OpenUpdateMachine = new OpenUpdateMachineCommand(this);
            this.DeleteMachine = new DeleteMachineCommand(this);
            this.ExportMachine = new ExportMachineCommand(this);
        }

        public ObservableCollection<MachineModel> MachineModels { get; set; }
        public ICommand OpenSaveMachine { get; set; }
        public ICommand OpenUpdateMachine { get; set; }
        public ICommand DeleteMachine { get; set; }
        public ICommand ExportMachine { get; set; }
        public int SelectedMachineIndex { get; set; }
    }
}
