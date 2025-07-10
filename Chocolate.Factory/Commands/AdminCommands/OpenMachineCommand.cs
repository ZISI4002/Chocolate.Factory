using Chocolate.Factory.ViewModels;
using Chocolate.Factory.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chocolate.Factory.Commands.AdminCommands
{
    public class OpenMachineCommand : ICommand
    {
        private readonly AdminWindowViewModel _viewModel;

        public OpenMachineCommand(AdminWindowViewModel viewModel)
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
            _viewModel.CenterGrid.Children.Clear();

            UserControl machineUserControl = new MachineUserControl();
            MachineViewModel machineViewModel = new MachineViewModel();
            machineUserControl.DataContext = machineViewModel;


            _viewModel.CenterGrid.Children.Add(machineUserControl);

        }
    }
}
