﻿
namespace DatePickerPro
{
    partial class MonthYearSelector
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.stringUpDown1 = new DatePickerPro.StringUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown1.Location = new System.Drawing.Point(90, 0);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50, 19);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            2024,
            0,
            0,
            0});
            // 
            // stringUpDown1
            // 
            this.stringUpDown1.AutoSize = true;
            this.stringUpDown1.Location = new System.Drawing.Point(0, -1);
            this.stringUpDown1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stringUpDown1.Months = new string[] {
        "January"};
            this.stringUpDown1.Name = "stringUpDown1";
            this.stringUpDown1.Size = new System.Drawing.Size(93, 21);
            this.stringUpDown1.TabIndex = 0;
            this.stringUpDown1.Value = "January";
            this.stringUpDown1.ValueRolled += new System.EventHandler(this.stringUpDown1_ValueRolled);
            // 
            // MonthYearSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.stringUpDown1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(140, 23);
            this.Name = "MonthYearSelector";
            this.Size = new System.Drawing.Size(140, 23);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StringUpDown stringUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
