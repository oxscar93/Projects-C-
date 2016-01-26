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
        public string ProgramNameUnmodified { get; set; }
        public string DownloadLink { get; set; }
       
      
        public void ChangeDownloadStatus(string status)
        {
            ProgramName = ProgramNameUnmodified;
            ProgramName = ProgramName + Constants.EmptySpace + status;
        }

        
     

        //TODO: method to execute a program
    }
}
