using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductsList_Command_MVVM_WpfApp2.mvvm
{
   public class Changed : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void Signal([CallerMemberName] string prop = null) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}

