using System;
using System.Diagnostics;
using System.Text;
using System.Reflection;


namespace LogHelper
{
    public class LoggerHelper
    {
        public delegate void ShowMessageEventHandler(string msg);
        public static event ShowMessageEventHandler ShowMessage;
        private const bool SHOW_STACK = true;
        public static LogLevel CurrentLogLevels;
        private static LogWriter m_logWriter;
        public static string DebugFilterStr;
        private static ulong index;
        static LoggerHelper()
        {
            LoggerHelper.CurrentLogLevels = (LogLevel.DEBUG | LogLevel.INFO | LogLevel.WARNING | LogLevel.ERROR | LogLevel.EXCEPT | LogLevel.CRITICAL);
            LoggerHelper.DebugFilterStr = string.Empty;
            LoggerHelper.index = 0uL;
            LoggerHelper.m_logWriter = new LogWriter();

        }
        public static void Release()
        {
            LoggerHelper.m_logWriter.Release();
        }
        private static string GetStacksInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();
            StackTrace stackTrace = new StackTrace();
            StackFrame[] frames = stackTrace.GetFrames();
            for (int i = 2; i < frames.Length; i++)
            {
                stringBuilder.AppendLine(frames[i].ToString());
            }
            return stringBuilder.ToString();
        }
        private static string GetStackInfo()
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame frame = stackTrace.GetFrame(2);
            MethodBase method = frame.GetMethod();
            return string.Format("{0}.{1}():",method.ReflectedType.Name,method.Name);
        }
        private static void Log(string message, LogLevel level, bool isShow = true)
        {
            string msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff") + message;
            LoggerHelper.m_logWriter.WriteLog(msg,level);
            if ((ShowMessage != null) && isShow)
            {
                ShowMessage(msg);
            }
        }
        public static void Debug(object message, bool isShowStack = true, bool isShow = true)
        {
            if (!(LoggerHelper.DebugFilterStr != ""))
            {
                if (LogLevel.DEBUG == (LoggerHelper.CurrentLogLevels & LogLevel.DEBUG))
                {
                    object[] array = new object[5];
                    array[0] = " [DEBUG]: ";
                    array[1] = (isShowStack ? LoggerHelper.GetStackInfo() : "");
                    array[2] = message;
                    array[3] = " Index = ";
                    array[4] = LoggerHelper.index;
                    LoggerHelper.index += 1uL;
                    LoggerHelper.Log(string.Concat(array),LogLevel.DEBUG,isShow);
                    
                }
            }
        }
        public static void Debug(string filter, object message, bool isShowStack = true, bool isShow = true)
        {
            if (!(LoggerHelper.DebugFilterStr != "") || !(LoggerHelper.DebugFilterStr != filter))
            {
                if (LogLevel.DEBUG == (LoggerHelper.CurrentLogLevels & LogLevel.DEBUG))
                {
                    LoggerHelper.Log(" [DEBUG]: " + (isShowStack ? LoggerHelper.GetStackInfo() : "") + message, LogLevel.DEBUG, isShow);
                }
            }
        }
        public static void Info(object message, bool isShowStack = false, bool isShow = true)
        {
            if (LogLevel.INFO == (LoggerHelper.CurrentLogLevels & LogLevel.INFO))
            {
                LoggerHelper.Log(" [INFO]：" + (isShowStack ? LoggerHelper.GetStackInfo() : "") + message, LogLevel.INFO, isShow);
            }
        }
        public static void Warning(object message, bool isShowStack = true, bool isShow = true)
        {
            if (LogLevel.WARNING == (LoggerHelper.CurrentLogLevels & LogLevel.WARNING))
            {
                LoggerHelper.Log(" [WARNING]：" + (isShowStack ? LoggerHelper.GetStackInfo() : "") + message, LogLevel.WARNING, isShow);
            }
        }
        public static void Error(object message, bool isShowStack = true, bool isShow = true)
        {
            if (LogLevel.ERROR == (LoggerHelper.CurrentLogLevels & LogLevel.ERROR))
            {
                LoggerHelper.Log(string.Concat(new object[]
                {
                    " [ERROR]：",
                    message,
                    "\r\n",
                    isShowStack?LoggerHelper.GetStacksInfo():""
                }),LogLevel.ERROR,isShow);
            }
        }
        public static void Critical(object message, bool isShowStack = true, bool isShow = true)
        {
            if (LogLevel.CRITICAL == (LoggerHelper.CurrentLogLevels & LogLevel.CRITICAL))
            {
                LoggerHelper.Log(string.Concat(new object[]
                    {
                        " [CRITICAL]：",
                        message,
                        "\r\n",
                        isShowStack?LoggerHelper.GetStacksInfo():""
                    }),LogLevel.CRITICAL,isShow);
            }
        }
        public static void Except(Exception ex, object message = null, bool isShow = true)
        {
            if (LogLevel.EXCEPT == (LoggerHelper.CurrentLogLevels & LogLevel.EXCEPT))
            {
                Exception ex2 = ex;
                while (ex2.InnerException != null)
                {
                    ex2 = ex2.InnerException;
                }
                LoggerHelper.Log(" [EXCEPT]：" + ((message == null) ? "" : (message + "\r\n")) + ex.Message + ex2.StackTrace, LogLevel.CRITICAL, isShow);
            }
        }
    }
}
