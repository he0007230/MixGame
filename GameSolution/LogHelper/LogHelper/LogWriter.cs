using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using MyConstants;

namespace LogHelper
{
    class LogWriter
    {
        private string m_logPath = SystemConfig.ResourceFolder+"/Log/";
        private string m_logFileName = "{0}Log.txt";
        private string m_logFilePath;
        private string m_nowDate;
        private FileStream m_fs;
        private StreamWriter m_sw;
        private Action<string, LogLevel> m_logWriter;
        private static readonly object m_locker = new object();
        public LogWriter()
        {
            if (!Directory.Exists(this.m_logPath))
            {
                Directory.CreateDirectory(this.m_logPath);
            }
            this.m_logFilePath = this.m_logPath + string.Format(this.m_logFileName,DateTime.Today.ToString("yyyyMMdd"));
            this.m_nowDate = DateTime.Today.ToString("yyyyMMdd");
            try
            {
                this.m_logWriter = new Action<string, LogLevel>(this.Write);
                this.m_fs = new FileStream(this.m_logFilePath,FileMode.Append,FileAccess.Write,FileShare.ReadWrite);
                this.m_sw = new StreamWriter(this.m_fs);
            }
            catch
            {
            }
        }

        public void Release()
        {
            object locker;
            Monitor.Enter(locker = LogWriter.m_locker);
            try
            {
                if (this.m_sw != null)
                {
                    this.m_sw.Close();
                    this.m_sw.Dispose();
                }
                if (this.m_fs != null)
                {
                    this.m_fs.Close();
                    this.m_fs.Dispose();
                }
            }
            finally
            {
                Monitor.Exit(locker);
            }
        }
        public void WriteLog(string msg, LogLevel level)
        {
            if (m_nowDate != DateTime.Today.ToString("yyyyMMdd"))
            {
                Release();
                if (!Directory.Exists(this.m_logPath))
                {
                    Directory.CreateDirectory(this.m_logPath);
                }
                this.m_logFilePath = this.m_logPath + string.Format("{0}Log.txt", DateTime.Today.ToString("yyyyMMdd"));
                this.m_nowDate = DateTime.Today.ToString("yyyyMMdd");
                try
                {
                    this.m_fs = new FileStream(this.m_logFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                    this.m_sw = new StreamWriter(this.m_fs);
                }
                catch
                {
                }
            }
            this.m_logWriter.BeginInvoke(msg, level, null, null);
        }
        private void Write(string msg, LogLevel level)
        {
            object locker;
            Monitor.Enter(locker = LogWriter.m_locker);
            try
            {
                if (this.m_sw != null)
                {
                    this.m_sw.WriteLine(msg);
                    this.m_sw.Flush();
                }
            }
            catch
            {
            }
            finally
            {
                Monitor.Exit(locker);
            }
        }
    }
}
