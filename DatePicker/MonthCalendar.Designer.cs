
using System.Drawing;

namespace DatePickerPro
{
    partial class MonthCalendar
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this._monthYearSelector1 = new DatePickerPro.MonthYearSelector();
            this._lblMessage = new System.Windows.Forms.Label();
            this._calendar = new System.Windows.Forms.TableLayoutPanel();
            this._mainLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainLayout
            // 
            this._mainLayout.BackColor = SystemColors.Window;
            this._mainLayout.ColumnCount = 1;
            this._mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainLayout.Controls.Add(this._monthYearSelector1, 0, 0);
            this._mainLayout.Controls.Add(this._lblMessage, 0, 2);
            this._mainLayout.Controls.Add(this._calendar, 0, 1);
            this._mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainLayout.Location = new System.Drawing.Point(0, 0);
            this._mainLayout.Name = "_mainLayout";
            this._mainLayout.RowCount = 3;
            this._mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this._mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._mainLayout.Size = new System.Drawing.Size(270, 210);
            this._mainLayout.TabIndex = 0;
            // 
            // _monthYearSelector1
            // 
            this._monthYearSelector1.BackColor = SystemColors.Window;
            this._monthYearSelector1.Location = new System.Drawing.Point(4, 3);
            this._monthYearSelector1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._monthYearSelector1.Name = "_monthYearSelector1";
            this._monthYearSelector1.Size = new System.Drawing.Size(262, 20);
            this._monthYearSelector1.TabIndex = 0;
            this._monthYearSelector1.Value = new System.DateTime(2024, 5, 2, 3, 4, 45, 379);
            // 
            // _lblMessage
            // 
            this._lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._lblMessage.BackColor = SystemColors.Control;
            this._lblMessage.Location = new System.Drawing.Point(3, 200);
            this._lblMessage.Name = "_lblMessage";
            this._lblMessage.Size = new System.Drawing.Size(0, 20);
            this._lblMessage.TabIndex = 1;
            // 
            // _calendar
            // 
            this._calendar.BackColor =  SystemColors.Window;
            this._calendar.ColumnCount = 7;
            this._calendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F / 7));
            this._calendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F / 7));
            this._calendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F / 7));
            this._calendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F / 7));
            this._calendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F / 7));
            this._calendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F / 7));
            this._calendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F / 7));
            this._calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this._calendar.Location = new System.Drawing.Point(3, 23);
            this._calendar.Name = "_calendar";
            this._calendar.RowCount = 7;
            this._calendar.Size = new System.Drawing.Size(264, 174);
            this._calendar.TabIndex = 2;
            // 
            // MonthCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this._mainLayout);
            this.Name = "MonthCalendar";
            this.Size = new System.Drawing.Size(280, 210);
            this._mainLayout.ResumeLayout(false);
            this._mainLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _mainLayout;
        private MonthYearSelector _monthYearSelector1;
        private System.Windows.Forms.Label _lblMessage;
        private System.Windows.Forms.TableLayoutPanel _calendar;
    }
}
