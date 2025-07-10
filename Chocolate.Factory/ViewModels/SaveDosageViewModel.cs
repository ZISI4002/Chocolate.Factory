using Chocolate.Factory.Commands.DosageCommands;
using Chocolate.Factory.Commands.IngredientCommands;
using Chocolate.Factory.Core.Domain.Entities;
using Chocolate.Factory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Chocolate.Factory.ViewModels
{
    public class SaveDosageViewModel : BaseWindowViewModel
    {
        public SaveDosageViewModel(Window window, DosageViewModel baseViewModel) : base(window)
        {

            List<Product> products = ApplicationContext.UnitOfWork.ProductRepository.GetAll();
            List<Ingredient> ingredients = ApplicationContext.UnitOfWork.IngredientRepository.GetAll();


            this.Products = products.Select(x => new ProductModel
            {
                Id = x.Id,
                Name = x.Name,
                CompanyName = x.CompanyName,
                StandartWeight = x.StandartWeight,
            }).ToList();

            this.Ingredients = ingredients.Select(b => new IngredientModel
            {
                Id = b.Id,
                Name = b.Name,
                InStock = b.InStock,
                UseTime = b.UseTime,
            }).ToList();
            
            BaseViewModel = baseViewModel;

            this.SaveDosage = new SaveDosageCommand(this);

        }

        public ICommand SaveDosage { get; set; }
        public decimal SelectedQuantity { get; set; }
        public decimal SelectedDeviation { get; set; }

        public List<ProductModel> Products { get; set; }
        public int SelectedProductId { get; set; }

        public List<IngredientModel> Ingredients { get; set; }
        public int SelectedIngredientId { get; set; }
        public DosageViewModel BaseViewModel { get; set; }
    }
}