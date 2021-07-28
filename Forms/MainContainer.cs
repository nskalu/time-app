using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeProject.Forms
{
    public partial class MainContainer : Form
    {
        public MainContainer()
        {
            InitializeComponent();
        }
       

        private void ExitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }


        private void MainContainer_Load(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Maximized;
            //FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            //Left = Top = 0;
            //Width = Screen.PrimaryScreen.WorkingArea.Width;
            //Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

       
        private void Createuser_Click_1(object sender, EventArgs e)
        {
            frmCreateUser Frmcreateuser = new frmCreateUser();
            Frmcreateuser.Show();
        }

        private void Registerstudent_Click_1(object sender, EventArgs e)
        {
            frmRegisterStudent frmreg = new frmRegisterStudent();
            frmreg.Show();
        }

        private void CreateSessionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmCreateSession frmcreateSession = new frmCreateSession();
            frmcreateSession.Show();
        }

      

        private void EmailHandlerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmEmailHandler frmEmail = new frmEmailHandler();
            frmEmail.Show();
        }

        private void ByDeptToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GeneralReport frmGeneral = new GeneralReport();
            frmGeneral.Show();
        }

        private void ByStudentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            StudentAttendanceReport frmStudentReport = new StudentAttendanceReport();
            frmStudentReport.Show();
        }

        private void LogOffToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login frmlogin = new Login();
            frmlogin.Show();
        }

        private void ExitApplicationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
