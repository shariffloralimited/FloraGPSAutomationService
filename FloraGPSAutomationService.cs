using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ServiceProcess;
using System.Text;
using System.IO;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Timers;
using System.Xml;
using System.Security.Cryptography;


namespace FloraSoft
{

    public partial class FloraGPSAutomationService : ServiceBase
    {
        Timer timer1 = new Timer();
        private HUBFile db = new HUBFile();

        //public string StartTime;
        //public string EndTime;
        //public string Friday;
        //public string Saturday;

        //public string OutwardPath;
        //public string OutwardAckPath;
        //public string InwardPath;
        //public string InwardAckPath;
        //public string LogPath;

        public string StartTime;

        public string EndTime;

        public string Friday;

        public string Saturday;

        public string OutwardPath;

        public string OutwardAckPath;

        public string InwardPath;

        public string InwardAckPath;

        public string ReconPath;

        public string ReconStartTime;

        public string ReconEndTime;

        public string LogPath;

        //OLD CODE
        //private void WriteLog(string Msg)
        //{
        //    FileStream fs = new FileStream(ConfigurationManager.AppSettings["LogPath"] + "\\GPS\\" + System.DateTime.Today.ToString("yyyyMMdd") + ".log", FileMode.OpenOrCreate, FileAccess.Write);
        //    StreamWriter sw = new StreamWriter(fs);
        //    sw.BaseStream.Seek(0, SeekOrigin.End);
        //    sw.WriteLine(System.DateTime.Now.ToString() + ": " + Msg);
        //    sw.Close();
        //    sw.Dispose();
        //    fs.Close();
        //    fs.Dispose();
        //}
        //private void BackupFile(string FileName)
        //{
        //    int m = FileName.LastIndexOf("\\");

        //    string DestFileName = FileName.Substring(0, m) + "\\bak\\" + FileName.Substring(m + 1);
        //    if (!File.Exists(DestFileName))
        //    {
        //        File.Move(FileName, DestFileName);
        //    }
        //}
        ////private bool CheckBusinessHour()
        ////{
        ////    DayOfWeek Today = System.DateTime.Today.DayOfWeek;
        ////    int CurHour = System.DateTime.Now.Hour;

        ////    if ((Today == DayOfWeek.Friday) && (Friday.ToUpper() == "TRUE"))
        ////    {
        ////        return false;
        ////    }
        ////    if ((Today == DayOfWeek.Saturday) && (Saturday.ToUpper() == "TRUE"))
        ////    {
        ////        return false;
        ////    }
        ////    try
        ////    {
        ////        if (CurHour < Int32.Parse(StartTime))
        ////        {
        ////            return false;
        ////        }
        ////        if (CurHour > Int32.Parse(EndTime))
        ////        {
        ////            return false;
        ////        }
        ////    }
        ////    catch { }

        ////    return true;
        ////}
        ////---------------------------------
        //protected override void OnStart(string[] args)
        //{
        //    this.LogPath = ConfigurationManager.AppSettings["LogPath"];
        //    WriteLog("Service Started.");

        //    StartTime = ConfigurationManager.AppSettings["StartTime"];
        //    EndTime = ConfigurationManager.AppSettings["EndTime"];
        //    Friday = ConfigurationManager.AppSettings["Friday"];
        //    Saturday = ConfigurationManager.AppSettings["Saturday"];

        //    OutwardPath = ConfigurationManager.AppSettings["OutwardPath"];
        //    OutwardAckPath = ConfigurationManager.AppSettings["OutwardAckPath"];
        //    InwardPath = ConfigurationManager.AppSettings["InwardPath"];
        //    InwardAckPath = ConfigurationManager.AppSettings["InwardAckPath"];


        //    long delay = Int32.Parse(ConfigurationManager.AppSettings["IntervalInSeconds"]) * 1000;
        //    WriteLog("Sleep time: " + ConfigurationManager.AppSettings["IntervalInSeconds"] + " seconds.");
        //    if (delay < 1000)
        //    {
        //        WriteLog("Sleep time too short: Changed to default.");
        //        delay = 1000;
        //    }
        //    timer1.Elapsed += new ElapsedEventHandler(OnElapsedTime);
        //    timer1.Interval = delay;
        //    timer1.Enabled = true;
        //}
        //private void OnElapsedTime(object source, ElapsedEventArgs e)
        //{
        //    WriteLog("Waking up..........");
        //    //if (!CheckBusinessHour())
        //    //{
        //    //    WriteLog("Exiting for non business hour");
        //    //    return;
        //    //}
        //    timer1.Stop();
        //    try
        //    {
        //        LoadFiles();
        //    }
        //    catch(Exception ex)
        //    {
        //        WriteLog("Error: " + ex.Message);
        //    }


