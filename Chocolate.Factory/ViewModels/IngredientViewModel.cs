using Chocolate.Factory.Commands.IngredientCommands;
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
    public class IngredientViewModel 
    {
        public IngredientViewModel() { 
        List<Ingredient> ingredients = ApplicationContext.UnitOfWork.IngredientRepository.GetAll();

            IngredientModels = new ObservableCollection<IngredientModel>();
            foreach (Ingredient ingredient in ingredients)
            {
                IngredientModel ingredientmodel = new IngredientModel
                {
                    Id = ingredient.Id,
                    Name = ingredient.Name,
                    UseTime = ingredient.UseTime,                    
                    InStock = ingredient.InStock,
                };


               IngredientModels.Add(ingredientmodel);
            }



           this.OpenSaveIngredient= new OpenSaveIngredientCommand(this);
            this.OpenUpdateIngredient = new OpenUpdateIngredientCommand(this);
           this.DeleteIngredient= new DeleteIngredientCommand(this);
            this.ExportIngredient=new ExportIngredientCommand(this);    
        }

        public ObservableCollection<IngredientModel> IngredientModels { get; set; }
        public ICommand OpenSaveIngredient { get; set; }
       public ICommand OpenUpdateIngredient { get; set; }
      public ICommand DeleteIngredient { get; set; }
        public ICommand ExportIngredient { get; set; }  
       public int SelectedIngredientIndex { get; set; }
    }
}
