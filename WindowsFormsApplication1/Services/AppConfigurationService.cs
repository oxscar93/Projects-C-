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
    public class AppConfigurationService
    {
        public void SaveConfiguration(IList<DownloadableProgram> programList, string directoryPath)
        {
            var configurationString = UtilClass.ConvertProgramListToStringConfigurationFormat(programList);
      
            using (var outputFile = new StreamWriter(directoryPath))
            {
                    outputFile.WriteLine(configurationString);
            }
        }

        public IList<DownloadableProgram> OpenConfiguration(string directoryPath)
        {
            var configurationString = string.Empty;
            try
            {
                using (var reader = new StreamReader(directoryPath))
                {
                    configurationString = reader.ReadLine();
                }
                return UtilClass.GetProgramsFromConfigurationString(configurationString);
            }
            catch (FileNotFoundException e)
            {
                return null;
            }                     
        }
    }
}
