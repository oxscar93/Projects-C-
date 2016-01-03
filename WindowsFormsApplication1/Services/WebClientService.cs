using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Common_Objects;
using WindowsFormsApplication1.Utils;

namespace WindowsFormsApplication1.Services
{
    public class WebClientService
    {
        private readonly WebClient _webClient;
        private ProgressBar _downloadProgressBar;
        private Label _downloadProgressLabel;
        private Queue<DownloadableProgram>_downloadLinks;
        private string _directoryPath;
        private DownloadableProgram _currentProgramInDownloading;
        private CheckedListBox _downloadableProgramsCheckedList;
        
        public WebClientService(WebClient webClient)
        {
            _webClient = webClient;
            _downloadProgressBar = null;
            _downloadProgressLabel = null;
            _downloadLinks = null;
            _currentProgramInDownloading = null;
            _downloadableProgramsCheckedList = null;
        }

        public void DownloadFilesOnSpecificDirectory(string downloadLink, string directoryPath)
        {
            _ChangeStatusForCurrentProgramInDownloadingStatus(true);

            using (var client = _webClient)
            {
                client.DownloadProgressChanged += _WebClient_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadFileCompleted;
                client.DownloadFileAsync(new Uri(downloadLink),
                    directoryPath);
            }
        }

        public void DownloadFilesOnSpecificDirectory(string directoryPath)
        {
            _downloadLinks = UtilClass.GetProgramsFromCheckedList(_downloadableProgramsCheckedList.CheckedItems);
            _directoryPath = directoryPath;
            _DownloadFile();
        }

        public void RegistryDownloadProgressBar(ProgressBar downloadProgressBar)
        {
            _downloadProgressBar = downloadProgressBar;
        }

        public void RegistryDownloadProgressLabel(Label downloadProgressLabel)
        {
            _downloadProgressLabel = downloadProgressLabel;
        }

        public void RegistryDownloadableProgramsCheckedList(CheckedListBox downloadableProgrmsCheckedList)
        {
            _downloadableProgramsCheckedList = downloadableProgrmsCheckedList;
        }

        private void _WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            _downloadProgressBar.Value = e.ProgressPercentage;

            _downloadProgressLabel.Text = e.ProgressPercentage != 100
                ? e.ProgressPercentage + Constants.Percent
                : Constants.DownloadFinished;
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _currentProgramInDownloading.ChangeStatusOnErrorIsRaised();
                MessageBox.Show(e.Error.Message);
            }

            if (e.Cancelled)
            {
                //TODO: handle cancelled scenario
            }

            _ChangeStatusForCurrentProgramInDownloadingStatus(false);

            if (_downloadLinks.Count <= 0) return;         
            _DownloadFile();
        }

        private void _DownloadFile()
        {
            _currentProgramInDownloading =  _downloadLinks.Dequeue();
            DownloadFilesOnSpecificDirectory(_currentProgramInDownloading.DownloadLink, 
                UtilClass.CreateDirectoryPathWithProgramFile(_directoryPath, _currentProgramInDownloading.DownloadLink));
        }

        private void _ChangeStatusForCurrentProgramInDownloadingStatus(bool condition)
        {
            _currentProgramInDownloading.ChangeDownloadStatus(condition);
            _downloadableProgramsCheckedList.Refresh();
        }
    }
}
