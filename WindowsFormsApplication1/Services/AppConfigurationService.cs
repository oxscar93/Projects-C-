using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Common_Objects;
using WindowsFormsApplication1.Utils;

namespace WindowsFormsApplication1.Services
{
    public class AppConfigurationService
    {
        public void SaveConfiguration(IList<DownloadableProgram> programList)
        {
            var configurationString = UtilClass.ConvertProgramListToStringConfigurationFormat(programList);
      
            using (var outputFile = new StreamWriter(@"C:\Users\Maria\Desktop\Configuration.txt"))
            {
                    outputFile.WriteLine(configurationString);
            }
        }

        public IList<DownloadableProgram> OpenConfiguration(string directoryPath)
        {
            var configurationString = string.Empty;

            using (var reader = new StreamReader(directoryPath))
            {
                configurationString = reader.ReadLine();
            }

            return UtilClass.GetProgramsFromConfigurationString(configurationString);
        }
    }
}
