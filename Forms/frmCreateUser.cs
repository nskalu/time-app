using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeProject.Classes;

namespace TimeProject.Forms
{
    public partial class frmCreateUser : Form
    {
       
        public frmCreateUser()
        {
            InitializeComponent();
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        string progress;

        private void BtnSave_Click(object sender, EventArgs e)
        { 
            try
            {
               
                btnclose.Enabled = false;
                progress = "Processing...";
                lblprogress.Invoke(new Action(loadui));
               
                string name = txtName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string phone = txtPhone.Text.Trim();
                int role = (int)cboRole.SelectedValue;
                string password = txtpassword.Text.Trim();

                if (name=="" || email=="" || phone == "")
                {
                    lblMsg.Text = "Ensure all fields are filled";
                    return;
                }
                DataTable data;
                data = SQLiteHandler.CheckStaffExists(email, phone).Tables[0];
                if (data.Rows.Count > 0)
                {
                    lblMsg.Text = " Email or Phone already exists";
                    lblMsg.ForeColor = Color.Red;
                    return;
                }
                int i;
                i = SQLiteHandler.InsertUser(txtName.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), cboRole.Text, password);
                if (i > 0)
                {
                    lblMsg.Text = "User Created Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Blue;
                    btnclose.Enabled = true;
                }
                else
                {
                    lblMsg.Text = "Record could not created";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {

                lblMsg.Text = "An error has occured";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                progress = "Completed";
                lblprogress.Invoke(new Action(loadui));
                btnclose.Enabled = true;
            }
            
        }
        private void loadui()
        {
            lblprogress.Text = progress;
        }
        private void FrmCreateUser_Load(object sender, EventArgs e)
        {
            Dictionary<string, int> newItem = new Dictionary<string, int>();
            newItem.Add("Admin", 1);
            newItem.Add("Sub Admin", 2);

            cboRole.DataSource = new BindingSource(newItem, null);
            cboRole.DisplayMember = "Key";
            cboRole.ValueMember = "Value";
        }
    
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void Btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
