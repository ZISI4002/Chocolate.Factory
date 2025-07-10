using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace Chocolate.Factory.ViewModels
{
    public abstract class BaseWindowViewModel:INotifyPropertyChanged
    {
        public Window Window { get; private set; }
        public BaseWindowViewModel(Window window)
        {
            Window = window;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected  void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }


    }
}
