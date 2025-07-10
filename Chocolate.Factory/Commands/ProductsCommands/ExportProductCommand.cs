using Chocolate.Factory.ViewModels;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Chocolate.Factory.Models;
using System.IO;
using Chocolate.Factory.Helper;

namespace Chocolate.Factory.Commands.ProductsCommands
{
   
    public class ExportProductCommand : BaseExpotrtCommand<ProductModel>
    {
          private readonly ProductViewModel _viewModel;

        public ExportProductCommand(ProductViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override List<ProductModel> GetData()
        {
            return _viewModel.ProductModels.ToList();
        }
    }

}
