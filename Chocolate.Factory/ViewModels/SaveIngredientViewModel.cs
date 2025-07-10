using Chocolate.Factory.Commands.IngredientCommands;
using Chocolate.Factory.Commands.ProductsCommands;
using Chocolate.Factory.Core.Domain.Enums;
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
    public class SaveIngredientViewModel : BaseWindowViewModel
    {
        public SaveIngredientViewModel(Window window, IngredientViewModel ingredientViewModel) : base(window)
        {

            this.UseTimes = Enum.GetValues(typeof(UseTimeType))
               .Cast<UseTimeType>().ToList();



            this.IngredientModel = new IngredientModel();
            this.IngredientsViewModel = ingredientViewModel;
            this.SaveIngredient = new SaveIngredientCommand(this);
        }


        public IngredientModel IngredientModel { get; set; }
        public ICommand SaveIngredient { get; set; }
        public IngredientViewModel IngredientsViewModel { get; set; }
        public List<UseTimeType> UseTimes { get; set; }
       
    }
}
