using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Common_Objects;
using WindowsFormsApplication1.Services;
using WindowsFormsApplication1.Utils;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private readonly WebClientService _webClientService;
        private readonly AppConfigurationService _appConfigurationService;

        public Form1(WebClientService webClientService, AppConfigurationService appConfigurationService)
        {
            InitializeComponent();
            _webClientService = webClientService;
            _appConfigurationService = appConfigurationService;
            _webClientService.RegistryDownloadProgressBar(downloadProgressBar);
            _webClientService.RegistryDownloadProgressLabel(progressLbl);
            _webClientService.RegistryDownloadableProgramsCheckedList(programDownloadList);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            programDownloadList.DisplayMember = Constants.DisplayMemberProgramName;
            _AddItemsToCheckedListFromConfigurationFile(@"C:\Users\Maria\Desktop\Configuration.txt");
        }

        private void exitAppBtn_Click(object sender, EventArgs e)
        {
            _SaveConfigurationOnExit();
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
                DownloadLink = downloadLinkTxt.Text
            });

            _ClearCreateProgramFields();
        }

        private void downloadProgramsBtn_Click(object sender, EventArgs e)
        {
            var dialogResult = _ShowFolderDialogAndGetPath();

            if ( dialogResult == null)
            {
                return;
            }

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
            //TODO : implement save configuration on specific directory
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

        private string _ShowFolderDialogAndGetPath()
        {
            if (programDownloadList.CheckedItems.Count == 0)
            {
                MessageBox.Show(Constants.DialogWarningMessage);
                return null;
            }

            var folderDialog = new FolderBrowserDialog();
            var result = folderDialog.ShowDialog();

            switch (result)
            {
                case DialogResult.OK:
                    return folderDialog.SelectedPath;
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

        private void _SaveConfigurationOnExit()
        {          
           _appConfigurationService.SaveConfiguration(programDownloadList.Items.Cast<DownloadableProgram>().ToList());          
        }

        private void _AddItemsToCheckedListFromConfigurationFile(string directoryPath)
        {
            var programsList=_appConfigurationService.OpenConfiguration(directoryPath);

            foreach (var program in programsList)
            {
                programDownloadList.Items.Add(program);
            }

            programDownloadList.Refresh();
        }
    }
}
