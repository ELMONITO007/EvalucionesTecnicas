using Safari.Infranstructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Safari.Infranstructure
{
    public class EventLogWritter : INotificationAction
    {
        private const string LogFileNameOnly = @"LogFile";
        private const string LogFileExtension = @".txt";
        private const string LogFileDirectory = @"~/App_Data";
        private static string _logFileName;
        public void ActOnNotification(string message)
        {
            string docPath = "";// System.Web.Hosting.HostingEnvironment
            //      .MapPath(LogFileDirectory);
            _logFileName = MakeLogFileName(false);
            using (StreamWriter ouputFile = new
                StreamWriter (Path.Combine(docPath,_logFileName),true))
            {
                ouputFile.WriteLine(message);
            }
        }

        private string MakeLogFileName(bool isArchive)
        {
            return !isArchive ? $"{LogFileNameOnly}{LogFileExtension}"
                : $"{LogFileNameOnly}_{DateTime.UtcNow.ToString("ddMMyyyy_hhmmss")}{LogFileExtension}";
        }
    }
}