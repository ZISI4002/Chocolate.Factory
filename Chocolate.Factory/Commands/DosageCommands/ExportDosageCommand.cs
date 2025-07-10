using Chocolate.Factory.Models;
using Chocolate.Factory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Commands.DosageCommands
{
    public class ExportDosageCommand : BaseExpotrtCommand<DosageModel>
    {
        private readonly DosageViewModel _viewModel;

        public ExportDosageCommand(DosageViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override List<DosageModel> GetData()
        {
            return _viewModel.DosageModels.ToList();
        }
    }
}
