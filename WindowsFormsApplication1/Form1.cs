using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WindowsFormsApplication1.Common_Objects;
using WindowsFormsApplication1.Services;
using WindowsFormsApplication1.Utils;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private readonly WebClientService _webClientService;
        private readonly AppConfigurationService _appConfigurationService;
        private readonly string _appCurrentDirectory;

        public Form1(WebClientService webClientService, AppConfigurationService appConfigurationService)
        {
            InitializeComponent();
            _webClientService = webClientService;
            _appConfigurationService = appConfigurationService;
            _appCurrentDirectory = Application.StartupPath;
            _webClientService.RegistryDownloadProgressBar(downloadProgressBar);
            _webClientService.RegistryDownloadProgressLabel(progressLbl);
            _webClientService.RegistryDownloadableProgramsCheckedList(programDownloadList);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            programDownloadList.DisplayMember = Constants.DisplayMemberProgramName;
            _AddItemsToCheckedListFromConfigurationFile(UtilClass.FormatDirectoryPathAndAddFileToPath(_appCurrentDirectory, Constants.ConfigurationFile));         
        }

        private void exitAppBtn_Click(object sender, EventArgs e)
        {
            _appConfigurationService.SaveConfiguration(programDownloadList.Items.Cast<DownloadableProgram>().ToList(), 
                UtilClass.FormatDirectoryPathAndAddFileToPath(_appCurrentDirectory, Constants.ConfigurationFile));
            Application.Exit();
        }

        private void addProgramBtn_Click(object sender, EventArgs e)
        {
            _ShowOrHideRequiredCharIfNeeded(programNameTxt, programNameRequiredChar);
            _ShowOrHideRequiredCharIfNeeded(downloadLinkTxt, downloadLinkRequiredChar);

            if (programNameTxt.Text == string.Empty || downloadLinkTxt.Text == string.Empty) return;
            programDownloadList.Items.Add(new DownloadableProgram
            {
                ProgramName = programNameTxt.Text,
                ProgramNameUnmodified = programNameTxt.Text,
                DownloadLink = downloadLinkTxt.Text
            });

            _ClearCreateProgramFields();
        }

        private void downloadProgramsBtn_Click(object sender, EventArgs e)
        {
            var dialogResult = _ShowFolderDialogForItemsToDownload();

            if ( dialogResult == null)
            {
                return;
            }
            stopDownloadingBtn.Enabled = true;
            _webClientService.DownloadFilesOnSpecificDirectory(dialogResult);
        }

        private void modifyLinkBtn_Click(object sender, EventArgs e)
        {
            if (programDownloadList.SelectedItem == null) return;
            var programSelected = (DownloadableProgram)programDownloadList.SelectedItem;

            programSelected.ProgramName = programNameTxt.Text;
            programSelected.DownloadLink = downloadLinkTxt.Text;

            programDownloadList.Refresh();
        }

        private void removeProgramBtn_Click(object sender, EventArgs e)
        {
            if (programDownloadList.CheckedItems.Count == 0) return;
            _ClearCreateProgramFields();
            _RemoveCheckedItemsFromList(programDownloadList);
        }
        
        private void programDownloadList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (programDownloadList.SelectedItem == null) return;
            var programSelected = (DownloadableProgram)programDownloadList.SelectedItem;

            programNameTxt.Text = programSelected.ProgramName;
            downloadLinkTxt.Text = programSelected.DownloadLink;
        }

        private void saveConfigurationBtn_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog {OverwritePrompt = true};

            var directoryPathAndFile = _ShowFolderDialogOrFileDialogAndGetPath(saveDialog);
           
            if (directoryPathAndFile != null)
            {
                var fileToSaveData =
                   UtilClass.ParseFileFromDownloadLink(directoryPathAndFile.Replace(Constants.DoubleBars,
                   Constants.SingleBar));

                _appConfigurationService.SaveConfiguration(programDownloadList.Items.Cast<DownloadableProgram>().ToList(),
                   UtilClass.FormatDirectoryPathAndAddFileToPath(directoryPathAndFile.Replace(Constants.DoubleBars + fileToSaveData, string.Empty), 
                   fileToSaveData));
            }     
        }

        private void openConfigurationBtn_Click(object sender, EventArgs e)
        {
            var directoryPath = _ShowFolderDialogOrFileDialogAndGetPath(new OpenFileDialog());

            if (directoryPath != null)
            {
                _AddItemsToCheckedListFromConfigurationFile(directoryPath);
            }
        }

        private void _ClearCreateProgramFields()
        {
            programNameTxt.Text = string.Empty;
            downloadLinkTxt.Text = string.Empty;
        }

        private void _ShowOrHideRequiredCharIfNeeded(TextBox txtControl, Label lblControl)
        {
            lblControl.Visible = txtControl.Text == string.Empty;
        }

        private string _ShowFolderDialogForItemsToDownload()
        {
            if (programDownloadList.CheckedItems.Count == 0)
            {
                MessageBox.Show(Constants.DialogWarningMessage);
                return null; 
            }

            return _ShowFolderDialogOrFileDialogAndGetPath(new FolderBrowserDialog());
        }

        private string _ShowFolderDialogOrFileDialogAndGetPath(CommonDialog dialog)
        {       
            switch (dialog.ShowDialog())
            {
                case DialogResult.OK:
                    return dialog is FolderBrowserDialog
                        ? ((FolderBrowserDialog) dialog).SelectedPath
                        : ((FileDialog) dialog).FileName;
                case DialogResult.Cancel:
                    return null;
            }

            return null;
        }

        private void _RemoveCheckedItemsFromList(CheckedListBox checkedListBox)
        {
            while (checkedListBox.CheckedItems.Count > 0)
            {
                checkedListBox.Items.Remove(checkedListBox.CheckedItems[0]);
            }
        }

        private void _AddItemsToCheckedListFromConfigurationFile(string directoryPath)
        {
            programDownloadList.Items.Clear();
            var programsList=_appConfigurationService.OpenConfiguration(directoryPath);

            if (programsList == null)
            {
                MessageBox.Show(Constants.FileNotFoundWarningMessage);
                return;
            }
           
            foreach (var program in programsList)
            {
                programDownloadList.Items.Add(program);
            }

            programDownloadList.Refresh();
        }

        private void stopDownloadingBtn_Click(object sender, EventArgs e)
        {
            _webClientService.StopDownload();
            stopDownloadingBtn.Enabled = false;
        }
    }
}
