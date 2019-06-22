using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _27_WPF_MVVM.Helper
{
    public class ObservObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler
                 PropertyChanged;
        public void OnPropertyChanged
                        ([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                      new PropertyChangedEventArgs(prop));
        }
    }
}
