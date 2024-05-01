using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace DatePickerPro
{

    internal partial class MonthCalendar : UserControl
    {
        private DayButton[,] _dayButtons;
        private List<Holiday> _holidaysList = new List<Holiday>();
        public event EventHandler ValueChanged;
        private DateTime _value;

        [EditorBrowsable()]
        [Category("Behavior")]
        public DateTime Value
        {
            get { return _value; }
            set { _value = value;
                SetDateToCalendar(value.Date);
            }
        }

        public List<Holiday> Holidays
        {
            get { return _holidaysList; }
            set
            {
                _holidaysList = value;
                UpdateCalendar();
            }
        }

        public MonthCalendar()
        {
            InitializeComponent();
            SuspendLayout();

            _monthYearSelector1.ValueChanged += (s, e) => UpdateCalendar();
            PopulateCalendar();
            var dayNames = DateTimeFormatInfo.CurrentInfo.DayNames;

            for (int i = 0; i < 7; i++)
            {
                _calendar.Controls.Add(GetDayHeader(dayNames, i), i, 1);
            }
            for (int row = 2; row <= 7; row++)
            {
                _calendar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / 6));

                for (int col = 0; col < 7; col++)
                {
                    _calendar.Controls.Add(_dayButtons[row - 2, col], col, row);
                }
            }

            ResumeLayout();
            Value = DateTime.Now;
            Load += (s, e) => UpdateCalendar();
        }
        private void SetDateToCalendar(DateTime value)
        {
             if (value == new DateTime()) return;
             _monthYearSelector1.Value = value;
            for (int i = 0; i < 5; i++)
            {
                var button = _dayButtons[i, (int)value.DayOfWeek];
                if (button.Date == value)
                {
                    button.Checked = true;
                    break;
                }
            }
        }


        private void UpdateCalendar()
        {
            if (_monthYearSelector1.Value == new DateTime()) return;
            var selectedMonth = _monthYearSelector1.Value.Month;
            var selectedYear = _monthYearSelector1.Value.Year;

            var firstDayOfMonth = new DateTime(selectedYear, (int)selectedMonth, 1);
            var daysInMonth = DateTime.DaysInMonth(selectedYear, (int)selectedMonth);

            var currentDay = firstDayOfMonth;

            int daysBefore = ((int)currentDay.DayOfWeek - (int)DayOfWeek.Sunday + 7) % 7; // Ensure positive value
            for (int row = 2; row <= 7; row++)
            {
                _calendar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / 6));

                for (int col = 0; col < 7; col++)
                {
                    DisplayButton(firstDayOfMonth, daysInMonth, daysBefore, row, col);
                }
            }
        }

        private void DisplayButton(DateTime firstDayOfMonth, int daysInMonth, int daysBefore, int row, int col)
        {
            var days = (row - 2) * 7 + col;
            if (days < daysBefore)
            {
                var prevMonthDay = firstDayOfMonth.AddDays(-daysBefore + days);
                UpdateButton(row, col, prevMonthDay);
            }
            else if (days - daysBefore < daysInMonth)
            {
                var currentMonthDay = firstDayOfMonth.AddDays(days - daysBefore);
                UpdateButton(row, col, currentMonthDay, true);
            }
            else
            {
                var nextMonthDay = firstDayOfMonth.AddMonths(1).AddDays(days - daysBefore - daysInMonth);
                UpdateButton(row, col, nextMonthDay);
            }
        }

        private void UpdateButton(int row, int col, DateTime day, bool isCurrentMonth = false)
        {
            var button = _dayButtons[row - 2, col];
            var holidays = GetHoliday(day);
            button.SetDate(day, day == _value, holidays, isCurrentMonth);
        }

        private List<Holiday> GetHoliday(DateTime day)
        {
            return _holidaysList.FindAll(h => h.Date.Date == day.Date);
        }

        private DayButton GetDayHeader(string[] dayNames, int i)
        {
            float headerFontSize = Font.Size - (Font.Size * 0.1f);
            return new DayButton
            {
                Text = dayNames[i].Substring(0, 3),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(Font.Name, headerFontSize),
                BackColor = SystemColors.ControlLight,
                Enabled = false
            };
        }

        private void PopulateCalendar()
        {
            _dayButtons = new DayButton[6, 7];

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    _dayButtons[i, j] = GetDayButton();
                }
            }
        }

        private DayButton GetDayButton()
        {
            var dayButton = new DayButton();
            dayButton.ValueChanged += (s, e) =>
            {
                if (e == null)
                {
                    SetDateToCalendar(_value);
                    return;
                }
                if (ValueChanged != null) ValueChanged(this, e);
            };

            dayButton.MessageChanged += (s, e) => {
                if (e==null)
                {
                    _lblMessage.Text = string.Empty;
                }
                else
                {
                    if (!string.IsNullOrEmpty(((MessageChangedEventArg)e).Message))
                    {
                        _lblMessage.Text = ((MessageChangedEventArg)e).Message;
                    }
                }
            };
            return dayButton;
        }


    }
}
