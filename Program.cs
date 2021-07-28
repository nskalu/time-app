using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeProject.Forms;
using TimeProject.Classes;
using System.Data;


namespace TimeProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SQLiteHandler obj = new SQLiteHandler();

            SQLiteHandler.CreateSqliteDB();
            try
            {
                SQLiteHandler.CreateTable();
                DataTable data = SQLiteHandler.CheckStaffExists("admin", "0").Tables[0];
                if (data.Rows.Count == 0)
                {
                    int i;
                    i = SQLiteHandler.InsertUser("Admin User", "admin", "09011111111", "admin", "admin"); 
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error has occured while creating the database tables" + ex.Message + " Inner exception: " + ex.InnerException, "Table Creation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.Run(new MarkAttendance());
        }
    }
}
