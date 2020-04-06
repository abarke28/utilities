using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace utilities
{
    public class BaseVM : INotifyPropertyChanged
    {
        public void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}