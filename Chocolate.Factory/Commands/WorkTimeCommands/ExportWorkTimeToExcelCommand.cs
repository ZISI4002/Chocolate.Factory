using Chocolate.Factory.Models;
using Chocolate.Factory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.WorkTimeCommands
{
    public class ExportWorkTimeCommand : BaseExpotrtCommand<WorkTimeModel>
    {
        private readonly WorkTimeViewModel _viewModel;

        public ExportWorkTimeCommand(WorkTimeViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override List<WorkTimeModel> GetData()
        {
            return _viewModel.WorkTimeModels.ToList();
        }
    }
}
