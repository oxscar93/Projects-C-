using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Common_Objects;

namespace WindowsFormsApplication1.Utils
{
    public static class UtilClass
    {
        public static string ParseFileFromDownloadLink(string downloadLink)
        {
            var programFile = downloadLink.Reverse();
            var parsedProgramFile = string.Empty;

            foreach (var character in programFile)
            {
                if (character.ToString() != Constants.SingleBar)
                {
                    parsedProgramFile = parsedProgramFile + character;
                }
                else
                {
                    return parsedProgramFile.Reverse()
                        .Aggregate(string.Empty, (current, ch) => current + ch); ;
                }
            }

            return parsedProgramFile;
        }

        public static string CreateDirectoryPathWithProgramFile(string directoryPathWithoutFile, string downloadLink)
        {
            return directoryPathWithoutFile + Constants.DoubleBars + ParseFileFromDownloadLink(downloadLink);
        }

        public static Queue<DownloadableProgram> GetProgramsQueueFromCheckedListControl(CheckedListBox.CheckedItemCollection items)
        {
            var downloadLinks = new Queue<DownloadableProgram>();

            foreach (var downloadableProgram in items.Cast<DownloadableProgram>())
            {
                downloadLinks.Enqueue(downloadableProgram);
            }

            return downloadLinks;
        }
  
        public static string ConvertProgramListToStringConfigurationFormat(IList<DownloadableProgram> programList)
        {
            return programList
                .Aggregate(string.Empty, (current, downloadableProgram)
                            => current + Constants.OpenKeyConfigurationFormat + downloadableProgram.ProgramName
                                       + Constants.Comma + downloadableProgram.DownloadLink + Constants.CloseKeyConfigurationFormat + Constants.SingleBarVertical);
        }
    }
}

