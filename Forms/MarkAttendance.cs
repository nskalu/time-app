using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalPersona.Standards;
using DPFP;
using DPFP.Capture;
using DPFP.Processing;
using System.IO;
using System.Drawing.Imaging;
using TimeProject.Classes;
using System.Globalization;
using System.Threading;
using TimeSheetDpSidLib;


namespace TimeProject.Forms
{
    delegate void FunctionCall(dynamic param);
    public partial class MarkAttendance : Form, DPFP.Capture.EventHandler, IDisposable
    {
        public MarkAttendance()
        {
            InitializeComponent();
        }

       

        public System.ComponentModel.ISynchronizeInvoke IObj;
        public byte[] bmpByte;
        public System.Drawing.Bitmap Resultbmp;
        public System.Drawing.Bitmap Derivedbmp;
        private FileStream ImageStream;
        Bitmap LeftBmp, RightBmp;
        DataHolder DataHold;
        Image returnImage;
        // '---------------------------
        private DPFP.Capture.Capture Capturer = new DPFP.Capture.Capture();
        private DPFP.Processing.Enrollment Enroller;
        private DPFP.Verification.Verification Verificator;
        private DPFP.Template Template;
        public event OnTemplateEventHandler OnTemplate;

        public delegate void OnTemplateEventHandler(object template);
        private DataTable dt, dt1;
        private string Message, MatricNo = "";
        private Bitmap TrueBitmap = null/* TODO Change to default(_) if this is not a reference type */;
        private int Dpi = 700;
        Byte[] inputData = null;
        DigitalPersona.Standards.InputParameterForRaw inpRaw = null;
        DPFP.Sample DPsample;
        DPFP.FeatureSet DPFeatures;
        DPFP.Template DPTemplate;
        byte[] ISOFMD;
        DataGridViewRow row;
        String labelMessage; string session; string semester; int NoExpected;
         private void MarkAttendance_Load(object sender, EventArgs e)
        {
            try
            {
              

                dt = SQLiteHandler.GetSession();
                if (dt.Rows.Count>0)
                {
                session = dt.Rows[0]["Session"].ToString();
                semester = dt.Rows[0]["Semester"].ToString();
                NoExpected = int.Parse(dt.Rows[0]["ExpectedNofAttendance"].ToString());
                }
                else
                {
                    lblMsg.Text = "You can't mark attendance yet, No Active Semester has been created";
                    return;
                }
                
                Cursor = Cursors.WaitCursor;

                // set culture
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB", false);
                // '===================
                Capturer = new DPFP.Capture.Capture();               // Create a capture operation.
                
                    try
                    {
                        if ((Capturer != null))
                    {
                        Capturer.StartCapture();
                        Capturer.EventHandler = this;
                    }
                                                        // Subscribe for capturing events.
                        else
                            throw new Exception("Can't initiate capture operation! Please exit and relaunch the application");
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            //logger.WriteLog(ex);
                        }
                        catch (Exception exx)
                        {
                        }
                        MessageBox.Show("Can't initiate capture operation! Please exit and relaunch the application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
                Enroller = new DPFP.Processing.Enrollment();
                Verificator = new DPFP.Verification.Verification();

                //GetAllScanner(cboScanner); btnStartCapture.PerformClick();


                Application.DoEvents();
            }
            catch (Exception ex)
            {
                try
                {
                    //logger.WriteLog(ex);
                }
                catch (Exception exx)
                {
                }
                //MsgBox(ex.Message, MsgBoxStyle.Exclamation, Application.ProductName);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            try
            {
                if (!(Capturer == null))
                {
                    try
                    {
                        Capturer.StartCapture();
                        SetPrompt("Using the fingerprint reader, scan your fingerprint.");

                    }
                    catch (Exception ex)
                    {
                        SetPrompt("Can't initiate capture! Please exit and relaunch the application");
                    }
                }
            }
            catch (Exception ex)
            {
                //MsgBox(ex.Message, MsgBoxStyle.Exclamation, Application.ProductName);
            }
            getCurrentAttendanceList();
        }
        
        private void getCurrentAttendanceList()
        {
            try
            {
                dt = SQLiteHandler.GetAttendanceList(MatricNo).Tables[0];
                int i = 0;
                //gdvAttendanceList.DataSource = dt;
                foreach (DataRow row in dt.Rows)
                {
                   
                    DataGridViewRow rw = (DataGridViewRow)gdvAttendanceList.Rows[0].Clone();
                    rw.Cells[0].Value = dt.Rows[i]["Name"];
                    rw.Cells[1].Value = dt.Rows[i]["matricno"];
                    rw.Cells[2].Value = dt.Rows[i]["TimeIn"];
                    rw.Cells[3].Value = dt.Rows[i]["TimeOut"];
                    gdvAttendanceList.Rows.Add(rw);
                    i++;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error has occured while getting report "+ ex.Message+ " inner exception: "+ex.InnerException.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            MakeReport("The " + getFingerType() + " fingerprint was captured.");
            Message = null;

            // use verification method
            Process(Sample);
            //check for saturdays and sundays and return if not saturday or sunday
            if (GetFingerPrints(LeftBmp))//leftbmp here does not denote left finger, it could be right finger
            {
                int AttendanceCheck = InsertAttendance(MatricNo);

                if (AttendanceCheck == 3)
                {
                    labelMessage = "You have signed in successfully";
                    picImage.Image = null;
                    lblMsg.Invoke(new Action(LoadUI));
                   
                }
                else if (AttendanceCheck == 2)
                {
                    labelMessage = "You are not expected to sign in yet";
                    lblMsg.Invoke(new Action(ShowMsg));
                }
                else if (AttendanceCheck == 1)
                {
                    labelMessage = "You have signed out successfully";
                    lblMsg.Invoke(new Action(LoadUI));
                }
                else 
                {
                    lblMsg.Text = "Not Successful";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                labelMessage = "Identification Failed";
                lblMsg.Invoke(new Action(ShowMsg));
            }
            
        }

        private void ShowMsg()
        {
            lblMsg.Text = labelMessage;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
        private void LoadUI()
        {dt=SQLiteHandler.GetStudentDetail(MatricNo).Tables[0];
            dt1 = SQLiteHandler.GetAttendance(MatricNo).Tables[0]; 
                    DataGridViewRow row = (DataGridViewRow)gdvAttendanceList.Rows[0].Clone();
                    picImage.Image = byteArrayToImage((byte[])dt.Rows[0]["Passport"]);
            gdvAttendanceList.Rows.Clear();
            getCurrentAttendanceList();
     
            lblMsg.Text = labelMessage;
            lblMsg.ForeColor = System.Drawing.Color.Blue;
        }
    
        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The " + getFingerType() + " finger was removed from the fingerprint reader.");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The fingerprint reader was touched.");
        }
        
        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
        
            MakeReport("The fingerprint reader was connected and started.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {

            MakeReport("The fingerprint reader was disconnected.");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {

            if (CaptureFeedback == CaptureFeedback.Good)
            {
                MakeReport("The quality of the " + getFingerType() + " fingerprint sample is good.");
            }
            else
            {
                MakeReport("The quality of the " + getFingerType() + " fingerprint sample is poor.");
            }


        }
        protected void MakeReport(object status)
        {
            try
            {
                this.Invoke(new FunctionCall(_MakeReport), status);
            }
            catch (Exception ex)
            {
                try
                {
                    //logger.WriteLog(ex);
                }
                catch (Exception exx)
                {
                }
            }
        }
        private void _MakeReport(dynamic status)
        {
            if (txtLog != null)
            {
                txtLog.AppendText(status + Environment.NewLine);
            }

        }

        public string getFingerType()
        {
            //to remove
            //return rdbLeftThumb.Checked ? "Left" : "Right";
            return "";
        }
        protected virtual void Process(DPFP.Sample Sample)
        {
            try
            {
                TrueBitmap = ConvertSampleToBitmap(Sample);
                DrawPicture(TrueBitmap);
            }
            catch (Exception ex)
            {
            }
        }
        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion convertor = new DPFP.Capture.SampleConversion();
            Bitmap bitmap = null/* TODO Change to default(_) if this is not a reference type */;
            convertor.ConvertToPicture(Sample, ref bitmap);
            return bitmap;
        }
        protected void DrawPicture(Image bmp)
        {
            try
            {
                this.Invoke(new FunctionCall(_DrawPicture), bmp);
            }
            catch (Exception ex)
            {
                try
                {
                    //logger.WriteLog(ex);
                }
                catch (Exception exx)
                {
                    MessageBox.Show("An error has occured during draw", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void _DrawPicture(dynamic bmp)
        {
           
                PicDerived.Image = new Bitmap(bmp, PicDerived.Size);
                LeftBmp = (System.Drawing.Bitmap)bmp;
          
        }

        public new void Dispose()
        {
            throw new NotImplementedException();
        }
        protected void SetPrompt(string text)
        {
            try
            {
                this.Invoke(new FunctionCall(_SetPrompt), text);
            }
            catch (Exception ex)
            {
                try
                {
                    // Base.logger.WriteLog(ex);
                }
                catch (Exception exx)
                {
                }
            }
        }

        private void _SetPrompt(dynamic text)
        {
            txtLog.Text = (string)text;
        }
        
        public static Bitmap BytesToBitmap(byte[] byteArray)
        {
            try
            {
                byte[] bytes = { 3, 10, 8, 25 };
                using (MemoryStream ms = new MemoryStream(byteArray))
                  {
                    ms.Position = 0;
                    dynamic t = byteArray;
                    Bitmap bmpfromDB = new Bitmap(ms);//new Bitmap( Image.FromStream(ms));
                    Image img = Image.FromStream(ms);
                    return bmpfromDB;
                  }
            }
            catch (Exception ex)
            {

                throw;
            }
            

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Capturer.StopCapture();
            this.Hide();
            Login frmlogin = new Login();
            frmlogin.Show();


        }

    

        private bool GetFingerPrints(Bitmap bmp)
        {
            try
            {
                dt = SQLiteHandler.GetFingerprints().Tables[0];
                if (dt.Rows.Count > 0)
                {
                   foreach (DataRow row in dt.Rows)
                    {
                        
                            LeftBmp = BytesToBitmap((byte[])row["LeftFinger"]);
                            RightBmp = BytesToBitmap((byte[])row["RightFinger"]);
                            MatricNo = row["MatricNo"].ToString();
                        DigitaPersonaClass obj = new DigitaPersonaClass();
                        if (obj.NonUnique(ref LeftBmp, ref bmp))
                        {
                            
                            return true;
                        }
                        if (obj.NonUnique(ref RightBmp, ref bmp))
                        {
                            return true;
                        }
                        
                    }
                }
                else
                {
                    return false;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private int InsertAttendance(String MatricNo)
        {
            try
            {
                int i;
                dt = SQLiteHandler.GetAttendance(MatricNo).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string timeout = dt.Rows[0]["TimeOut"].ToString();
                    if (dt.Rows[0]["TimeOut"].ToString() == "")
                    {
                        i = SQLiteHandler.UpdateStudentAttendance(MatricNo);
                        if (i > 0)
                        {
                            int r; float noAttended; float percentAttend; string percentage; float div;
                            dt = SQLiteHandler.GetAttendanceReport(MatricNo).Tables[0];
                            noAttended = int.Parse(dt.Rows[0]["count(MatricNo)"].ToString());
                            div = (noAttended / NoExpected);
                            percentAttend=div * 100;
                            percentage = Math.Round(percentAttend,2,MidpointRounding.ToEven).ToString() + "%";
                            r = SQLiteHandler.InsertStudentAttendancePerecntage(MatricNo, session, semester, percentage);
                                return 1;
                        }
                    }
                    else { return 2; }
                    
                }
                else
               { 

                i = SQLiteHandler.InsertStudentAttendance(MatricNo, DateTime.Now,session,semester);
                if (i > 0)
                {
                    return 3;
                }
               }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error has occured while saving your attendance", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 4;
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
                ms.Write(byteArrayIn, 0, byteArrayIn.Length);
                returnImage = Image.FromStream(ms, true);//Exception occurs here
            }
            catch { }
            return returnImage;
        }
        
    }
}
