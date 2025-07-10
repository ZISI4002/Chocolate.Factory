using Chocolate.Factory.Models;
using Chocolate.Factory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Commands.IngredientCommands
{
    public class ExportIngredientCommand : BaseExpotrtCommand<IngredientModel>
    {
        private readonly IngredientViewModel _viewModel;

        public ExportIngredientCommand(IngredientViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override List<IngredientModel> GetData()
        {
            return _viewModel.IngredientModels.ToList();
        }
    }
}
