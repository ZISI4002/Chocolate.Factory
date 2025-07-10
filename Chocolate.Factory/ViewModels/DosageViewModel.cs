using Chocolate.Factory.Commands.DosageCommands;
using Chocolate.Factory.Core.Domain.Entities;
using Chocolate.Factory.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chocolate.Factory.ViewModels
{
    public class DosageViewModel
    {
        public DosageViewModel()
        {
            DosageModels = new ObservableCollection<DosageModel>();
            List<Dosage> dosages = ApplicationContext.UnitOfWork.DosageRepository.GetAll();

            foreach (Dosage dosage in dosages)
            {
                DosageModel dosageModel = new DosageModel
                {
                   Id = dosage.Id,
                   Quantity = dosage.Quantity,
                   Deviation = dosage.Deviation,
                    ProductName = dosage.Product.Name,
                    IngredientName = dosage.Ingredient.Name,
                    
                };

                this.DosageModels.Add(dosageModel);
            }

            this.OpenAddDosage = new OpenAddDosageCommand(this);
            this.DeleteDosage = new DeleteDosageCommand(this);
            this.ExportDosage = new ExportDosageCommand(this);

        }

        public ObservableCollection<DosageModel> DosageModels {  get; set; }
        public int SelectedDosageId { get; set; }
        public ICommand OpenAddDosage { get; set; }
        public ICommand DeleteDosage { get; set; }
        public ICommand ExportDosage { get; set; }
    }
    
}
