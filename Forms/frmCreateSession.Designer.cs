namespace TimeProject.Forms
{
    partial class frmCreateSession
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateSession));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsession = new System.Windows.Forms.TextBox();
            this.txtnoofAttendance = new System.Windows.Forms.TextBox();
            this.dtpStartdate = new System.Windows.Forms.DateTimePicker();
            this.dtpenddate = new System.Windows.Forms.DateTimePicker();
            this.cboSemester = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdbfulltime = new System.Windows.Forms.RadioButton();
            this.rdbparttime = new System.Windows.Forms.RadioButton();
            this.lblmsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Navy;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(258, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Session Name:";
            // 
            // txtsession
            // 
            this.txtsession.Location = new System.Drawing.Point(256, 57);
            this.txtsession.Name = "txtsession";
            this.txtsession.Size = new System.Drawing.Size(200, 20);
            this.txtsession.TabIndex = 2;
            // 
            // txtnoofAttendance
            // 
            this.txtnoofAttendance.Location = new System.Drawing.Point(256, 252);
            this.txtnoofAttendance.Name = "txtnoofAttendance";
            this.txtnoofAttendance.ReadOnly = true;
            this.txtnoofAttendance.Size = new System.Drawing.Size(200, 20);
            this.txtnoofAttendance.TabIndex = 4;
            // 
            // dtpStartdate
            // 
            this.dtpStartdate.Location = new System.Drawing.Point(256, 94);
            this.dtpStartdate.Name = "dtpStartdate";
            this.dtpStartdate.Size = new System.Drawing.Size(200, 20);
            this.dtpStartdate.TabIndex = 5;
            // 
            // dtpenddate
            // 
            this.dtpenddate.Location = new System.Drawing.Point(256, 128);
            this.dtpenddate.Name = "dtpenddate";
            this.dtpenddate.Size = new System.Drawing.Size(200, 20);
            this.dtpenddate.TabIndex = 6;
            // 
            // cboSemester
            // 
            this.cboSemester.FormattingEnabled = true;
            this.cboSemester.Location = new System.Drawing.Point(256, 212);
            this.cboSemester.Name = "cboSemester";
            this.cboSemester.Size = new System.Drawing.Size(200, 21);
            this.cboSemester.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Semester:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Expected No. of Attendance:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Start Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "End Date:";
            // 
            // rdbfulltime
            // 
            this.rdbfulltime.AutoSize = true;
            this.rdbfulltime.Location = new System.Drawing.Point(256, 172);
            this.rdbfulltime.Name = "rdbfulltime";
            this.rdbfulltime.Size = new System.Drawing.Size(67, 17);
            this.rdbfulltime.TabIndex = 12;
            this.rdbfulltime.TabStop = true;
            this.rdbfulltime.Text = "Full-Time";
            this.rdbfulltime.UseVisualStyleBackColor = true;
            this.rdbfulltime.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // rdbparttime
            // 
            this.rdbparttime.AutoSize = true;
            this.rdbparttime.Location = new System.Drawing.Point(345, 172);
            this.rdbparttime.Name = "rdbparttime";
            this.rdbparttime.Size = new System.Drawing.Size(70, 17);
            this.rdbparttime.TabIndex = 13;
            this.rdbparttime.TabStop = true;
            this.rdbparttime.Text = "Part-Time";
            this.rdbparttime.UseVisualStyleBackColor = true;
            this.rdbparttime.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsg.Location = new System.Drawing.Point(258, 18);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(0, 17);
            this.lblmsg.TabIndex = 14;
            // 
            // frmCreateSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(655, 346);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.rdbparttime);
            this.Controls.Add(this.rdbfulltime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboSemester);
            this.Controls.Add(this.dtpenddate);
            this.Controls.Add(this.dtpStartdate);
            this.Controls.Add(this.txtnoofAttendance);
            this.Controls.Add(this.txtsession);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCreateSession";
            this.Text = "Create Session";
            this.Load += new System.EventHandler(this.FrmCreateSession_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsession;
        private System.Windows.Forms.TextBox txtnoofAttendance;
        private System.Windows.Forms.DateTimePicker dtpStartdate;
        private System.Windows.Forms.DateTimePicker dtpenddate;
        private System.Windows.Forms.ComboBox cboSemester;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdbfulltime;
        private System.Windows.Forms.RadioButton rdbparttime;
        private System.Windows.Forms.Label lblmsg;
    }
}