        //    timer1.Start();
        //    WriteLog("Going to sleep.....");
        //}
        //protected override void OnStop()
        //{
        //    WriteLog("Service Stopped.");
        //}
        //protected void LoadFiles()
        //{
        //    DirectoryInfo dir = new DirectoryInfo(OutwardPath);

        //    FileInfo[] files = dir.GetFiles();
        //    WriteLog(files.Length.ToString() + " files found. ");

        //    foreach (FileInfo file in files)
        //    {
        //        WriteLog("Loading: " + file.FullName);
        //        LoadSingleFile(file.FullName, file.Name);
        //        WriteLog("Loading completed: " + file.Name);

        //    }

        //    //dir = new DirectoryInfo("InwardAckPath");
        //    //files = dir.GetFiles();

        //    //foreach (FileInfo file in files)
        //    //{
        //    //    LoadSingleFile(file.FullName);
        //    //}

        //}
        //private void LoadSingleFile(string filepath, string filename)
        //{
           
        //    HUBFile db = new HUBFile();

        //    FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
        //    WriteLog("fs completed.");
        //    StreamReader sr = new StreamReader(fs, Encoding.ASCII);
        //    string LineData = sr.ReadLine();
        //    WriteLog("LineData: " + LineData);

        //    if (LineData != null)
        //    {
        //        db.InsertOutwardData(filename, LineData);
        //        WriteLog("LineData inserted.");
        //    }
        //    sr.Close();
        //    sr.Dispose();
        //    fs.Close();
        //    fs.Dispose();
        //    BackupFile(filepath);
        //}
//    }
//}

       /// <summary>
       /// OLD CODE END
       /// </summary>
       /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            this.LogPath = ConfigurationManager.AppSettings["LogPath"];
            this.WriteLog("Service Started.");
            this.StartTime = ConfigurationManager.AppSettings["StartTime"];
            this.EndTime = ConfigurationManager.AppSettings["EndTime"];
            this.Friday = ConfigurationManager.AppSettings["Friday"];
            this.Saturday = ConfigurationManager.AppSettings["Saturday"];
            this.OutwardPath = ConfigurationManager.AppSettings["OutwardPath"];
            this.OutwardAckPath = ConfigurationManager.AppSettings["OutwardAckPath"];
            this.InwardPath = ConfigurationManager.AppSettings["InwardPath"];
            this.InwardAckPath = ConfigurationManager.AppSettings["InwardAckPath"];
            this.ReconPath = ConfigurationManager.AppSettings["ReconPath"];
            this.ReconStartTime = ConfigurationManager.AppSettings["ReconStartTime"];
            this.ReconEndTime = ConfigurationManager.AppSettings["ReconEndTime"];
            long num = (long)(int.Parse(ConfigurationManager.AppSettings["IntervalInSeconds"]) * 1000);
            this.WriteLog("Sleep time: " + ConfigurationManager.AppSettings["IntervalInSeconds"] + " seconds.");
            bool flag = num < 2000;
            if (flag)
            {
                this.WriteLog("Sleep time too short: Changed to default 2 secs.");
                num = 2000;
            }
            this.timer1.Elapsed += new ElapsedEventHandler(this.OnElapsedTime);
            this.timer1.Interval = (double)num;
            this.timer1.Enabled = true;
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            this.WriteLog("Waking up..........");
            bool flag = !this.CheckBusinessHour();
            if (flag)
            {
                this.WriteLog("Exiting for non business hour");
            }
            else
            {
                this.timer1.Stop();
                try
                {
                    this.ReadAndLoadOutwardFile();
                    this.CreateInwardFile();
                    int hour = DateTime.Now.Hour;
                    this.WriteLog("CurrentHour: " + hour);
                    bool flag2 = hour > Convert.ToInt32(this.ReconStartTime) && hour < Convert.ToInt32(this.ReconEndTime);
                    if (flag2)
                    {
                        try
                        {
                            this.CreateOutwardReconFile();
                        }
                        catch (Exception ex)
                        {
                            this.WriteLog("Error Generating Outward EOD: " + ex.Message);
                        }
                        try
                        {
                            this.CreateInwardReconFile();
                        }
                        catch (Exception ex2)
                        {
                            this.WriteLog("Error Generating Inward EOD: " + ex2.Message);
                        }
                    }
                    this.ReadAndLoadInwardAckFile();
                }
                catch (Exception ex3)
                {
                    this.WriteLog("Error: " + ex3.Message);
                }
                this.timer1.Start();
                this.WriteLog("Going to sleep.....");
            }
        }

