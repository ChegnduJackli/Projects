using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Combobox1
{
    class Person:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int age;
        public int Age
        {
            get { return age; }
            set {
                age = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Age"));
                }
            }
        }
    }
}
