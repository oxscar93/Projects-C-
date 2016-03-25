using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Common_Objects;
using WindowsFormsApplication1.Utils;

namespace WindowsFormsApplication1.Services
{
    public class AppFileService
    {
        public void SaveFile(IList<DownloadableProgram> programList, string directoryPath)
        {
            var fileString = UtilClass.ConvertProgramListToStringConfigurationFormat(programList);
      
            using (var outputFile = new StreamWriter(directoryPath))
            {
                    outputFile.WriteLine(fileString);
            }
        }

        public string OpenFile(string directoryPath)
        {
            var fileString = string.Empty;
            try
            {
                using (var reader = new StreamReader(directoryPath))
                {
                    fileString = reader.ReadLine();
                }
                return fileString;
            }
            catch (FileNotFoundException e)
            {
                return null;
            }                     
        }
    }
}
