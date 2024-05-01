using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatePickerPro
{
    internal partial class MonthYearSelector : UserControl
    {
        private DateTime _value;

        [EditorBrowsable()]
        [Category("Behavior")]
        public DateTime Value
        {
            get { return _value; }
            set
            {
                if (value == new DateTime()) return;
                _value = value;
                numericUpDown1.Value = value.Year;
                stringUpDown1.Value = _months[value.Month - 1];
            }
        }

        private List<string> _months;

        public event EventHandler ValueChanged;

        public MonthYearSelector()
        {
            InitializeComponent();
            _months = DateTimeFormatInfo.CurrentInfo.MonthNames.Take(12).ToList();
            stringUpDown1.Months = _months.ToArray();
            numericUpDown1.Increment = 1;
            numericUpDown1.Minimum = 1900;
            numericUpDown1.Maximum = 9999;
            Value = DateTime.Now;

            numericUpDown1.ValueChanged += Date_ValueChanged;
            stringUpDown1.ValueChanged += Date_ValueChanged;
        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {
            var monthIndex = _months.IndexOf(stringUpDown1.Value);
            if (monthIndex < 0) return;
            _value = new DateTime((int)numericUpDown1.Value, monthIndex + 1, 1);
            if (ValueChanged != null) ValueChanged(this, new EventArgs());
        }

        private void stringUpDown1_ValueRolled(object sender, EventArgs e)
        {
            if (((ValueRolledEventArgs)e).IsForword)
                numericUpDown1.Value++;
            else
                numericUpDown1.Value--;
        }
    }
}
