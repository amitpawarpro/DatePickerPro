using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatePickerPro
{
    public class ValueRolledEventArgs : EventArgs
    {
        public bool IsForword { get; set; }

        public ValueRolledEventArgs(bool isForword)
        {
            IsForword = isForword;
        }
    }
}
