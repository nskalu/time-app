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
    public partial class StudentAttendanceReport : Form
    {
        public StudentAttendanceReport()
        {
            InitializeComponent();
        }
        DataTable dt;
        string matricno;
        private void StudentAttendanceReport_Load(object sender, EventArgs e)
        {
            try
            {
                string matricno = txtMatricno.Text;
                dt = SQLiteHandler.GetAttendanceHistory(matricno).Tables[0];
                gdvHistory.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error has occured.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string matricno = txtMatricno.Text;
                dt = SQLiteHandler.GetAttendanceHistory(matricno).Tables[0];
                gdvHistory.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error has occured", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtFromGrid = new DataTable();
                dtFromGrid = gdvHistory.DataSource as DataTable;
                SaveAsExcel(dtFromGrid, "Student Attendance");
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error has occured while saving the excel", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
