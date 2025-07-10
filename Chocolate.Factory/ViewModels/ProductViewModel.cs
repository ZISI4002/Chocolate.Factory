using Chocolate.Factory.Commands.ProductsCommands;
using Chocolate.Factory.Core.Domain.Entities;
using Chocolate.Factory.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chocolate.Factory.ViewModels
{
    public class ProductViewModel 
    {
        public ProductViewModel() { 
        List<Product> products= ApplicationContext.UnitOfWork.ProductRepository.GetAll();

            ProductModels = new ObservableCollection<ProductModel>();
            foreach (Product product in products)
            {
                ProductModel model = new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    CompanyName = product.CompanyName,
                    StandartWeight = product.StandartWeight,
                };


                ProductModels.Add(model);
            }
         
           
            this.OpenSaveProduct= new OpenSaveProductsCommand(this);
            this.OpenUpdateProduct= new OpenUpdateProductCommand(this);
            this.DeleteProduct= new DeleteProductCommand(this);
            this.ExportProduct= new ExportProductCommand(this);
        }

       public ObservableCollection<ProductModel> ProductModels { get; set; }
        public ICommand OpenSaveProduct {  get; set; }
        public ICommand OpenUpdateProduct { get; set; }
        public ICommand DeleteProduct { get; set; }
        public ICommand ExportProduct {  get; set; }
        public int SelectedProductIndex { get; set; }
    }
}
