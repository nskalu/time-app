namespace TimeProject.Forms
{
    partial class MainContainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainContainer));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.createuser = new System.Windows.Forms.ToolStripMenuItem();
            this.registerstudent = new System.Windows.Forms.ToolStripMenuItem();
            this.markattendance = new System.Windows.Forms.ToolStripMenuItem();
            this.report = new System.Windows.Forms.ToolStripMenuItem();
            this.byDeptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailHandlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImage = global::TimeProject.Properties.Resources.WhatsApp_Image_2019_11_06_at_12_25_45_PM;
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Size = new System.Drawing.Size(1041, 553);
            this.splitContainer1.SplitterDistance = 176;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createuser,
            this.registerstudent,
            this.markattendance,
            this.report,
            this.emailHandlerToolStripMenuItem,
            this.logOffToolStripMenuItem,
            this.exitApplicationToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(176, 553);
            this.menuStrip1.TabIndex = 0;
            // 
            // createuser
            // 
            this.createuser.BackColor = System.Drawing.Color.Silver;
            this.createuser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.createuser.Margin = new System.Windows.Forms.Padding(2);
            this.createuser.Name = "createuser";
            this.createuser.Padding = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.createuser.Size = new System.Drawing.Size(168, 31);
            this.createuser.Text = "Create New User";
            this.createuser.Click += new System.EventHandler(this.Createuser_Click_1);
            // 
            // registerstudent
            // 
            this.registerstudent.BackColor = System.Drawing.Color.Silver;
            this.registerstudent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.registerstudent.Margin = new System.Windows.Forms.Padding(2);
            this.registerstudent.Name = "registerstudent";
            this.registerstudent.Size = new System.Drawing.Size(168, 21);
            this.registerstudent.Text = "Register Student";
            this.registerstudent.Click += new System.EventHandler(this.Registerstudent_Click_1);
            // 
            // markattendance
            // 
            this.markattendance.BackColor = System.Drawing.Color.Silver;
            this.markattendance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.markattendance.Margin = new System.Windows.Forms.Padding(2);
            this.markattendance.Name = "markattendance";
            this.markattendance.Size = new System.Drawing.Size(168, 21);
            this.markattendance.Text = "Create Session";
            this.markattendance.Click += new System.EventHandler(this.CreateSessionToolStripMenuItem_Click_1);
            // 
            // report
            // 
            this.report.BackColor = System.Drawing.Color.Silver;
            this.report.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byDeptToolStripMenuItem,
            this.byStudentToolStripMenuItem});
            this.report.ForeColor = System.Drawing.SystemColors.ControlText;
            this.report.Margin = new System.Windows.Forms.Padding(2);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(168, 21);
            this.report.Text = "View Attendance Report";
            // 
            // byDeptToolStripMenuItem
            // 
            this.byDeptToolStripMenuItem.Name = "byDeptToolStripMenuItem";
            this.byDeptToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.byDeptToolStripMenuItem.Text = "By Dept";
            this.byDeptToolStripMenuItem.Click += new System.EventHandler(this.ByDeptToolStripMenuItem_Click_1);
            // 
            // byStudentToolStripMenuItem
            // 
            this.byStudentToolStripMenuItem.Name = "byStudentToolStripMenuItem";
            this.byStudentToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.byStudentToolStripMenuItem.Text = "By Student";
            this.byStudentToolStripMenuItem.Click += new System.EventHandler(this.ByStudentToolStripMenuItem_Click_1);
            // 
            // emailHandlerToolStripMenuItem
            // 
            this.emailHandlerToolStripMenuItem.Name = "emailHandlerToolStripMenuItem";
            this.emailHandlerToolStripMenuItem.Size = new System.Drawing.Size(172, 21);
            this.emailHandlerToolStripMenuItem.Text = "Email Handler";
            this.emailHandlerToolStripMenuItem.Click += new System.EventHandler(this.EmailHandlerToolStripMenuItem_Click_1);
            // 
            // logOffToolStripMenuItem
            // 
            this.logOffToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.logOffToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.logOffToolStripMenuItem.Margin = new System.Windows.Forms.Padding(2);
            this.logOffToolStripMenuItem.Name = "logOffToolStripMenuItem";
            this.logOffToolStripMenuItem.Size = new System.Drawing.Size(168, 21);
            this.logOffToolStripMenuItem.Text = "Log Off";
            this.logOffToolStripMenuItem.Click += new System.EventHandler(this.LogOffToolStripMenuItem_Click_1);
            // 
            // exitApplicationToolStripMenuItem
            // 
            this.exitApplicationToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.exitApplicationToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.exitApplicationToolStripMenuItem.Margin = new System.Windows.Forms.Padding(2);
            this.exitApplicationToolStripMenuItem.Name = "exitApplicationToolStripMenuItem";
            this.exitApplicationToolStripMenuItem.Size = new System.Drawing.Size(168, 21);
            this.exitApplicationToolStripMenuItem.Text = "Exit Application";
            this.exitApplicationToolStripMenuItem.Click += new System.EventHandler(this.ExitApplicationToolStripMenuItem_Click_1);
            // 
            // MainContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 553);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainContainer";
            this.Text = "Main Container";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem createuser;
        private System.Windows.Forms.ToolStripMenuItem registerstudent;
        private System.Windows.Forms.ToolStripMenuItem markattendance;
        private System.Windows.Forms.ToolStripMenuItem report;
        private System.Windows.Forms.ToolStripMenuItem exitApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byDeptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailHandlerToolStripMenuItem;
    }
}