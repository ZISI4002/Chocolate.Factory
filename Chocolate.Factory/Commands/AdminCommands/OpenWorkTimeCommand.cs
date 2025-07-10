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
    public class OpenWorkTimesCommand : ICommand
    {
        private readonly AdminWindowViewModel _viewModel;

        public OpenWorkTimesCommand(AdminWindowViewModel viewModel)
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

            UserControl workTimesUserControl = new WorkTimeUserControl();
            WorkTimeViewModel workTimesViewModel = new WorkTimeViewModel();
            workTimesUserControl.DataContext = workTimesViewModel;

            _viewModel.CenterGrid.Children.Add(workTimesUserControl);
        }
    }
}
