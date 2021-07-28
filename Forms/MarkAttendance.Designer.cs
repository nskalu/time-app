namespace TimeProject.Forms
{
    partial class MarkAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarkAttendance));
            this.gdvAttendanceList = new System.Windows.Forms.DataGridView();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatricNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.PicDerived = new System.Windows.Forms.PictureBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gdvAttendanceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicDerived)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // gdvAttendanceList
            // 
            this.gdvAttendanceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvAttendanceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentName,
            this.MatricNum,
            this.TimeIn,
            this.TimeOut});
            this.gdvAttendanceList.Location = new System.Drawing.Point(603, 44);
            this.gdvAttendanceList.Name = "gdvAttendanceList";
            this.gdvAttendanceList.Size = new System.Drawing.Size(417, 507);
            this.gdvAttendanceList.TabIndex = 0;
            // 
            // StudentName
            // 
            this.StudentName.HeaderText = "Name";
            this.StudentName.Name = "StudentName";
            // 
            // MatricNum
            // 
            this.MatricNum.HeaderText = "Matric No.";
            this.MatricNum.Name = "MatricNum";
            // 
            // TimeIn
            // 
            this.TimeIn.HeaderText = "Time In";
            this.TimeIn.Name = "TimeIn";
            // 
            // TimeOut
            // 
            this.TimeOut.HeaderText = "Time Out";
            this.TimeOut.Name = "TimeOut";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(3, 325);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(582, 226);
            this.txtLog.TabIndex = 3;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(17, 10);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 25);
            this.lblMsg.TabIndex = 4;
            // 
            // PicDerived
            // 
            this.PicDerived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicDerived.Location = new System.Drawing.Point(414, 123);
            this.PicDerived.Name = "PicDerived";
            this.PicDerived.Size = new System.Drawing.Size(150, 196);
            this.PicDerived.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicDerived.TabIndex = 2;
            this.PicDerived.TabStop = false;
            // 
            // picImage
            // 
            this.picImage.Image = global::TimeProject.Properties.Resources._002_user_avatar;
            this.picImage.Location = new System.Drawing.Point(264, 191);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(130, 128);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 1;
            this.picImage.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(910, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Admin Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // MarkAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1023, 553);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.PicDerived);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.gdvAttendanceList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MarkAttendance";
            this.Text = "Mark Attendance";
            this.Load += new System.EventHandler(this.MarkAttendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdvAttendanceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicDerived)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gdvAttendanceList;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.PictureBox PicDerived;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatricNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeOut;
        private System.Windows.Forms.Button button1;
    }
}