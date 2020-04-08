using Safari.Infranstructure;
using System;
using System.IO;

namespace Safari.Infrastructure
{
    public class EmailSender : INotificationAction
    {
        private const string LogFileNameOnly = @"LogFile";
        private const string LogFileExtension = @".txt";
        private const string LogFileDirectory = @"~/App_Data";
        private static string _logFileName;


        public void ActOnNotification(string message)
        {
            //string docPath = System.Web.Hosting.HostingEnvironment.MapPath(LogFileDirectory);
            _logFileName = MakeLogFileName(false);

            //using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, _logFileName), true))
            //{
            //    outputFile.WriteLine("Error EmailSender. No existe implementación para este servicio.");
            //}
        }

        private static string MakeLogFileName(bool isArchive)
        {
            return !isArchive ? $"{LogFileNameOnly}{LogFileExtension}"
                : $"{LogFileNameOnly}_{DateTime.UtcNow.ToString("ddMMyyyy_hhmmss")}{LogFileExtension}";
        }
    }
}