        protected override void OnStop()
        {
            this.WriteLog("Service Stopped.");
        }

        private void ReadAndLoadOutwardFile()
        {
            string str = DateTime.Today.ToString("yyyy-MM-dd");
            string searchPattern = "BD_RTGSReport_" + str + "*";
            DirectoryInfo directoryInfo = new DirectoryInfo(this.OutwardPath);
            FileInfo[] files = directoryInfo.GetFiles(searchPattern);
            FileInfo[] array = files;
            for (int i = 0; i < array.Length; i++)
            {
                FileInfo fileInfo = array[i];
                string name = fileInfo.Name;
                string fullName = fileInfo.FullName;
                this.WriteLog("Found: " + name);
                bool flag = fileInfo.Length == 0;
                if (flag)
                {
                    this.WriteLog(name + ": Zero Size");
                    this.db.UpdateOuwardACKData(name, "ZRO", "Zero Size file.");
                    this.CreateOutwardACKFile(name);
                    this.BackupFile(fullName);
                }
                else
                {
                    foreach (string current in File.ReadLines(fullName))
                    {
                        bool flag2 = current.Length < 40;
                        if (flag2)
                        {
                            this.WriteLog(name + ": Data too small");
                            this.db.UpdateOuwardACKData(name, "M03", " Data too small (Parsing error).");
                            break;
                        }
                        this.WriteLog("LineData: " + current.Substring(0, 40));
                        string[] array2 = current.Split(new char[]
						{
							'|'
						});
                        bool flag3 = array2.Length < 20;
                        if (flag3)
                        {
                            this.db.UpdateOuwardACKData(name, "M03", " Less Number of columns in CSV (Parsing error).");
                            this.WriteLog(name + ": Less Number of columns in CSV.");
                            break;
                        }
                        try
                        {
                            this.db.InsertOutwardFileData(name, array2[0], array2[1], array2[2], array2[3], array2[4], array2[5], array2[6], array2[7], array2[8], array2[9], array2[10], array2[11], array2[12], array2[13], array2[14], array2[15], array2[16], array2[17], array2[18], array2[19]);
                            this.WriteLog("Inserted: " + name);
                        }
                        catch (Exception ex)
                        {
                            this.WriteLog("Error InsertOutwardFileData (" + name + "): " + ex.Message);
                        }
                    }
                    try
                    {
                        this.db.ValidataAndMove(name);
                    }
                    catch (Exception ex2)
                    {
                        this.WriteLog("Error Validate and Move: " + ex2.Message);
                    }
                    this.BackupFile(fullName);
                    this.CreateOutwardACKFile(name);
                }
            }
        }

        private void ReadAndLoadInwardAckFile()
        {
            string searchPattern = "BD_IN_RTGS_*";
            DirectoryInfo directoryInfo = new DirectoryInfo(this.InwardAckPath);
            FileInfo[] files = directoryInfo.GetFiles(searchPattern);
            FileInfo[] array = files;
            for (int i = 0; i < array.Length; i++)
            {
                FileInfo fileInfo = array[i];
                string name = fileInfo.Name;
                string fullName = fileInfo.FullName;
                this.WriteLog("Found: " + name);
                string text = File.ReadAllText(fullName);
                this.WriteLog("Inward ACK line DATA" + text);
                this.db.InsertInwardACKFileData(name, text);
                this.BackupFile(fullName);
                this.WriteLog("Backup completed: " + name);
            }
        }

        private void CreateInwardFile()
        {
            HUBFile hUBFile = new HUBFile();
            SqlDataReader singleInwardData = hUBFile.GetSingleInwardData();
            while (singleInwardData.Read())
            {
                string text = (string)singleInwardData["FileName"];
                string text2 = this.InwardPath + "\\" + text;
                string text3 = (string)singleInwardData["LineData"];
                text3 = text3.Replace("~", " ");
                bool flag = !File.Exists(text2);
                if (flag)
                {
                    this.CreateTxtFile(text3, text2);
                    this.UpdateInwardStatus(text2, text);
                }
            }
            singleInwardData.Close();
            singleInwardData.Dispose();
        }

