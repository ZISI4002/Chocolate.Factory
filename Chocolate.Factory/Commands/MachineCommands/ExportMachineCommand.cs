using Chocolate.Factory.Models;
using Chocolate.Factory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Commands.MachineCommands
{
    public class ExportMachineCommand : BaseExpotrtCommand<MachineModel>
    {
        private readonly MachineViewModel _viewModel;

        public ExportMachineCommand(MachineViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override List<MachineModel> GetData()
        {
            return _viewModel.MachineModels.ToList();
        }
    }

}
