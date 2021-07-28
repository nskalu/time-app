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
using ClosedXML.Excel;
namespace TimeProject.Forms
{
    public partial class GeneralReport : Form
    {
        DataTable dt;
        public GeneralReport()
        {
            InitializeComponent();
        }

        private void GeneralReport_Load(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, int> depts = new Dictionary<string, int>();
                depts.Add("Select...", 0);
                depts.Add("Computer Sci.", 1);
                depts.Add("Accountancy", 2);
                depts.Add("Mass Comm.", 3);
                depts.Add("Business Administration", 4);


                cboDept.DataSource = new BindingSource(depts, null);
                cboDept.DisplayMember = "Key";
                cboDept.ValueMember = "Value";

                Dictionary<string, int> level = new Dictionary<string, int>();
                level.Add("Select...", 0);
                level.Add("100", 100);
                level.Add("200", 200);
                level.Add("300", 300);
                level.Add("400", 400);

                cboSemester.DataSource = new BindingSource(level, null);
                cboSemester.DisplayMember = "Key";
                cboSemester.ValueMember = "Value";
                dt = SQLiteHandler.GetSession();
                if (dt.Rows.Count>0)
                {
                string session = dt.Rows[0]["Session"].ToString();
                string semester = dt.Rows[0]["Semester"].ToString();
                dt = SQLiteHandler.GetAttendanceReportAll(session,semester).Tables[0];
                gdvGeneralReport.DataSource = dt;
                }
                else
                    MessageBox.Show("No Active Session/Semester has been setup yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error has occured while loading the report", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gdvGeneralReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // here you can have column reference by using e.ColumnIndex
            DataGridViewImageCell cell = (DataGridViewImageCell)gdvGeneralReport.Rows[e.RowIndex].Cells[e.ColumnIndex];

            // ... do something ...
        }
        public static int SaveAsExcel(DataTable dt, string sheetname)
        {
            try
            {
                SaveFileDialog sd = new SaveFileDialog()
                {
                    Filter = "Excel Files|*.xlsx;"
                };

                if (sd.ShowDialog() == DialogResult.OK)
                {
                    string filename = sd.FileName;
                    XLWorkbook wb = new XLWorkbook();
                    wb.Worksheets.Add(dt, sheetname);
                    wb.SaveAs(filename);
                    return 1;
                }

                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private void Btnload_Click(object sender, EventArgs e)
        {
            try
            {
                dt = SQLiteHandler.GetAttendanceReport(cboDept.Text, cboSemester.Text).Tables[0];
                if (dt.Rows.Count>0)
                    gdvGeneralReport.DataSource = dt;
                else
                    MessageBox.Show("No Attendance report found for this semester", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show("An error has occured while loading the report", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtFromGrid = new DataTable();
                dtFromGrid = gdvGeneralReport.DataSource as DataTable;
                SaveAsExcel(dtFromGrid, "General Students Attendance");
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error has occured while saving the excel", "Error Message", MessageBoxButtons.OK,MessageBoxIcon.Error);
               
            }
        }
    }
}
