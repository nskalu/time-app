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
    public partial class frmCreateSession : Form
    {
        public frmCreateSession()
        {
            InitializeComponent();
        }
     
        private void FrmCreateSession_Load(object sender, EventArgs e)
        {
            Dictionary<string, int> semesters = new Dictionary<string, int>();
            semesters.Add("Select...", 0);
            semesters.Add("1st", 1);
            semesters.Add("2nd", 2);

            cboSemester.DataSource = new BindingSource(semesters, null);
            cboSemester.DisplayMember = "Key";
            cboSemester.ValueMember = "Value";
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
            //calculate no of weekdays btw start and end
            txtnoofAttendance.Text= CalculateWeekdays(dtpStartdate.Value, dtpenddate.Value).ToString();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
          
            //calculate no of sat and sun btw start and end
            txtnoofAttendance.Text = CountWeekEnds(dtpStartdate.Value, dtpenddate.Value).ToString();
        }
        private int CalculateWeekdays(DateTime dtmStart, DateTime dtmEnd)
        {
            int dowStart = ((int)dtmStart.DayOfWeek == 0 ? 7 : (int)dtmStart.DayOfWeek);
            int dowEnd = ((int)dtmEnd.DayOfWeek == 0 ? 7 : (int)dtmEnd.DayOfWeek);
            TimeSpan tSpan = dtmEnd - dtmStart;
            if (dowStart <= dowEnd)
            {
                return (((tSpan.Days / 7) * 5) + Math.Max((Math.Min((dowEnd + 1), 6) - dowStart), 0));
            }
            return (((tSpan.Days / 7) * 5) + Math.Min((dowEnd + 6) - Math.Min(dowStart, 6), 5));

        }
       
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string session, semester, progammode, noofattendance;
                DateTime startdate, enddate;
                session = txtsession.Text;
                semester = cboSemester.Text;
                noofattendance = txtnoofAttendance.Text;
                startdate = dtpStartdate.Value;
                enddate = dtpenddate.Value;
                if (session == "" || semester == "" || noofattendance == "" || startdate.ToString() == "" || enddate.ToString() == "" )
                {
                    MessageBox.Show("Ensure all fields are filled", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataTable data;
                data = SQLiteHandler.CheckSessionExists(session, semester).Tables[0];
                if (data.Rows.Count > 0)
                {
                    MessageBox.Show("Session/Semester has already been created", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (rdbfulltime.Checked)
                    progammode = "Full Time";
                else
                    progammode = "Part Time";
                int r;
                try
                {
                    r = SQLiteHandler.UpdateInActiveSessionSemester();
                }
                catch (Exception)
                {

                    lblmsg.Text = "Error has occured while creating the semester";
                }
                int i;
                i = SQLiteHandler.CreateSessionSemester(session,semester,progammode,noofattendance,startdate,enddate);
                
                if (i>0)
                {
                    lblmsg.Text = "Session/Semester Successfully created";
                    lblmsg.ForeColor = Color.Blue;
                    
                }
                else
                {
                    lblmsg.Text = "Session and semester not created";
                    lblmsg.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {

                lblmsg.Text = "An error has occured while creating the semester";
                lblmsg.ForeColor = Color.Red;
            }
        }
        public static int CountWeekEnds(DateTime startDate, DateTime endDate)
        {
            int weekEndCount = 0;
            if (startDate > endDate)
            {
                DateTime temp = startDate;
                startDate = endDate;
                endDate = temp;
            }
            TimeSpan diff = endDate - startDate;
            int days = diff.Days;
            for (var i = 0; i <= days; i++)
            {
                var testDate = startDate.AddDays(i);
                if (testDate.DayOfWeek == DayOfWeek.Saturday || testDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    weekEndCount += 1;
                }
            }
            return weekEndCount;
        }

    }
}
