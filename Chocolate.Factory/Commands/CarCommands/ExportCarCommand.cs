using Chocolate.Factory.Models;
using Chocolate.Factory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Commands.CarCommands
{
    public class ExportCarCommand : BaseExpotrtCommand<CarModel>
    {
        private readonly CarViewModel _viewModel;

        public ExportCarCommand(CarViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override List<CarModel> GetData()
        {
            return _viewModel.CarModels.ToList();
        }
    }

}
