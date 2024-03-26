using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DatePickerPro
{
    public class DayButton : RadioButton
    {
        private readonly ToolTip _ttError = new() { ShowAlways = true, ToolTipIcon = ToolTipIcon.Error, BackColor = Color.LightPink };
        public DateTime Date { get; private set; }
        public List<Holiday> Holidays { get; private set; }
        public DayButton()
        {
            Click += DayButton_Click;
            Margin = new Padding(0);
            TextAlign = ContentAlignment.MiddleCenter;
            Appearance = Appearance.Button;
            Dock = DockStyle.Fill;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderColor = Color.LightGray;
            FlatAppearance.CheckedBackColor = SystemColors.GradientActiveCaption;
            FlatAppearance.MouseOverBackColor = SystemColors.GradientInactiveCaption;
            BackgroundImageLayout = ImageLayout.Stretch;
            Date = DateTime.Now;
        }

        private void DayButton_Click(object sender, EventArgs e)
        {
            if (Cursor == Cursors.No)
            {
                var day = Date;
                var holidaysText = GetTooltipText();
                var toolTipText = $"'{day.ToString("dddd dd MMMM yyyy")}' is a non-working day.{holidaysText}";
                _ttError.Show(toolTipText, this, 2000);
                _ttError.Show(toolTipText, this, 2000);
                Checked = false;

                if (ValueChanged != null) ValueChanged(this, null);
                return;
            };
            if (ValueChanged != null) ValueChanged(this, new ValueChangedEventArgs(Date));
        }

        public event EventHandler ValueChanged;

        private string GetTooltipText()
        {
            var toolTipText = string.Empty;

            if (Holidays.Count > 0)
            {
                foreach (var holiday in Holidays)
                {
                    toolTipText += $"{Environment.NewLine}{holiday.Description}-{holiday.Calendar.CalendarType}";
                }
            }

            return toolTipText;
        }

        public void SetDate(DateTime day, bool isSelected, List<Holiday> holidays, bool isCurrentMonth )
        {
            if (Date == day) return;

            Date = day;
            Holidays = holidays;
            _ttError.RemoveAll();
            Checked = isSelected;
            Text = day.Day.ToString();

            var isWorkDay = day.DayOfWeek != DayOfWeek.Sunday && day.DayOfWeek != DayOfWeek.Saturday && (holidays !=null && holidays.Count == 0);

            ForeColor = isCurrentMonth ? SystemColors.WindowText : SystemColors.GrayText;
            Cursor = isWorkDay ? Cursors.Default : Cursors.No;

            BackgroundImage = (holidays != null && holidays.Count == 0) ? null : ImageHelper.GenerateBitmap(32, 32, holidays);
            FlatAppearance.MouseOverBackColor = isWorkDay ? SystemColors.GradientInactiveCaption : SystemColors.Control;

            BackColor = isWorkDay ? SystemColors.ButtonHighlight : SystemColors.ButtonFace;
        }
    }
}
