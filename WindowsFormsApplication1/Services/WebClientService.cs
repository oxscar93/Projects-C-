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
using WindowsFormsApplication1.Decisions;
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
        private Button _stopButton;
        public WebClientServiceArgs WebClientServiceArgs { get; set; }
        
        public WebClientService(WebClient webClient)
        {
            _webClient = webClient;
        }

        public void DownloadFilesOnSpecificDirectory(string downloadLink, string directoryPath)
        {
            _ChangeStatusForCurrentProgramInDownloadingStatus(Constants.StatusDownloading);

            try
            {
                using (var client = _webClient)
                {
                    client.DownloadProgressChanged += _WebClient_DownloadProgressChanged;
                    client.DownloadFileCompleted += webClient_OnFinish;
                    client.DownloadFileAsync(new Uri(downloadLink),
                        directoryPath);
                }
            }
            catch (Exception e)
            {
                var decisionsArgs = new DecisionsArgsBuilder().Build(e, _stopButton);
                var status= new DecisionsFactory().GetDecisionBasedOnArgs(decisionsArgs)
                    .TriggerDecision(decisionsArgs);
                _ChangeStatusForCurrentProgramInDownloadingStatus(status);
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
            _stopButton.Enabled = false;
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

        public void RegistryStopButton(Button button)
        {
            _stopButton = button;
        }

        public bool HasWebClientBusy()
        {
            return _webClient.IsBusy;
        }
          
        private void _WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            _downloadProgressBar.Value = e.ProgressPercentage;

            _downloadProgressLabel.Text = e.ProgressPercentage != 100
                ? e.ProgressPercentage + Constants.Percent
                : Constants.DownloadFinished;
        }

        private void webClient_OnFinish(object sender, AsyncCompletedEventArgs e)
        {
            var decisionsArgsBuilder = new DecisionsArgsBuilder();

            _webClient.Dispose();
           
            var newStatus = new DecisionsFactory().GetDecisionBasedOnArgs(decisionsArgsBuilder.Build(e))
                .TriggerDecision(decisionsArgsBuilder
                .Build(e,_downloadProgressBar, UtilClass.CreateDirectoryPathWithProgramFile(_currentDirectoryPath,
                _currentProgramInDownloading.DownloadLink),_downloadablePrograms,_downloadProgressLabel));
       
            _ChangeStatusForCurrentProgramInDownloadingStatus(newStatus);

            if (_downloadablePrograms.Count <= 0) return;         
            _DownloadFile();
        }

        private void _DownloadFile()
        {
            _currentProgramInDownloading =  _downloadablePrograms.Dequeue();
            var currentDirectoryPathAndCurrentFile = UtilClass.CreateDirectoryPathWithProgramFile(_currentDirectoryPath,
                _currentProgramInDownloading.DownloadLink);

            DownloadFilesOnSpecificDirectory(_currentProgramInDownloading.DownloadLink, currentDirectoryPathAndCurrentFile);
        }

        private void _ChangeStatusForCurrentProgramInDownloadingStatus(string status)
        {
            _currentProgramInDownloading.ChangeDownloadStatus(status);
            _downloadableProgramsCheckedList.Refresh();
        }
    }
}
