using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Utils;

namespace WindowsFormsApplication1.Common_Objects
{
    public class DownloadableProgram
    {
        public string ProgramName { get; set; }
        public string DownloadLink { get; set; }
        public bool IsDownloading { get; set; }
      
        public void ChangeDownloadStatus(bool inProgress)
        {
            if (inProgress)
            {
                ProgramName = ProgramName + Constants.EmptySpace + Constants.StatusDownloading;
                IsDownloading = true;
            }
            else
            {
                ProgramName = ProgramName.Replace(Constants.StatusDownloading, Constants.StatusFinished);
                IsDownloading = false;
            }
        }

        public void ChangeStatusOnErrorIsRaised()
        {
            ProgramName = ProgramName.Replace(IsDownloading ? 
                Constants.StatusDownloading : Constants.StatusFinished, Constants.StatusError);
        }

        //TODO: method to execute a program
    }
}
