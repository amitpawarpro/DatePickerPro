using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DatePickerPro
{
    public class DayButton : RadioButton
    {
        private readonly ToolTip _ttError = new() { ShowAlways = true, ToolTipIcon = ToolTipIcon.Error, BackColor = Color.LightPink };
        public DateTime Date { get; private set; }
        public List<Holiday> Holidays { get; private set; }

        public event EventHandler MessageChanged;
        public DayButton()
        {
            Click += DayButton_Click;
            Margin = new Padding(0);
            TextAlign = ContentAlignment.MiddleCenter;
            Appearance = Appearance.Button;
            Dock = DockStyle.Fill;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.CheckedBackColor = SystemColors.GradientActiveCaption;
            BackgroundImageLayout = ImageLayout.Stretch;
            Date = DateTime.Now;

            MouseEnter += (s,e)=> { FlatAppearance.BorderSize = 1; if (MessageChanged != null){ MessageChanged(this, new MessageChangedEventArg(Date.ToString(Constants.DateDisplayFormatDetails) + GetTooltipText(Holidays))); } }; 
            MouseLeave += (s, e) => { FlatAppearance.BorderSize = 0; if (MessageChanged != null){ MessageChanged(this, null); } };
        }

        private void DayButton_Click(object sender, EventArgs e)
        {
            if (Cursor == Cursors.No)
            {
                var day = Date;
                var holidaysText = GetTooltipText(Holidays, Environment.NewLine);
                var toolTipText = $"'{day.ToString(Constants.DateDisplayFormatDetails)}' is a non-working day.{holidaysText}";
                _ttError.Show(toolTipText, this, 2000);
                _ttError.Show(toolTipText, this, 2000);
                Checked = false;

                if (ValueChanged != null) ValueChanged(this, null);
                return;
            };
            if (ValueChanged != null) ValueChanged(this, new ValueChangedEventArgs(Date));
        }

        public event EventHandler ValueChanged;

        private string GetTooltipText(List<Holiday> holidays, string separator = ",")
        {
            var toolTipText = string.Empty;

            if (holidays.Count > 0)
            {
                foreach (var holiday in holidays)
                {
                    toolTipText += $"{separator}{holiday.Description}-{holiday.Calendar.CalendarType}";
                }
            }

            return toolTipText;
        }

        public void SetDate(DateTime day, bool isSelected, List<Holiday> holidays, bool isCurrentMonth )
        {
            Date = day;
            Holidays = holidays;
            _ttError.RemoveAll();
            Checked = isSelected;
            Text = day.Day.ToString();

            var blockDayDueToHoliday = holidays.Any(h => h.Calendar.BlockDate);

            var isWorkDay = day.DayOfWeek != DayOfWeek.Sunday && day.DayOfWeek != DayOfWeek.Saturday && !blockDayDueToHoliday;

            ForeColor = isCurrentMonth ? SystemColors.WindowText : SystemColors.GrayText;
            Cursor = isWorkDay ? Cursors.Default : Cursors.No;

            var holidaysToDisplay = holidays.FindAll(h => h.Calendar.DisplayOnDate);

            BackgroundImage = (holidays != null && holidays.Count == 0) ? null : IndicationHelper.GenerateBitmap(32, 32, holidaysToDisplay);
            FlatAppearance.MouseOverBackColor = isWorkDay ? SystemColors.GradientInactiveCaption : SystemColors.Control;

            BackColor = isWorkDay ? SystemColors.ButtonHighlight : SystemColors.ButtonFace;
        }
    }
}
