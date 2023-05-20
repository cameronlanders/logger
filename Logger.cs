using System;
using System.IO;

namespace Util
{
    static class Logger
    {
        // -----------------------------------------------------
        // Logger - A simple logging  class in C#.
        // -----------------------------------------------------
        // Developed by Cameron Landers
        // -----------------------------------------------------
        static string _logfilepath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\your_app_name_here\\";
        public static void AppendLog(string entry)
        {
            try
            {
                // ---------------------------------------------
                // Create the log path if necessary.
                // ---------------------------------------------
                if (!Directory.Exists(_logfilepath)) Directory.CreateDirectory(_logfilepath);
                // ---------------------------------------------
                // Create a new log file every day.
                // ---------------------------------------------
                string CurrentLog = _logfilepath + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".log";
                FileInfo logFile = new FileInfo(CurrentLog);
                // ---------------------------------------------
                // Build the log entry, preappending a 
                // datetime stamp. 
                // ---------------------------------------------
                // Add an extra space to single digit hours for 
                // consistent visual alignment.
                // ---------------------------------------------
                string logEntry = (DateTime.Now.Hour < 10) ? DateTime.Now.ToString() + ":  " + entry : DateTime.Now.ToString() + ": " + entry;
                // ---------------------------------------------
                // Append the entry to the end of the log.
                // ---------------------------------------------
                File.AppendAllText(logFile.FullName, logEntry + Environment.NewLine);
            }
            catch
            {
                // ---------------------------------------------
                // Add exception handler here if desired.
                // ---------------------------------------------
            }
        }
    }
}
