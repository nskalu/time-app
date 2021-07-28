using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeProject.Classes;
using DigitalPersona.Standards;
using DPFP;
using DPFP.Capture;
using DPFP.Processing;
using TimeSheetDpSidLib;
using System.Threading;
using System.Globalization;
using System.Diagnostics;


namespace TimeProject
{
    delegate void FunctionCall(dynamic param);
    public partial class frmRegisterStudent : Form, DPFP.Capture.EventHandler, IDisposable
    {
        //private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.ComponentModel.ISynchronizeInvoke IObj;
        public byte[] bmpByte;
        public System.Drawing.Bitmap Resultbmp;
        public System.Drawing.Bitmap Derivedbmp;
        private FileStream ImageStream;
        Bitmap LeftBmp, RightBmp;
        DataHolder DataHold; 
        // '---------------------------
        private DPFP.Capture.Capture Capturer = new DPFP.Capture.Capture();
        private DPFP.Processing.Enrollment Enroller;
        private DPFP.Verification.Verification Verificator;
        private DPFP.Template Template;
        public event OnTemplateEventHandler OnTemplate;

        public delegate void OnTemplateEventHandler(object template);

        private string Message = "";
        private Bitmap TrueBitmap = null/* TODO Change to default(_) if this is not a reference type */;
        private int Dpi = 700;
        Byte[] inputData = null;
        DigitalPersona.Standards.InputParameterForRaw inpRaw = null;
        DPFP.Sample DPsample;
        DPFP.FeatureSet DPFeatures;
        DPFP.Template DPTemplate;
        byte[] ISOFMD;
        private const int CP_NOCLOSE_BUTTON = 0x200;
        public frmRegisterStudent()
        {
            InitializeComponent();
        }
       