        private void CreateOutwardReconFile()
        {
            string text = "";
            HUBFile hUBFile = new HUBFile();
            SqlDataReader outwardReconData = hUBFile.GetOutwardReconData();
            while (outwardReconData.Read())
            {
                text = (string)outwardReconData["FileName"];
                string fileFullName = this.ReconPath + "\\" + text;
                string text2 = (string)outwardReconData["LineData"];
                text2 = text2.Replace("~", " ");
                this.CreateTxtFile(text2, fileFullName);
                this.WriteLog("CreateOutwardReconFile" + text);
            }
            outwardReconData.Close();
            outwardReconData.Dispose();
            hUBFile.UpdateStatusReconFileData(text);
        }

        private void CreateInwardReconFile()
        {
            string text = "";
            HUBFile hUBFile = new HUBFile();
            SqlDataReader inwardReconData = hUBFile.GetInwardReconData();
            while (inwardReconData.Read())
            {
                text = (string)inwardReconData["FileName"];
                string fileFullName = this.ReconPath + "\\" + text;
                string text2 = (string)inwardReconData["LineData"];
                text2 = text2.Replace("~", " ");
                this.CreateTxtFile(text2, fileFullName);
                this.WriteLog("CreateInwardReconFile" + text);
            }
            inwardReconData.Close();
            inwardReconData.Dispose();
            hUBFile.UpdateStatusReconFileData(text);
        }

        private void CreateOutwardACKFile(string fileshortname)
        {
            ACKValues aCKValues = new ACKValues();
            aCKValues = this.db.GPSGetOutwardACKValues(fileshortname);
            string text = this.OutwardAckPath + "\\" + aCKValues.ACKFileName;
            try
            {
                this.CreateTxtFile(aCKValues.ACKData, text);
                this.WriteLog(text + ": Created Successfully");
                this.db.UpdateStatusOuwardACKData(fileshortname, aCKValues.ACKFileName);
                this.WriteLog("Update Status OuwardACKData" + fileshortname);
            }
            catch (Exception ex)
            {
                this.WriteLog("Error creating ack file: " + fileshortname + ": " + ex.Message);
            }
        }

        private void UpdateInwardStatus(string FileFullName, string FileShortName)
        {
            bool flag = File.Exists(FileFullName);
            if (flag)
            {
                try
                {
                    this.db.UpdateStatusInwardFileData(FileShortName);
                }
                catch (Exception ex)
                {
                    this.WriteLog("Error UpdateStatusInwardFileData : " + ex.Message);
                }
                this.WriteLog("Status updated: " + FileShortName);
            }
        }

        private void CreateTxtFile(string LineData, string FileFullName)
        {
            FileStream fileStream = new FileStream(FileFullName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
            streamWriter.WriteLine(LineData);
            streamWriter.Close();
            streamWriter.Dispose();
            fileStream.Close();
            fileStream.Dispose();
        }

        private void BackupFile(string FileName)
        {
            int num = FileName.LastIndexOf("\\");
            string text = FileName.Substring(0, num) + "\\bak";
            bool flag = !Directory.Exists(text);
            if (flag)
            {
                Directory.CreateDirectory(text);
            }
            string text2 = text + "\\" + FileName.Substring(num + 1);
            bool flag2 = File.Exists(text2);
            if (flag2)
            {
                File.Delete(text2);
            }
            try
            {
                File.Move(FileName, text2);
            }
            catch (Exception ex)
            {
                this.WriteLog("Error during Backup " + FileName + "  - " + ex.Message);
            }
        }

        private void WriteLog(string Msg)
        {
            FileStream fileStream = new FileStream(this.LogPath + "\\GPS" + DateTime.Today.ToString("yyyyMMdd") + ".log", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
            streamWriter.WriteLine(DateTime.Now.ToString() + ": " + Msg);
            streamWriter.Close();
            streamWriter.Dispose();
            fileStream.Close();
            fileStream.Dispose();
        }

        private bool CheckBusinessHour()
        {
            DayOfWeek dayOfWeek = DateTime.Today.DayOfWeek;
            int hour = DateTime.Now.Hour;
            bool flag = dayOfWeek == DayOfWeek.Friday && this.Friday.ToUpper() == "TRUE";
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                bool flag2 = dayOfWeek == DayOfWeek.Saturday && this.Saturday.ToUpper() == "TRUE";
                if (flag2)
                {
                    result = false;
                }
                else
                {
                    try
                    {
                        bool flag3 = hour < int.Parse(this.StartTime);
                        if (flag3)
                        {
                            result = false;
                            return result;
                        }
                        bool flag4 = hour > int.Parse(this.EndTime);
                        if (flag4)
                        {
                            result = false;
                            return result;
                        }
                    }
                    catch
                    {
                    }
                    result = true;
                }
            }
            return result;
        }

    }
}