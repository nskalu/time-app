using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;
namespace TimeProject.Classes
{
    public class SQLiteHandler
    {

        public static SQLiteConnection conn;
        static string ZIpFileFolder = @"C:\SWU3196D-621C-478A-81F7-35C16EF7BSWU";
        public static string SQLiteDB = ZIpFileFolder + @"\SWULite.db";
        public static string ConnectionString()
        {
            conn = new SQLiteConnection("Data Source=" + SQLiteDB + "; Version = 3; New = True; Compress = True; Default TimeOut=30; Max Pool Size=100");
            return conn.ConnectionString; ;
        }

        public static Boolean CreateSqliteDB()
        {
            try
            {
                if (!Directory.Exists(ZIpFileFolder))
                {
                    Directory.CreateDirectory(ZIpFileFolder);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("An error has occured while creating the database");
            }
            try
            {
                if (!File.Exists(SQLiteDB))
                {
                    SQLiteConnection.CreateFile(SQLiteDB);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error has occured while creating the database " + ex.Message + " Inner exception: " + ex.InnerException);
            }
            if (File.Exists(SQLiteDB))
                return true;
            return false;
        }

        public static void CreateTable()
        {

            try
            {
                SQLiteConnection connection;
                string conn = SQLiteHandler.ConnectionString();
                connection = new SQLiteConnection(conn);
                string CreateUsersql = "CREATE TABLE if not exists AppUsers(Id int Primary Key,StaffName VARCHAR(20), Email varchar(50), Phone varchar(20), Password varchar(20), Role varchar(20))";
                string CreateStudentsql = "CREATE TABLE if not exists Students(Id int Primary Key,Surname VARCHAR(20), FirstName varchar(50), MiddleName varchar(50), MatricNo varchar(50), Level int, dept varchar(100), Semester varchar(50), Email varchar(50), Phone varchar(20), Passport BLOB)";
                string CreateFinger = "CREATE TABLE if not exists StudentsFingerprint(StudentId integer, MatricNo varchar(50), LeftFinger BLOB, RightFinger BLOB)";
                string CreateAttendance = "CREATE TABLE if not exists StudentsAttendance(StudentId integer, MatricNo varchar(50), TimeIn Datetime, TimeOut Datetime, DateIn varchar(20), semester varchar(5), session varchar(10))";
                string CreateSession = "CREATE TABLE if not exists AcademicSessionSemester(Session varchar(50), Semester int, StartDate Datetime, EndDate Datetime, ProgramMode varchar(20), ExpectedNofAttendance int, IsActive bit)";
                string CreatePercentageTable = "CREATE TABLE if not exists AttendancePercentage(Matricno varchar(50), Session varchar(50), Semester int, Percentage varchar(5))";
                SQLiteCommand Command = new SQLiteCommand(CreateUsersql, connection);
                SQLiteCommand Command2 = new SQLiteCommand(CreateStudentsql, connection);
                SQLiteCommand Command3 = new SQLiteCommand(CreateFinger, connection);
                SQLiteCommand Command4 = new SQLiteCommand(CreateAttendance, connection);
                SQLiteCommand Command5 = new SQLiteCommand(CreateSession, connection);
                SQLiteCommand Command6 = new SQLiteCommand(CreatePercentageTable, connection);
                Command.CommandType = CommandType.Text;
                Command2.CommandType = CommandType.Text;
                Command3.CommandType = CommandType.Text;
                Command4.CommandType = CommandType.Text;
                Command5.CommandType = CommandType.Text;
                Command.CommandTimeout = 0; connection.Open();
                Command.ExecuteNonQuery();
                Command2.ExecuteNonQuery();
                Command3.ExecuteNonQuery();
                Command4.ExecuteNonQuery();
                Command5.ExecuteNonQuery();
                Command6.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //return;
                throw new Exception("An error has occured while creating the database tables" + ex.Message + " Inner exception: " + ex.InnerException);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

            }


        }

        public static int InsertUser(string StaffName, string Email, string Phone, string Role, string Password)
        {
            try
            {
                int i;
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                SQLiteParameter[] param = new[] { new SQLiteParameter("?@StaffName", StaffName), new SQLiteParameter("?@Email", Email), new SQLiteParameter("?@Phone", Phone), new SQLiteParameter("?@Password", Password), new SQLiteParameter("?@Role", Role) };
                string InsertUserQuery = "insert into AppUsers(StaffName, Email, Phone, Password, Role) values('" + StaffName + "','" + Email + "','" + Phone + "','" + Password + "','" + Role + "')";
                SQLiteCommand Command = new SQLiteCommand(InsertUserQuery, Connection);
                Command.CommandType = CommandType.Text;
                Command.CommandTimeout = 0; Connection.Open();
                i = Command.ExecuteNonQuery();
                return i;
            }
            catch (Exception ex)
            {

                return -1;
            }
            finally { conn.Close(); }

        }
        public static int InsertStudent(string surname, string Email, string Phone, string semester, string matricno, string firstname, string middlename, string dept, string level, byte[] passport)
        {
            try
            {
                int i;
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                // string InsertUserQuery = "insert into Students(surname, firstname, middlename, level, matricno,Email, Phone, semester, dept, Passport) values('" + surname + "','" + firstname + "','" + middlename + "','" + level + "','" + matricno + "','" + Email + "','" + Phone + "','" + semester+"','" + dept + "','"+passport+"')";
                using (SQLiteCommand com = new SQLiteCommand("INSERT INTO Students (surname, firstname, middlename, level, matricno,Email, Phone, semester, dept, Passport) VALUES (@surname,@firstname,@middlename,@level,@matricno,@Email,@Phone,@semester,@dept,@Passport)", Connection))
                {
                    Connection.Open();
                    com.Parameters.AddWithValue("@surname", surname);
                    com.Parameters.AddWithValue("@firstname", firstname);
                    com.Parameters.AddWithValue("@middlename", middlename);
                    com.Parameters.AddWithValue("@level", level);
                    com.Parameters.AddWithValue("@matricno", matricno);
                    com.Parameters.AddWithValue("@Email", Email);
                    com.Parameters.AddWithValue("@Phone", Phone);
                    com.Parameters.AddWithValue("@semester", semester);
                    com.Parameters.AddWithValue("@dept", dept);
                    com.Parameters.AddWithValue("@Passport", passport);
                    i = com.ExecuteNonQuery();
                }
                return i;
            }
            catch (Exception ex)
            {

                return -1;
            }
            finally { conn.Close(); }

        }

        public static int InsertStudentAttendance(string matricno, DateTime TimeIn, string session, string semester)
        {
            try
            {
                int i;
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string InsertAttendanceQuery = "insert into StudentsAttendance( matricno,TimeIn,DateIn,session,semester) values('" + matricno + "','" + DateTime.Now.TimeOfDay + "','" + DateTime.Now.Date + "','" + session + "','" + semester + "')";
                SQLiteCommand Command = new SQLiteCommand(InsertAttendanceQuery, Connection);
                Command.CommandType = CommandType.Text;
                Command.CommandTimeout = 0; Connection.Open();
                i = Command.ExecuteNonQuery();
                return i;
            }
            catch (Exception ex)
            {

                return -1;
            }
            finally { conn.Close(); }

        }
        public static int InsertStudentAttendancePerecntage(string matricno, string session, string semester, string percentage)
        {
            try
            {
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string getpercentage = "select * from AttendancePercentage where matricno='" + matricno + "' and session='" + session + "' and semester='" + semester + "'";
                DataSet ds;
                var da = new SQLiteDataAdapter(getpercentage, Connection);
                Connection.Open();
                ds = new DataSet();
                da.Fill(ds);
                int i;
                string InsertAttendancepercentage = "insert into AttendancePercentage( matricno,session,semester,percentage) values('" + matricno + "','" + session + "','" + semester + "','" + percentage + "')";
                string updatepercentage = "update AttendancePercentage set Percentage='" + percentage + "' where matricno='" + matricno + "' and session='" + session + "' and semester='" + semester + "'";
                SQLiteCommand Command = new SQLiteCommand(ds.Tables[0].Rows.Count > 0 ? updatepercentage : InsertAttendancepercentage, Connection);
                Command.CommandType = CommandType.Text;
                Command.CommandTimeout = 0;
                i = Command.ExecuteNonQuery();
                return i;
            }
            catch (Exception ex)
            {

                return -1;
            }
            finally { conn.Close(); }

        }
        public static int CreateSessionSemester(string session, string semester, string programmode, string expectedattendance, DateTime startdate, DateTime enddate)
        {
            try
            {
                int i;
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string Insertsemester = "insert into AcademicSessionSemester( session,semester,programmode,ExpectedNofAttendance,startdate,enddate,isactive) values('" + session + "','" + semester + "','" + programmode + "','" + expectedattendance + "','" + startdate + "','" + enddate + "','" + true + "')";
                SQLiteCommand Command = new SQLiteCommand(Insertsemester, Connection);
                Command.CommandType = CommandType.Text;
                Command.CommandTimeout = 0; Connection.Open();
                i = Command.ExecuteNonQuery();
                return i;
            }
            catch (Exception ex)
            {

                return -1;
            }
            finally { conn.Close(); }

        }

        public static int UpdateInActiveSessionSemester()
        {
            try
            {
                int i;
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string Insertsemester = "Update AcademicSessionSemester set IsActive = False";
                SQLiteCommand Command = new SQLiteCommand(Insertsemester, Connection);
                Command.CommandType = CommandType.Text;
                Command.CommandTimeout = 0; Connection.Open();
                i = Command.ExecuteNonQuery();
                return i;
            }
            catch (Exception ex)
            {

                return -1;
            }
            finally { conn.Close(); }

        }


        public static int UpdateStudentAttendance(string matricno)
        {
            try
            {
                int i;
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string UpdateTimeOutQuery = "Update StudentsAttendance set TimeOut ='" + DateTime.Now.TimeOfDay + "' where matricno = '" + matricno + "'and DateIn= '" + DateTime.Now.Date + "'";
                SQLiteCommand Command = new SQLiteCommand(UpdateTimeOutQuery, Connection);
                Command.CommandType = CommandType.Text;
                Command.CommandTimeout = 0; Connection.Open();
                i = Command.ExecuteNonQuery();
                return i;
            }
            catch (Exception)
            {

                return -1;
            }
            finally { conn.Close(); }

        }

        public static int DeleteStudentRecord(string matricno)
        {
            try
            {
                int i;
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string deleteQuery = "Delete from Students  where matricno = '" + matricno + "'";
                SQLiteCommand Command = new SQLiteCommand(deleteQuery, Connection);
                Command.CommandType = CommandType.Text;
                Command.CommandTimeout = 0; Connection.Open();
                i = Command.ExecuteNonQuery();
                return i;
            }
            catch (Exception)
            {

                return -1;
            }
            finally { conn.Close(); }

        }
        public static int InsertStudentFinger(string matricno, byte[] RightFinger, byte[] LeftFinger)
        {
            try
            {
                int i;
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                // string InsertFingerQuery = "insert into StudentsFingerprint(matricno, leftFinger, RightFinger) values('" + matricno + "','" + LeftFinger + "','" + RightFinger  + "')";
                using (SQLiteCommand com = new SQLiteCommand("INSERT INTO StudentsFingerprint (matricno, leftFinger, RightFinger) VALUES (@matricno,@RightFinger,@LeftFinger)", Connection))
                {
                    Connection.Open();
                    com.Parameters.AddWithValue("@matricno", matricno);
                    com.Parameters.AddWithValue("@RightFinger", RightFinger);
                    com.Parameters.AddWithValue("@LeftFinger", LeftFinger);
                    i = com.ExecuteNonQuery();
                }
                return i;
            }
            catch (Exception ex)
            {

                return -1;
            }
            finally { conn.Close(); }

        }

        public static DataSet GetUser(string Email, string password)
        {
            try
            {
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string getUserQuery = "select * from AppUsers where Email='" + Email + "' and password='" + password + "'";
                DataSet ds;
                var da = new SQLiteDataAdapter(getUserQuery, Connection);
                Connection.Open();
                ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally { conn.Close(); }

        }
        public static DataSet GetFingerprints()
        {
            try
            {
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string getfingerQuery = "select * from StudentsFingerprint";
                DataSet ds;
                var da = new SQLiteDataAdapter(getfingerQuery, Connection);
                Connection.Open();
                ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally { conn.Close(); }

        }
        public static DataSet GetAttendance(string MatricNo)
        {
            try
            {
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string getattendanceQuery = "select * from StudentsAttendance where MatricNo='" + MatricNo + "' and DateIn='" + (DateTime.Now).Date + "'";
                DataSet ds;
                var da = new SQLiteDataAdapter(getattendanceQuery, Connection);
                Connection.Open();
                ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally { conn.Close(); }

        }
        public static DataSet GetAttendanceHistory(string MatricNo)
        {
            try
            {
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string getattendanceQuery = "select StudentsAttendance.DateIn, StudentsAttendance.TimeIn, StudentsAttendance.TimeOut, Attendancepercentage.percentage from StudentsAttendance inner join Attendancepercentage " +
                    "on StudentsAttendance.Matricno=Attendancepercentage.MatricNo where StudentsAttendance.MatricNo='" + MatricNo + "'";
                DataSet ds;
                var da = new SQLiteDataAdapter(getattendanceQuery, Connection);
                Connection.Open();
                ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally { conn.Close(); }

        }
        public static DataTable GetSession()
        {
            try
            {
                DataTable dt;
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string getattendanceQuery = "select Session, Semester, ExpectedNofAttendance from AcademicSessionSemester where isactive='" + true + "' or isactive=1";
                DataSet ds;
                var da = new SQLiteDataAdapter(getattendanceQuery, Connection);
                Connection.Open();
                ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally { conn.Close(); }

        }
        public static DataSet GetAllStudentMatric()
        {
            try
            {
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string getmatric = "select matricno from Students";
                DataSet ds;
                var da = new SQLiteDataAdapter(getmatric, Connection);
                Connection.Open();
                ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally { conn.Close(); }

        }
        public static DataSet GetAttendanceReportAll(string session, string semester)
        {
            try
            {
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string getattendanceReportQuery = " select students.Surname ||' '|| students.Firstname As Name,students.MatricNo,(select count(MatricNo) from StudentsAttendance where matricno=Students.MatricNo) as NoAttended, AttendancePercentage.Percentage from " +
                                                "StudentsAttendance inner join students on StudentsAttendance.MatricNo = Students.MatricNo inner join AttendancePercentage on AttendancePercentage.MatricNo = Students.MatricNo " +
                                                "where StudentsAttendance.session='" + session + "' and StudentsAttendance.semester='" + semester + "' group by Students.MatricNo";
                DataSet ds;
                var da = new SQLiteDataAdapter(getattendanceReportQuery, Connection);
                Connection.Open();
                ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally { conn.Close(); }

        }
        public static DataSet GetAttendanceReport(string matricno)
        {
            try
            {
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string getattendanceReportQuery = "select count(MatricNo) from StudentsAttendance where matricno='" + matricno + "'";
                DataSet ds;
                var da = new SQLiteDataAdapter(getattendanceReportQuery, Connection);
                Connection.Open();
                ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally { conn.Close(); }

        }
        public static DataSet GetAttendanceList(string MatricNo)
        {
            try
            {
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string getattendanceQuery = "select students.Surname ||' '|| students.Firstname As Name, students.MatricNo,StudentsAttendance.TimeIn,StudentsAttendance.TimeOut from StudentsAttendance inner join students on StudentsAttendance.MatricNo=Students.MatricNo where DateIn='" + (DateTime.Now).Date + "'";
                DataSet ds;
                var da = new SQLiteDataAdapter(getattendanceQuery, Connection);
                Connection.Open();
                ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally { conn.Close(); }

        }
        public static DataSet GetAttendanceReport(string dept, string level)
        {
            try
            {
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string getattendanceReportQuery = "select students.Surname ||' '|| students.Firstname As Name,students.MatricNo,(select count(MatricNo) from StudentsAttendance where matricno=Students.MatricNo) as NoAttended, AttendancePercentage.Percentage from " +
                                                "StudentsAttendance inner join students on StudentsAttendance.MatricNo = Students.MatricNo inner join AttendancePercentage on AttendancePercentage.MatricNo = Students.MatricNo " +
                                                "where students.dept='" + dept + "' and students.Level='" + level + "' group by Students.MatricNo";
                DataSet ds;
                var da = new SQLiteDataAdapter(getattendanceReportQuery, Connection);
                Connection.Open();
                ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally { conn.Close(); }

        }
        public static DataSet GetStudentDetail(string MatricNo)
        {
            try
            {
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string getstudentQuery = "select * from Students where MatricNo='" + MatricNo + "'";
                DataSet ds;
                var da = new SQLiteDataAdapter(getstudentQuery, Connection);
                Connection.Open();
                ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally { conn.Close(); }

        }
        public static DataSet CheckStudentExists(string MatricNo, string email, string phoneno)
        {
            try
            {
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string getstudentQuery = "select * from Students where MatricNo='" + MatricNo + "' or Email='" + email + "' or Phone='" + phoneno + "'";
                DataSet ds;
                var da = new SQLiteDataAdapter(getstudentQuery, Connection);
                Connection.Open();
                ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally { conn.Close(); }

        }
        public static DataSet CheckSessionExists(string session, string semester)
        {
            try
            {
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string checksession = "select * from AcademicSessionSemester where session='" + session + "' and semester='" + semester + "'";
                DataSet ds;
                var da = new SQLiteDataAdapter(checksession, Connection);
                Connection.Open();
                ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally { conn.Close(); }

        }

        public static DataSet CheckStaffExists(string email, string phoneno)
        {
            try
            {
                string conn = SQLiteHandler.ConnectionString();
                SQLiteConnection Connection = new SQLiteConnection(conn);
                string getstudentQuery = "select * from appusers where Email='" + email + "' or Phone='" + phoneno + "'";
                DataSet ds;
                var da = new SQLiteDataAdapter(getstudentQuery, Connection);
                Connection.Open();
                ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally { conn.Close(); }

        }
    }
}
