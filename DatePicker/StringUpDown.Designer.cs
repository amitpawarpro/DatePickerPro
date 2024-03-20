
namespace DatePickerPro
{
    partial class StringUpDown
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
            this.nudMonthIndex = new System.Windows.Forms.NumericUpDown();
            this.lblMonthName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonthIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // nudMonthIndex
            // 
            this.nudMonthIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudMonthIndex.ForeColor = System.Drawing.SystemColors.Window;
            this.nudMonthIndex.Location = new System.Drawing.Point(0, 0);
            this.nudMonthIndex.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.nudMonthIndex.Name = "nudMonthIndex";
            this.nudMonthIndex.Size = new System.Drawing.Size(117, 23);
            this.nudMonthIndex.TabIndex = 0;
            this.nudMonthIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMonthIndex.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudMonthIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMonthName
            // 
            this.lblMonthName.BackColor = System.Drawing.SystemColors.Window;
            this.lblMonthName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMonthName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMonthName.Location = new System.Drawing.Point(21, 0);
            this.lblMonthName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMonthName.Name = "lblMonthName";
            this.lblMonthName.Size = new System.Drawing.Size(96, 23);
            this.lblMonthName.TabIndex = 1;
            this.lblMonthName.Text = "January";
            this.lblMonthName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StringUpDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMonthName);
            this.Controls.Add(this.nudMonthIndex);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "StringUpDown";
            this.Size = new System.Drawing.Size(117, 23);
            ((System.ComponentModel.ISupportInitialize)(this.nudMonthIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudMonthIndex;
        private System.Windows.Forms.Label lblMonthName;
    }
}
