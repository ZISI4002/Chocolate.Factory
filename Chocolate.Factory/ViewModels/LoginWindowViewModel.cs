using Chocolate.Factory.Commands.LoginCommands;
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
    public class LoginWindowViewModel:BaseWindowViewModel
    {
        public LoginWindowViewModel(Window window):base(window) 
        {
            LoginModel = new LoginModel();
            ErrorVisibility = Visibility.Hidden;

            Login=new LoginCommand(this);
            OpenRegister = new OpenRegisterWindowCommand(this);
            CloseLogin= new CloseLoginCommand(this);    
        }
        public LoginModel LoginModel { get; set; }
        private Visibility errorVisibility;
            public Visibility ErrorVisibility
        {
            get { return errorVisibility; }
            set
            {
                errorVisibility = value;
                this.OnPropertyChanged(nameof(errorVisibility));
            }

        }

        public ICommand Login {  get; set; }
        public ICommand OpenRegister { get; set; }
        public ICommand CloseLogin { get; set; }

    }
}
