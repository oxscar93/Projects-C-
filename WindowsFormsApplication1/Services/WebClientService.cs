using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
        private Queue<DownloadableProgram>_downloadablePrograms;
        private string _currentDirectoryPath;
        private DownloadableProgram _currentProgramInDownloading;
        private CheckedListBox _downloadableProgramsCheckedList;
        
        public WebClientService(WebClient webClient)
        {
            _webClient = webClient;
            _downloadProgressBar = null;
            _downloadProgressLabel = null;
            _downloadablePrograms = null;
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
            _downloadablePrograms = UtilClass.GetProgramsQueueFromCheckedListControl(_downloadableProgramsCheckedList.CheckedItems);
            _currentDirectoryPath = directoryPath;
            _DownloadFile();
        }

        public void StopDownload()
        {
            _webClient.CancelAsync();
            _downloadProgressBar.Value = 0;
            _downloadProgressLabel.Text = Constants.DownloadStopStatus;
            _downloadProgressBar.Refresh();
            _currentProgramInDownloading.ChangeStatusForStoppedDownload();
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
                _downloadablePrograms.Clear();
            }

            if (e.Cancelled)
            {
                _webClient.Dispose();
                File.Delete(_currentDirectoryPath);
                _downloadablePrograms.Clear();
            }

            _ChangeStatusForCurrentProgramInDownloadingStatus(false);

            if (_downloadablePrograms.Count <= 0) return;         
            _DownloadFile();
        }

        private void _DownloadFile()
        {
            _currentProgramInDownloading =  _downloadablePrograms.Dequeue();
            _currentDirectoryPath = UtilClass.CreateDirectoryPathWithProgramFile(_currentDirectoryPath,
                _currentProgramInDownloading.DownloadLink);

            DownloadFilesOnSpecificDirectory(_currentProgramInDownloading.DownloadLink, _currentDirectoryPath);
        }

        private void _ChangeStatusForCurrentProgramInDownloadingStatus(bool condition)
        {
            _currentProgramInDownloading.ChangeDownloadStatus(condition);
            _downloadableProgramsCheckedList.Refresh();
        }
    }
}
