using Chocolate.Factory.Models;
using Chocolate.Factory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Commands.CarWorkTimeCommands
{
    public class ExportCarWorkTimeCommand : BaseExpotrtCommand<CarWorkTimeModel>
    {
        private readonly CarWorkTimeViewModel _viewModel;

        public ExportCarWorkTimeCommand(CarWorkTimeViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override List<CarWorkTimeModel> GetData()
        {
            return _viewModel.CarWorkTimeModels.ToList();
        }
    }
}
