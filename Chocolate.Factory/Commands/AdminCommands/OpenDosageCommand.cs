using Chocolate.Factory.ViewModels;
using Chocolate.Factory.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.AdminCommands
{
    public class OpenDosageCommand:ICommand
    {
        private readonly AdminWindowViewModel _viewModel;

        public OpenDosageCommand(AdminWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
           return true;
        }

        public void Execute(object parameter)
        {
            DosageUserControl userControl = new DosageUserControl();
            DosageViewModel viewModel = new DosageViewModel();
            userControl.DataContext = viewModel;

            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(userControl);
        }
    }
}
