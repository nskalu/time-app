namespace TimeProject.Forms
{
    partial class GeneralReport
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralReport));
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.gdvGeneralReport = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatricNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoOfAttendance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Percentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboSemester = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnload = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gdvGeneralReport)).BeginInit();
            this.SuspendLayout();
            // 
            // cboDept
            // 
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(119, 77);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(174, 21);
            this.cboDept.TabIndex = 0;
            // 
            // gdvGeneralReport
            // 
            this.gdvGeneralReport.AllowUserToAddRows = false;
            this.gdvGeneralReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvGeneralReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvGeneralReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.MatricNo,
            this.NoOfAttendance,
            this.Percentage});
            this.gdvGeneralReport.Location = new System.Drawing.Point(2, 126);
            this.gdvGeneralReport.Name = "gdvGeneralReport";
            this.gdvGeneralReport.Size = new System.Drawing.Size(798, 321);
            this.gdvGeneralReport.TabIndex = 1;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            // 
            // MatricNo
            // 
            this.MatricNo.DataPropertyName = "MatricNo";
            this.MatricNo.HeaderText = "Matric No.";
            this.MatricNo.Name = "MatricNo";
            // 
            // NoOfAttendance
            // 
            this.NoOfAttendance.DataPropertyName = "NoAttended";
            this.NoOfAttendance.HeaderText = "No Of Attendance";
            this.NoOfAttendance.Name = "NoOfAttendance";
            // 
            // Percentage
            // 
            this.Percentage.DataPropertyName = "Percentage";
            this.Percentage.HeaderText = "Percentage";
            this.Percentage.Name = "Percentage";
            // 
            // cboSemester
            // 
            this.cboSemester.FormattingEnabled = true;
            this.cboSemester.Location = new System.Drawing.Point(388, 75);
            this.cboSemester.Name = "cboSemester";
            this.cboSemester.Size = new System.Drawing.Size(169, 21);
            this.cboSemester.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dept:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Level:";
            // 
            // btnload
            // 
            this.btnload.Location = new System.Drawing.Point(580, 74);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(156, 23);
            this.btnload.TabIndex = 5;
            this.btnload.Text = "Load Attendance Report";
            this.btnload.UseVisualStyleBackColor = true;
            this.btnload.Click += new System.EventHandler(this.Btnload_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(644, 102);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(156, 23);
            this.btnExcel.TabIndex = 6;
            this.btnExcel.Text = "Save asExcel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // GeneralReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(801, 450);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnload);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSemester);
            this.Controls.Add(this.gdvGeneralReport);
            this.Controls.Add(this.cboDept);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Text = "General Report";
            this.Load += new System.EventHandler(this.GeneralReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdvGeneralReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.DataGridView gdvGeneralReport;
        private System.Windows.Forms.ComboBox cboSemester;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatricNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoOfAttendance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Percentage;
    }
}