        private void FrmRegisterStudent_Load(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, int> levels = new Dictionary<string, int>();
                levels.Add("Select...", 0);
                levels.Add("100", 1);
                levels.Add("200", 2);
                levels.Add("300", 3);
                levels.Add("400", 4);

                cboLevel.DataSource = new BindingSource(levels, null);
                cboLevel.DisplayMember = "Key";
                cboLevel.ValueMember = "Value";

                Dictionary<string, int> semesters = new Dictionary<string, int>();
                semesters.Add("Select...", 0);
                semesters.Add("1st", 1);
                semesters.Add("2nd", 2);

                cboSemester.DataSource = new BindingSource(semesters, null);
                cboSemester.DisplayMember = "Key";
                cboSemester.ValueMember = "Value";

                Dictionary<string, int> depts = new Dictionary<string, int>();
                depts.Add("Select...", 0);
                depts.Add("Computer Sci.", 1);
                depts.Add("Accountancy", 2);
                depts.Add("Mass Comm.", 3);
                depts.Add("Business Administration", 4);


                cboDept.DataSource = new BindingSource(depts, null);
                cboDept.DisplayMember = "Key";
                cboDept.ValueMember = "Value";
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
               
                // set culture
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB", false);
                // '===================
                Capturer = new DPFP.Capture.Capture();                   // Create a capture operation.

                try
                {
                    if ((Capturer != null))
                        Capturer.EventHandler = this;                             // Subscribe for capturing events.
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

               // GetAllScanner(cboScanner); btnStartCapture.PerformClick();

          
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
                    lblMsg.Text = "An error has occured while initialising the scanner";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                //MsgBox(ex.Message, MsgBoxStyle.Exclamation, Application.ProductName);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = @"D:\",
                    Title = "Browse Passport",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "jpg",
                    Filter = "jpg files (*.jpg)|*.jpg",
                    FilterIndex = 2,
                    RestoreDirectory = true,

                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = openFileDialog1.FileName;// @"C:\Users\nskalu\Desktop\Ngozi Pics\DSC_5519.jpg";
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {

                lblMsg.Text = "An error has occured";
                lblMsg.ForeColor = System.Drawing.Color.Red; ;
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //validations 

                string surname = txtsurname.Text.Trim();
                string email = txtEmail.Text.Trim();
                string phone = txtPhoneNo.Text.Trim();
                int semester = (int)cboSemester.SelectedValue;
                string firstname = txtfirstname.Text.Trim();
                string middlename = txtmiddlename.Text.Trim();
                string matricno = txtmatricno.Text.Trim().ToUpper();
                int level = (int)cboLevel.SelectedValue;
                int dept = (int)cboDept.SelectedValue;
                Image passport = pictureBox1.Image;
                if (surname == "" || email == "" || phone == "" || semester == 0 || firstname == "" || matricno == "" || level == 0 || dept == 0)
                {
                    lblMsg.Text = "Ensure all fields are filled";
                    return;
                }
               
                if (txtPhoneNo.Text.Length!=11 || !IsDigitsOnly(phone))// || phone[0]!=0)
                {
                    MessageBox.Show("Phone number is not a valid Nigerian Number", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (!ValidateEmail.IsValidEmail(email))
                {
                    MessageBox.Show("Email string is not a valid email address", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DataTable data;
                data = SQLiteHandler.CheckStudentExists(matricno, email, phone).Tables[0];
                if (data.Rows.Count>0)
                {
                    lblMsg.Text = "Matric No. Email or Phone already exists";
                    lblMsg.ForeColor = Color.Red;
                    return;
                }
               
                using (MemoryStream ms = new MemoryStream())
                {
                    // Convert Image to byte[]
                    passport.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] imageBytes = ms.ToArray();

                int i, d;
                i = SQLiteHandler.InsertStudent(surname,email,phone,cboSemester.Text,matricno,firstname,middlename,cboDept.Text,cboLevel.Text, imageBytes);
                  
                    if (ProcessFingerPrint())
                    {
                      d = SQLiteHandler.InsertStudentFinger(matricno, ConvertToByteArray(LeftBmp), ConvertToByteArray(RightBmp));

                    }
                    else
                    {
                        d = 0;
                        //delete inserted record
                        SQLiteHandler.DeleteStudentRecord(matricno);
                    }
                    if (i > 0 && d > 0)
                {
                    lblMsg.Text = "Record created Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Blue;
                        resetControls();
                }
                else
                {
                    lblMsg.Text = "Record could not be created";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }

                }

            }
            catch (Exception ex)
            {

                lblMsg.Text = "An error has occured during save";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private void resetControls()
        {
            txtLog.Text = "";
            txtsurname.Text = "";
            txtPhoneNo.Text = "";
            txtEmail.Text = "";
            txtmatricno.Text = "";
            txtmiddlename.Text = "";
            txtfirstname.Text = "";
            cboDept.SelectedIndex = 0;
            cboSemester.SelectedIndex = 0;
            cboLevel.SelectedIndex = 0;
            PicDerived2.Image = null;
            PicDerived.Image = null;
            pictureBox1.Image = null;
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
        public bool Valid()
        {
            try
            {
               

                if (PicDerived.Image == null || PicDerived2.Image == null)
                {
                    //Interaction.MsgBox("Fingerprints must be captured", MsgBoxStyle.Exclamation);
                    //lblMsg.Text = "";
                    throw new Exception("Fingerprints must be captured");
                    //return false;
                }

                // check if fingerprints are unique
                if (NonUnique(ref LeftBmp, ref RightBmp))
                {
                    //Interaction.MsgBox("Same Fingerprints Are Not Allowed", MsgBoxStyle.Exclamation);
                    //lblMsg.Text = "Same Fingerprints Are Not Allowed";
                    throw new Exception("Same Fingerprints Are Not Allowed");
                   // return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                //MsgBox(ex.Message, MsgBoxStyle.Critical, Application.ProductName);
                throw new Exception(ex.Message);
                //return false;
            }
        }
        public bool NonUnique(ref Bitmap LeftFinger, ref Bitmap RightFinger)
        {
            try
            {
                // convert the leftfinger to sample
                Sample LeftSample = ConvertRawBmpAsSample(LeftFinger);

                // convert the right finger as template
                Template RightTemplate = ConvertRawBmpAsTemplate(RightFinger,  DataPurpose.Verification);

                // Process the sample and create a feature set for the enrollment purpose.
                DPFP.FeatureSet features = ExtractFeatures(LeftSample, DPFP.Processing.DataPurpose.Verification);

                Stopwatch sw = new Stopwatch();
                // Check quality of the sample and start verification if it's good
                if (features != null & RightTemplate != null)
                {
                    // loads the collection

                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();

                    // timer for current comparison 
                    sw.Start();

                    result = DPFP.Verification.Verification.Verify(features, RightTemplate, 0x7FFFFFFF / 100000);

                    if (result.Verified)
                        return true;
                    else
                        return false;
                    sw.Stop();
                }
                else
                    throw new Exception("Fingerprint is of low quality");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public Sample ConvertRawBmpAsSample(Bitmap RawBmp, short VertDpi = 700, short HorDpi = 700)
        {
            VariantConverter VConverter;
            Enroller = new DPFP.Processing.Enrollment();
            RawBmp = EncodeBitmap(RawBmp, VertDpi, HorDpi);
            try
            {
                // converts raw image to dpSample using DFC 2.0---------------------------------------
                // encode the bmp variable using the bitmap Loader
                BitmapLoader BmpLoader = new BitmapLoader(RawBmp, (int)RawBmp.HorizontalResolution, (int)RawBmp.VerticalResolution);
                BmpLoader.ProcessBitmap();
                // return the required result
                inputData = BmpLoader.RawData;
                inpRaw = BmpLoader.DPInputParam;
                // dispose the object
                BmpLoader.Dispose();

                // start the conversion process
                VConverter = new VariantConverter(VariantConverter.OutputType.dp_sample, DataType.RawSample, inpRaw, inputData, false);
                MemoryStream DStream = new MemoryStream(VConverter.Convert());
                DPsample = new DPFP.Sample(DStream);
                return DPsample;
            }
            catch (Exception ex)
            {
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }

        public static Bitmap EncodeBitmap(Bitmap Bmp, Int16 HorResolution = 500, Int16 VertResolution = 500)
        {
            try
            {
                Bitmap OutputBmp;
                if (Bmp != null)
                {
                    OutputBmp = Bmp;
                    OutputBmp.SetResolution(HorResolution, VertResolution);
                    return OutputBmp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return null/* TODO Change to default(_) if this is not a reference type */;
        }

        public DPFP.Template ConvertRawBmpAsTemplate(Bitmap RawBmp,DataPurpose ProcessPurpose = DataPurpose.Enrollment ,short VertDpi = 700, short HorDpi = 700)
        {
            VariantConverter VConverter;
            Enroller = new DPFP.Processing.Enrollment();
            RawBmp = EncodeBitmap(RawBmp, VertDpi, HorDpi);
            try
            {
                // converts raw image to dpSample using DFC 2.0---------------------------------------
                // encode the bmp variable using the bitmap Loader
                BitmapLoader BmpLoader = new BitmapLoader(RawBmp, (int)RawBmp.HorizontalResolution, (int)RawBmp.VerticalResolution);
                BmpLoader.ProcessBitmap();
                // return the required result
                inputData = BmpLoader.RawData;
                inpRaw = BmpLoader.DPInputParam;
                // dispose the object
                BmpLoader.Dispose();

                // start the conversion process
                VConverter = new VariantConverter(VariantConverter.OutputType.dp_sample, DataType.RawSample, inpRaw, inputData, false);
                MemoryStream DStream = new MemoryStream(VConverter.Convert());
                DPsample = new DPFP.Sample(DStream);
                // DPsample = DirectCast(VConverter.Convert(), DPFP.Sample)

                // converts dpSample to DPFeatures using the OTW'''''''''''''''''''''''''''''''''''''''
                DPFeatures = ExtractFeatures(DPsample, ProcessPurpose);
                // convert DPfeatures to ISO FMD using the DFC 2.0'''''''''''''''''''''''''''''''''''''''  
                byte[] SerializedFeatures = null;
                DPFeatures.Serialize(ref SerializedFeatures); // serialized features into the array of bytes
                ISOFMD = DigitalPersona.Standards.Converter.Convert(SerializedFeatures, DigitalPersona.Standards.DataType.DPFeatureSet, DataType.ISOFeatureSet);

                // convert ISO FMD to DPTemplate using DFC 2.0'''''''''''''''''''''''''''''''''''''''
                byte[] DPTemplateData = DigitalPersona.Standards.Converter.Convert(ISOFMD, DigitalPersona.Standards.DataType.ISOTemplate, DataType.DPTemplate);
                // deserialize data to Template
                DPTemplate = new DPFP.Template();
                DPTemplate.DeSerialize(DPTemplateData); // required for database purpose
                                                        // ============================================================================ 
                DStream.Close();
                return DPTemplate;
            }
            catch (Exception ex)
            {
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }

        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            try
            {
                DPFP.Processing.FeatureExtraction extractor = new DPFP.Processing.FeatureExtraction();        // Create a feature extractor
                DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
                DPFP.FeatureSet features = new DPFP.FeatureSet();
                extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features); // TODO: return features as a result?
                if ((feedback == DPFP.Capture.CaptureFeedback.Good))
                    return features;
                else
                    return null/* TODO Change to default(_) if this is not a reference type */;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Extracting Features");
            }
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
        private void Button1_Click(object sender, EventArgs e)
        {
            
                try
                {
                    if (!(Capturer == null))
                    {
                        try
                        {
                            Capturer.StartCapture();
                            SetPrompt("Using the fingerprint reader, scan your fingerprint.");
                            btnStartCapture.Enabled = false;
                            btnStopCapture.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            SetPrompt("Can't initiate capture! Please exit and relaunch the application.");
                        }
                       
                    }
                }
                catch (Exception ex)
                {
                    //MsgBox(ex.Message, MsgBoxStyle.Exclamation, Application.ProductName);
                }
            
        }
      
        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            MakeReport("The " + getFingerType() + " fingerprint was captured.");
            Message = null;

            // use verification method
            Process(Sample);
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
            return rdbLeftThumb.Checked ? "Left" : "Right";
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
                }
            }
        }
        private void _DrawPicture(dynamic bmp)
        {
            if (rdbLeftThumb.Checked)
            {
                PicDerived.Image = new Bitmap(bmp, PicDerived.Size);
                LeftBmp = (System.Drawing.Bitmap)bmp;
            }
            else
            {
                PicDerived2.Image = new Bitmap(bmp, PicDerived2.Size);
                RightBmp = (System.Drawing.Bitmap)bmp;
            }
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
        private void BtnStopCapture_Click_1(object sender, EventArgs e)
        {
            try
            {
                if ((Capturer != null))
                {
                    try
                    {
                        Capturer.StopCapture();
                        SetPrompt("Then fingerprint readerwas stopped");
                        btnStartCapture.Enabled = true;
                        btnStopCapture.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        SetPrompt("Can't initiate capture! Please exit and relaunch the application");
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

      private bool ProcessFingerPrint()
        {
           
            //DataHold.LeftFingerConfirm = LeftBmp;
            //DataHold.RightFingerConfirm = RightBmp;
            //DataHold.LeftFinger = LeftBmp;
            //DataHold.RightFinger = RightBmp;
            try
            {
               if (!(Valid()))
                {

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "FingerPrint Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
                
            }
                    

            return true;
               
        }

        private void Btnclose_Click(object sender, EventArgs e)
        {
            Capturer.StopCapture();
            this.Close();
        }

        private byte[] ConvertToByteArray(Bitmap value)
        {
            byte[] bitmapBytes;
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                value.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                bitmapBytes = stream.ToArray();
            }
            return bitmapBytes;
        }
        //public bool isValidPhoneNumber(string phoneNumber)
        //{
        //    var subs = phoneNumber.Substring(3);
        //    if ((IsMatch(phoneNumber, @"^[0-9][7-9][0-1][0-9]\d{7}$")))
        //    {
        //        if ((phoneNumber.Substring(3).Length > 0))
        //            return true;
        //        else
        //            return false;
        //    }
        //    else
        //        return false;
        //}
    }
}
