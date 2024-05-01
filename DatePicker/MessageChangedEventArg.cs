using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatePickerPro
{
    public class MessageChangedEventArg : EventArgs
    {
        public string Message { get; set; }

        public MessageChangedEventArg(string message)
        {
            Message = message;
        }
    }
}
