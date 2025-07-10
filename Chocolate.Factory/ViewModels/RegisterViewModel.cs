using Chocolate.Factory.Commands.RegisterCommands;
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
    public class RegisterViewModel : BaseWindowViewModel
    {
        public RegisterViewModel(Window window) : base(window)
        {
            this.RegisterModel = new RegisterModel();
            this.Register=new RegisterCommand(this);
            this.Close=new CloseCommand(this);  
            this.GoBack = new GoBackCommand(this);
        }

        public RegisterModel RegisterModel { get; set; }
        public ICommand Register {  get; set; }
        public ICommand Close { get; set; }
        public ICommand GoBack { get; set; }
    }
}
