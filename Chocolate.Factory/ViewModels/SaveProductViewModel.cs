using Chocolate.Factory.Commands.ProductsCommands;
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
    public class SaveProductViewModel : BaseWindowViewModel
    {
        public SaveProductViewModel(Window window,ProductViewModel productViewModel) : base(window)
        {
            this.ProductModel = new ProductModel();
            this.ProductsViewModel=productViewModel;
            this.SaveProduct=new SaveProductCommand(this);
        }
        public ProductModel ProductModel { get; set; }
        public ICommand SaveProduct { get; set; }
        
        public ProductViewModel ProductsViewModel { get; set; }

        
    }
}
