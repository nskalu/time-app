using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeProject.Classes;

namespace TimeProject.Forms
{
    public partial class Login : Form
    {
        //public frmCreateUser createUserfrm = new frmCreateUser();
        //public frmRegisterStudent registerstudentform = new frmRegisterStudent();

        public Login()
        {
            InitializeComponent();
        }
        DataSet dt;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtusername.Text.Trim()=="" || txtpassword.Text.Trim()=="")
                {
                    lblMsg.Text="Please enter your Username and Password";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
               dt= (DataSet)SQLiteHandler.GetUser(txtusername.Text.Trim(), txtpassword.Text.Trim());
                if (dt.Tables[0].Rows.Count>0)
                {
                    this.Close();
                   
                    MainContainer frmContainer = new MainContainer();
                    frmContainer.Show();
                    frmContainer.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    frmContainer.Left = Top = 0;
                    frmContainer.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    frmContainer.Height = Screen.PrimaryScreen.WorkingArea.Height;
                }
                else
                {
                    lblMsg.Text = "Incorrect Username or Password";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error has occured while trying to log you in " + ex.Message + " inner exception: " + ex.InnerException.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
