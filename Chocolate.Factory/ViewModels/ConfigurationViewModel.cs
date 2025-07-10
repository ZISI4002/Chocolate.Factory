using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Chocolate.Factory.Commands.ConfigurationCommands;
using Chocolate.Factory.Core.Domain.Enums;
using Chocolate.Factory.Models;

namespace Chocolate.Factory.ViewModels
{
    public class ConfigurationViewModel:BaseWindowViewModel
    {
        public ConfigurationViewModel(Window window):base(window) 
        {
            Configuration = new ConfigurationModel();

            Cancel = new CancelCommand(this);
            Save = new SaveCommand(this);
            SupportedDbTypes = Enum.GetValues(typeof(DatabaseType)).Cast<DatabaseType>().ToList();

        }
        public ConfigurationModel Configuration { get; set; }
        public List<DatabaseType>SupportedDbTypes { get; set; }

        public ICommand Save { get; set; }
        public ICommand Cancel { get; set; }

    }
}
