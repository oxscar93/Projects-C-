namespace ChatSystem
{
    partial class ChatWindow
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
            this.conversationTxt = new System.Windows.Forms.RichTextBox();
            this.messageTxt = new System.Windows.Forms.RichTextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // conversationTxt
            // 
            this.conversationTxt.Location = new System.Drawing.Point(12, 40);
            this.conversationTxt.Name = "conversationTxt";
            this.conversationTxt.Size = new System.Drawing.Size(539, 239);
            this.conversationTxt.TabIndex = 0;
            this.conversationTxt.Text = "";
            // 
            // messageTxt
            // 
            this.messageTxt.Location = new System.Drawing.Point(12, 307);
            this.messageTxt.Name = "messageTxt";
            this.messageTxt.Size = new System.Drawing.Size(420, 52);
            this.messageTxt.TabIndex = 1;
            this.messageTxt.Text = "";
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(439, 307);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(112, 52);
            this.sendBtn.TabIndex = 2;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 372);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.messageTxt);
            this.Controls.Add(this.conversationTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ChatWindow";
            this.Text = "Chat Window";
            this.Load += new System.EventHandler(this.ChatWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox conversationTxt;
        private System.Windows.Forms.RichTextBox messageTxt;
        private System.Windows.Forms.Button sendBtn;
    }
}