using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Utils
{
    public static class Constants
    {
        public static string DoubleBars = "\\";
        public static string DisplayMemberProgramName = "ProgramName";
        public static string SingleBar = "/";
        public static string Percent = "%";
        public static string DownloadFinished = "Finished";
        public static string DialogWarningMessage = "Please, select files to download";
        public static string EmptySpace = " ";
        public static string StatusDownloading = "(Downloading..)";
        public static string StatusFinished = "(Finished.)";
        public static string StatusError = "(Error.)";
        public static string OpenKeyConfigurationFormat = "{";
        public static string CloseKeyConfigurationFormat = "}";
        public static string SingleBarVertical = "|";
        public static string Comma = ",";
        public static string SingleBarInverted= @"\";
        public static string FileNotFoundWarningMessage =
            "Warning: Configuration file not found. A new configuration file will be created";
        public static string ConfigurationFile = "Configuration.txt";
        public static string DownloadStopStatus = "Stopped";
        public static string DownloadStopStatusForDownloadableProgram = "(Stopped)";
        public static string CancelledDownloadDecisionForWebClient = "CancelledDownloadDecisionForWebClient";
        public static string ExceptionDecisionForWebClient = "ExceptionDecisionForWebClient";
        public static string ErrorMsgInvalidLink = "The download link is incorrect, please, check it.";
        public static string WarningMsgForDownload = "Do you want stop the download?";
        public static string MessageBoxWarningTitle = "Warning";
    }
}
