using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatePickerPro
{
    public partial class DatePicker : DropDownControl
    {
        private bool isUpdating;
        public DatePicker()
        {
            InitializeComponent();
            InitializeDropDown(panel1);
            isUpdating = false;
            Value = DateTime.Now.Date;
        }
        public event EventHandler ValueChanged;

        [EditorBrowsable()]
        [Category("Behavior")]
        public DateTime Value
        {
            get { return monthCalendarx1.Value; }
            set { monthCalendarx1.Value = value;
                Text = monthCalendarx1.Value.ToShortDateString();
            }
        }

        public List<Holiday> Holidays 
        {
            get { return monthCalendarx1.Holidays; }
            set { monthCalendarx1.Holidays = value; }
        }


        private void monthCalendarx1_DateChanged(object sender, EventArgs e)
        {
            if (isUpdating || this.DropState != eDropState.Dropped) return;
            Value = ((ValueChangedEventArgs)e).Value;
            this.CloseDropDown();
            if (ValueChanged != null) ValueChanged(this, e);
        }
    }
}
