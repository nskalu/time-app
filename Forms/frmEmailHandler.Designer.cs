namespace TimeProject.Forms
{
    partial class frmEmailHandler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmailHandler));
            this.btnsendAll = new System.Windows.Forms.Button();
            this.btnSendsingle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmatricno = new System.Windows.Forms.TextBox();
            this.lblmsg = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnsendAll
            // 
            this.btnsendAll.Location = new System.Drawing.Point(173, 126);
            this.btnsendAll.Name = "btnsendAll";
            this.btnsendAll.Size = new System.Drawing.Size(207, 34);
            this.btnsendAll.TabIndex = 0;
            this.btnsendAll.Text = "Click here to send email to All Students";
            this.btnsendAll.UseVisualStyleBackColor = true;
            this.btnsendAll.Click += new System.EventHandler(this.BtnsendAll_Click);
            // 
            // btnSendsingle
            // 
            this.btnSendsingle.BackColor = System.Drawing.Color.Navy;
            this.btnSendsingle.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSendsingle.Location = new System.Drawing.Point(466, 37);
            this.btnSendsingle.Name = "btnSendsingle";
            this.btnSendsingle.Size = new System.Drawing.Size(111, 34);
            this.btnSendsingle.TabIndex = 1;
            this.btnSendsingle.Text = "Send Email";
            this.btnSendsingle.UseVisualStyleBackColor = false;
            this.btnSendsingle.Click += new System.EventHandler(this.BtnSendsingle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Matric No:";
            // 
            // txtmatricno
            // 
            this.txtmatricno.Location = new System.Drawing.Point(173, 41);
            this.txtmatricno.Name = "txtmatricno";
            this.txtmatricno.Size = new System.Drawing.Size(287, 20);
            this.txtmatricno.TabIndex = 3;
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsg.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblmsg.Location = new System.Drawing.Point(80, 9);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(0, 17);
            this.lblmsg.TabIndex = 4;
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.DarkRed;
            this.btnclose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnclose.Location = new System.Drawing.Point(387, 126);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 34);
            this.btnclose.TabIndex = 5;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.Btnclose_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 137);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(140, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundworker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundworker1_ProgressChanged);
            // 
            // frmEmailHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(589, 165);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.txtmatricno);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSendsingle);
            this.Controls.Add(this.btnsendAll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmailHandler";
            this.Text = "Email Handler";
            this.Load += new System.EventHandler(this.FrmEmailHandler_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsendAll;
        private System.Windows.Forms.Button btnSendsingle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmatricno;
        private System.Windows.Forms.Label lblmsg;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}