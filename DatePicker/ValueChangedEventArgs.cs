using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatePickerPro
{
    public class ValueChangedEventArgs : EventArgs
    {
        public DateTime Value { get; set; }

        public ValueChangedEventArgs(DateTime value)
        {
            Value = value;
        }
    }
}
