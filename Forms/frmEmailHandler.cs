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
using System.Net.Mail;
using System.Net;
using ClosedXML.Excel;
using System.IO;

namespace TimeProject.Forms
{
     
    public partial class frmEmailHandler : Form
    {
        DataTable dt, dt1;
        private const int CP_NOCLOSE_BUTTON = 0x200;
        static string Attendancefolder = @"C:\Students Attendance";
        public frmEmailHandler()
        {
            InitializeComponent();
        }

    

        private void BtnsendAll_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Visible = true;
                progressBar1.Maximum = 100;
                progressBar1.Step = 1;
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync();
                dt = SQLiteHandler.GetAllStudentMatric().Tables[0];
                if (dt.Rows.Count>0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        sendbulkemail(row["matricno"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("No student record was found on the database", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
               if (emailcount>0)
                {
                    lblmsg.Text = "Email has been sent out successfully to all students with attendance";
                    lblmsg.ForeColor = Color.Blue;
                }
                   
            }
            catch (Exception ex)
            {

                MessageBox.Show("Unable to send Bulk Email, Ensure you are connected to the internet and try again", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundworker1_DoWork(object sender, DoWorkEventArgs e)
        {
      
            var backgroundWorker = sender as BackgroundWorker;
            for (int j = 0; j < 100000; j++)
            {
                Calculate(j);
                backgroundWorker.ReportProgress((j * 100) / 100000);
            }
        }
        private void Calculate(int i)
        {
            double pow = Math.Pow(i, i);
        }
        private void backgroundworker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar   
            progressBar1.Value = e.ProgressPercentage;
            // Set the text.  
            this.Text = e.ProgressPercentage.ToString();
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

        private void FrmEmailHandler_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
        }

        private void BtnSendsingle_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Visible = true;
                progressBar1.Maximum = 100;
                progressBar1.Step = 1;
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync();
                if (txtmatricno.Text.Trim()=="")
                {
                    MessageBox.Show("Please enter Matric Number to perform this operation", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string matricno = txtmatricno.Text;
                dt = SQLiteHandler.GetAttendanceHistory(matricno).Tables[0];
                if (dt.Rows.Count==0)
                {
                    MessageBox.Show("No attendance record was found for "+txtmatricno.Text, "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dt1 = SQLiteHandler.GetStudentDetail(matricno).Tables[0];
                //smtp client details
                SmtpClient clientdetails = new SmtpClient();
                clientdetails.Port = 587;
                clientdetails.Host = "smtp.gmail.com";
                clientdetails.EnableSsl = true;
                clientdetails.DeliveryMethod = SmtpDeliveryMethod.Network;
                clientdetails.UseDefaultCredentials = false;
                clientdetails.Credentials = new NetworkCredential("swu.universitas@gmail.com", "swu@uni@");

                //message details
                string emailTo = dt1.Rows[0]["email"].ToString();
                string surname = dt1.Rows[0]["surname"].ToString();
                string firstname = dt1.Rows[0]["firstname"].ToString();
                MailMessage mailmsg = new MailMessage();
                mailmsg.From = new MailAddress("swu.universitas@gmail.com");
                mailmsg.To.Add(emailTo);
                mailmsg.Subject = "Student Attendance History";
                mailmsg.Body = "Dear "+firstname+","+ Environment.NewLine+"Kindly find the attached file for your school attendance details and percentage."+ Environment.NewLine+ Environment.NewLine+"For Management," + Environment.NewLine+"South Western University, Okun-Owa";

                //create an excel attachment
                if (!Directory.Exists(Attendancefolder))
                {
                    Directory.CreateDirectory(Attendancefolder);
                }
                string attendancefile = Attendancefolder + @"\"+surname+" attendance.xlsx";


                using (var file = File.OpenWrite(attendancefile))
                {
                  
                }

                DataTable dtFromGrid = new DataTable();
                string sheetname = surname + " Attendance details";
                dtFromGrid = dt;
                XLWorkbook wb = new XLWorkbook();
                wb.Worksheets.Add(dt, sheetname);
                wb.SaveAs(attendancefile);

                //add the attachment
                Attachment attachment = new Attachment(attendancefile);
                mailmsg.Attachments.Add(attachment);

                clientdetails.Send(mailmsg);

                //if (File.Exists(attendancefile))
                //{
                    //File.Delete(attendancefile);

                //}
                lblmsg.Text = "Email sent successfully";
            }
            catch (Exception ex)
            {

                lblmsg.Text = "An error has occured please exit and relaunch the application!";
                MessageBox.Show("Unable to send Email, Ensure you are connected to the internet and try again, or exit and relaunch the application", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                
            }
        }
        int emailcount = 0;
        private void sendbulkemail(string matricno)
        {
            try
            {
                dt = SQLiteHandler.GetAttendanceHistory(matricno).Tables[0];
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No attendance record was found for " + txtmatricno.Text, "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dt1 = SQLiteHandler.GetStudentDetail(matricno).Tables[0];
                //smtp client details
                SmtpClient clientdetails = new SmtpClient();
                clientdetails.Port = 587;
                clientdetails.Host = "smtp.gmail.com";
                clientdetails.EnableSsl = true;
                clientdetails.DeliveryMethod = SmtpDeliveryMethod.Network;
                clientdetails.UseDefaultCredentials = false;
                clientdetails.Credentials = new NetworkCredential("swu.universitas@gmail.com", "swu@uni@");

                //message details
                string emailTo = dt1.Rows[0]["email"].ToString();
                string surname = dt1.Rows[0]["surname"].ToString();
                string firstname = dt1.Rows[0]["firstname"].ToString();
                MailMessage mailmsg = new MailMessage();
                mailmsg.From = new MailAddress("swu.universitas@gmail.com");
                mailmsg.To.Add(emailTo);
                mailmsg.Subject = "Student Attendance History";
                mailmsg.Body = "Dear " + firstname + "," + Environment.NewLine + "Kindly find the attached file for your school attendance details and percentage." + Environment.NewLine + Environment.NewLine + "For Management," + Environment.NewLine + "South Western University, Okun-Owa";

                //create an excel attachment
                if (!Directory.Exists(Attendancefolder))
                {
                    Directory.CreateDirectory(Attendancefolder);
                }
                string attendancefile = Attendancefolder + @"\" + surname + " attendance.xlsx";


                using (var file = File.OpenWrite(attendancefile))
                {

                }

                DataTable dtFromGrid = new DataTable();
                string sheetname = surname + " Attendance details";
                dtFromGrid = dt;
                XLWorkbook wb = new XLWorkbook();
                wb.Worksheets.Add(dt, sheetname);
                wb.SaveAs(attendancefile);

                //add the attachment
                Attachment attachment = new Attachment(attendancefile);
                mailmsg.Attachments.Add(attachment);

                clientdetails.Send(mailmsg);
                emailcount++;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Unable to send Bulk Email, Ensure you are connected to the internet and try again", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

    }
}
