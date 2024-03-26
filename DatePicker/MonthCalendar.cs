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
        private readonly int _headerHeight = 20;
        private readonly Color _headerBackColor = SystemColors.ButtonFace;

        private MonthYearSelector _monthYearSelector;

        private TableLayoutPanel _calendarTable;
        private Panel _topPanel;
        private Panel _middlePanel;

        private List<Holiday> _holidaysList;
        private DayButton[,] _toggleButtons;
        public MonthCalendar()
        {
            InitializeComponent();
            InitializeCalendar();
            SetDefaults();
            BorderStyle = BorderStyle.FixedSingle;
        }


        [EditorBrowsable()]
        [Category("Behavior")]
        public bool AllowSelectionOfHolidays { get; set; }

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

        private void SetDateToCalendar(DateTime value)
        {
             if (value == new DateTime()) return;
            _monthYearSelector.Value = value;
            for (int i = 0; i < 5; i++)
            {
                var button = _toggleButtons[i, (int)value.DayOfWeek];
                if (button.Date == value)
                {
                    button.Checked = true;
                    break;
                }
            }
        }

        private void InitializeCalendar()
        {
            _topPanel = new Panel();
            _topPanel.Dock = DockStyle.Top;
            _topPanel.Height = _headerHeight;
            _topPanel.BackColor = SystemColors.Control;

            _middlePanel = new Panel();
            _middlePanel.Dock = DockStyle.Fill;
            _middlePanel.BackColor = SystemColors.Control;

            _monthYearSelector = new MonthYearSelector() { Left = 0, Top = 0 };
            _monthYearSelector.ValueChanged += (sender, e) => UpdateCalendar();
            _topPanel.Controls.Add(_monthYearSelector);

            _calendarTable = new TableLayoutPanel();
            _calendarTable.RowStyles.Add(new RowStyle(SizeType.Absolute, _headerHeight));
            _calendarTable.Dock = DockStyle.Fill;

            for (int i = 0; i < 7; i++)
            {
                _calendarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / 7));
            }

            _middlePanel.Controls.Add(_calendarTable);

            Controls.Add(_topPanel);
            Controls.Add(_middlePanel);

            _holidaysList = new List<Holiday>();
            PopulateCalendar();

            // Sample holidays (you can set these through the Holidays property)
            Holidays = new List<Holiday>
        {
            new Holiday(new DateTime(2024, 1, 1), "New Year Day", Calendars.Gregorian),
            new Holiday(new DateTime(2024, 3, 29), "Good Friday", Calendars.Gregorian),

            new Holiday(new DateTime(2024, 1, 15), "Indian fest", Calendars.Indian),
            new Holiday(new DateTime(2024, 1, 15), "Gregorian fest", Calendars.Gregorian),
            new Holiday(new DateTime(2024, 1, 15), "Hebrew fest", Calendars.Hebrew),
            new Holiday(new DateTime(2024, 1, 15), "Chinese fest", Calendars.Chinese),
            new Holiday(new DateTime(2024, 1, 15), "Iranian fest", Calendars.Iranian),
            new Holiday(new DateTime(2024, 1, 15), "Islamic fest", Calendars.Islamic),
            new Holiday(new DateTime(2024, 1, 15), "Japanese fest", Calendars.Japanese),
            new Holiday(new DateTime(2024, 1, 15), "Persian fest", Calendars.Persian),

            new Holiday(new DateTime(2024, 3, 8), "Mahashivratri", Calendars.Indian),
            new Holiday(new DateTime(2024, 1, 25), "Shevat", Calendars.Hebrew),
            new Holiday(new DateTime(2024, 3, 23), "Purim", Calendars.Hebrew),
            new Holiday(new DateTime(2024, 4, 10), "Eid al Fitr", Calendars.Islamic),
            new Holiday(new DateTime(2024, 6, 16), "Eid al Adha", Calendars.Islamic),
            new Holiday(new DateTime(2024, 2, 23), "Emperor’s Birthday", Calendars.Japanese),
            new Holiday(new DateTime(2024, 4, 29), "Showa Day", Calendars.Japanese),
        };

            InitCalendar();
        }

        private void PopulateCalendar()
        {
            _toggleButtons = new DayButton[6, 7];

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    _toggleButtons[i, j] = GetDayButton();
                }
            }
        }

        private void SetDefaults()
        {
            MinimumSize = new Size(300, 180);
            Value = DateTime.Now;
        }

        private void InitCalendar()
        {
            _calendarTable.Controls.Clear();
            _calendarTable.RowStyles.Clear();
            _calendarTable.RowStyles.Add(new RowStyle(SizeType.Absolute, _headerHeight));

            var dayNames = DateTimeFormatInfo.CurrentInfo.DayNames;

            for (int i = 0; i < 7; i++)
            {
                _calendarTable.Controls.Add(GetDayHeader(dayNames, i), i, 1);
            }
            for (int row = 2; row <= 7; row++)
            {
                _calendarTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / 6));

                for (int col = 0; col < 7; col++)
                {
                    _calendarTable.Controls.Add(_toggleButtons[row - 2, col], col, row);
                }
            }
        }

        private DayButton GetDayHeader(string[] dayNames, int i)
        {
            return new DayButton
            {
                Text = dayNames[i].Substring(0, 3),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = _headerBackColor,
                ForeColor = Color.White,
                Enabled = false
            };
        }

        private void UpdateCalendar()
        {
            if (_monthYearSelector.Value == new DateTime()) return;
            var selectedMonth = _monthYearSelector.Value.Month;
            var selectedYear = _monthYearSelector.Value.Year;

            var firstDayOfMonth = new DateTime(selectedYear, (int)selectedMonth, 1);
            var daysInMonth = DateTime.DaysInMonth(selectedYear, (int)selectedMonth);

            var currentDay = firstDayOfMonth;

            int daysBefore = ((int)currentDay.DayOfWeek - (int)DayOfWeek.Sunday + 7) % 7; // Ensure positive value
            for (int row = 2; row <= 7; row++)
            {
                _calendarTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / 6));

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
            var button = _toggleButtons[row - 2, col];
            if (button == null) button = GetDayButton();
            var holidays = GetHoliday(day);
            button.SetDate(day, day == _value, holidays, isCurrentMonth);
        }

        private List<Holiday> GetHoliday(DateTime day)
        {
            return _holidaysList.FindAll(h => h.Date.Date == day.Date);
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
            return dayButton;
        }

        public event EventHandler ValueChanged;

        public List<Holiday> Holidays
        {
            get { return _holidaysList; }
            set
            {
                _holidaysList = value;
                UpdateCalendar();
            }
        }
    }

    public class ValueChangedEventArgs: EventArgs
    {
        public DateTime Date { get; set; }
    
        public ValueChangedEventArgs( DateTime date)
        {
            Date = date;
        }
    }
}
