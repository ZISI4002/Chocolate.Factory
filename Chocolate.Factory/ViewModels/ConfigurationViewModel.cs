﻿using System;
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
    public class ConfigurationViewModel
    {
        public ConfigurationViewModel()
        {
            Model = new ConfigurationModel();

            //TODO:save and cansel
            Cancel = new CancelCommand(this);

            SupportedDbTypes = Enum.GetValues(typeof(DatabaseType)).Cast<DatabaseType>().ToList();


        }
        public ConfigurationModel Model { get; set; }
        public List<DatabaseType>SupportedDbTypes { get; set; }

        public ICommand Save { get; set; }
        public ICommand Cancel { get; set; }

        public Window Window { get; set; }
    }
}
