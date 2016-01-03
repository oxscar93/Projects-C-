namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.exitAppBtn = new System.Windows.Forms.Button();
            this.downloadProgramsBtn = new System.Windows.Forms.Button();
            this.downloadSpecificBtn = new System.Windows.Forms.Button();
            this.programDownloadList = new System.Windows.Forms.CheckedListBox();
            this.addProgramBtn = new System.Windows.Forms.Button();
            this.removeProgramBtn = new System.Windows.Forms.Button();
            this.modifyLinkBtn = new System.Windows.Forms.Button();
            this.programNameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.downloadLinkTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.programNameRequiredChar = new System.Windows.Forms.Label();
            this.downloadLinkRequiredChar = new System.Windows.Forms.Label();
            this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.progressLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exitAppBtn
            // 
            this.exitAppBtn.Location = new System.Drawing.Point(401, 293);
            this.exitAppBtn.Name = "exitAppBtn";
            this.exitAppBtn.Size = new System.Drawing.Size(75, 23);
            this.exitAppBtn.TabIndex = 0;
            this.exitAppBtn.Text = "Exit";
            this.exitAppBtn.UseVisualStyleBackColor = true;
            this.exitAppBtn.Click += new System.EventHandler(this.exitAppBtn_Click);
            // 
            // downloadProgramsBtn
            // 
            this.downloadProgramsBtn.Location = new System.Drawing.Point(12, 293);
            this.downloadProgramsBtn.Name = "downloadProgramsBtn";
            this.downloadProgramsBtn.Size = new System.Drawing.Size(113, 23);
            this.downloadProgramsBtn.TabIndex = 1;
            this.downloadProgramsBtn.Text = "Download programs";
            this.downloadProgramsBtn.UseVisualStyleBackColor = true;
            this.downloadProgramsBtn.Click += new System.EventHandler(this.downloadProgramsBtn_Click);
            // 
            // downloadSpecificBtn
            // 
            this.downloadSpecificBtn.Location = new System.Drawing.Point(142, 293);
            this.downloadSpecificBtn.Name = "downloadSpecificBtn";
            this.downloadSpecificBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.downloadSpecificBtn.Size = new System.Drawing.Size(152, 23);
            this.downloadSpecificBtn.TabIndex = 2;
            this.downloadSpecificBtn.Text = "Download specific program";
            this.downloadSpecificBtn.UseVisualStyleBackColor = true;
            // 
            // programDownloadList
            // 
            this.programDownloadList.FormattingEnabled = true;
            this.programDownloadList.Location = new System.Drawing.Point(12, 93);
            this.programDownloadList.Name = "programDownloadList";
            this.programDownloadList.Size = new System.Drawing.Size(384, 184);
            this.programDownloadList.TabIndex = 3;
            this.programDownloadList.SelectedIndexChanged += new System.EventHandler(this.programDownloadList_SelectedIndexChanged);
            // 
            // addProgramBtn
            // 
            this.addProgramBtn.Location = new System.Drawing.Point(402, 93);
            this.addProgramBtn.Name = "addProgramBtn";
            this.addProgramBtn.Size = new System.Drawing.Size(75, 42);
            this.addProgramBtn.TabIndex = 4;
            this.addProgramBtn.Text = "Add new program";
            this.addProgramBtn.UseVisualStyleBackColor = true;
            this.addProgramBtn.Click += new System.EventHandler(this.addProgramBtn_Click);
            // 
            // removeProgramBtn
            // 
            this.removeProgramBtn.Location = new System.Drawing.Point(402, 141);
            this.removeProgramBtn.Name = "removeProgramBtn";
            this.removeProgramBtn.Size = new System.Drawing.Size(75, 41);
            this.removeProgramBtn.TabIndex = 5;
            this.removeProgramBtn.Text = "Remove program(s)";
            this.removeProgramBtn.UseVisualStyleBackColor = true;
            this.removeProgramBtn.Click += new System.EventHandler(this.removeProgramBtn_Click);
            // 
            // modifyLinkBtn
            // 
            this.modifyLinkBtn.Location = new System.Drawing.Point(402, 189);
            this.modifyLinkBtn.Name = "modifyLinkBtn";
            this.modifyLinkBtn.Size = new System.Drawing.Size(75, 65);
            this.modifyLinkBtn.TabIndex = 6;
            this.modifyLinkBtn.Text = "Modify download link / name";
            this.modifyLinkBtn.UseVisualStyleBackColor = true;
            this.modifyLinkBtn.Click += new System.EventHandler(this.modifyLinkBtn_Click);
            // 
            // programNameTxt
            // 
            this.programNameTxt.Location = new System.Drawing.Point(123, 18);
            this.programNameTxt.Name = "programNameTxt";
            this.programNameTxt.Size = new System.Drawing.Size(150, 20);
            this.programNameTxt.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Program Name:";
            // 
            // downloadLinkTxt
            // 
            this.downloadLinkTxt.Location = new System.Drawing.Point(123, 45);
            this.downloadLinkTxt.Name = "downloadLinkTxt";
            this.downloadLinkTxt.Size = new System.Drawing.Size(273, 20);
            this.downloadLinkTxt.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Download Link:";
            // 
            // programNameRequiredChar
            // 
            this.programNameRequiredChar.AutoSize = true;
            this.programNameRequiredChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programNameRequiredChar.ForeColor = System.Drawing.Color.Red;
            this.programNameRequiredChar.Location = new System.Drawing.Point(280, 16);
            this.programNameRequiredChar.Name = "programNameRequiredChar";
            this.programNameRequiredChar.Size = new System.Drawing.Size(15, 20);
            this.programNameRequiredChar.TabIndex = 11;
            this.programNameRequiredChar.Text = "*";
            this.programNameRequiredChar.Visible = false;
            // 
            // downloadLinkRequiredChar
            // 
            this.downloadLinkRequiredChar.AutoSize = true;
            this.downloadLinkRequiredChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadLinkRequiredChar.ForeColor = System.Drawing.Color.Red;
            this.downloadLinkRequiredChar.Location = new System.Drawing.Point(402, 45);
            this.downloadLinkRequiredChar.Name = "downloadLinkRequiredChar";
            this.downloadLinkRequiredChar.Size = new System.Drawing.Size(15, 20);
            this.downloadLinkRequiredChar.TabIndex = 12;
            this.downloadLinkRequiredChar.Text = "*";
            this.downloadLinkRequiredChar.Visible = false;
            // 
            // downloadProgressBar
            // 
            this.downloadProgressBar.Location = new System.Drawing.Point(16, 342);
            this.downloadProgressBar.Name = "downloadProgressBar";
            this.downloadProgressBar.Size = new System.Drawing.Size(351, 23);
            this.downloadProgressBar.TabIndex = 13;
            // 
            // progressLbl
            // 
            this.progressLbl.AutoSize = true;
            this.progressLbl.Location = new System.Drawing.Point(373, 342);
            this.progressLbl.Name = "progressLbl";
            this.progressLbl.Size = new System.Drawing.Size(103, 13);
            this.progressLbl.TabIndex = 14;
            this.progressLbl.Text = "No files to download";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 377);
            this.Controls.Add(this.progressLbl);
            this.Controls.Add(this.downloadProgressBar);
            this.Controls.Add(this.downloadLinkRequiredChar);
            this.Controls.Add(this.programNameRequiredChar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.downloadLinkTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.programNameTxt);
            this.Controls.Add(this.modifyLinkBtn);
            this.Controls.Add(this.removeProgramBtn);
            this.Controls.Add(this.addProgramBtn);
            this.Controls.Add(this.programDownloadList);
            this.Controls.Add(this.downloadSpecificBtn);
            this.Controls.Add(this.downloadProgramsBtn);
            this.Controls.Add(this.exitAppBtn);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto -Download Programs";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitAppBtn;
        private System.Windows.Forms.Button downloadProgramsBtn;
        private System.Windows.Forms.Button downloadSpecificBtn;
        private System.Windows.Forms.CheckedListBox programDownloadList;
        private System.Windows.Forms.Button addProgramBtn;
        private System.Windows.Forms.Button removeProgramBtn;
        private System.Windows.Forms.Button modifyLinkBtn;
        private System.Windows.Forms.TextBox programNameTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox downloadLinkTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label programNameRequiredChar;
        private System.Windows.Forms.Label downloadLinkRequiredChar;
        private System.Windows.Forms.ProgressBar downloadProgressBar;
        private System.Windows.Forms.Label progressLbl;
    }
}

