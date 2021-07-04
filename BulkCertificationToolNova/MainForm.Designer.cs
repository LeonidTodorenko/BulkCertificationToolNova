namespace BulkCertificationToolNova
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.cbSourceLang = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblSourceLang = new System.Windows.Forms.Label();
            this.lblTargetLang = new System.Windows.Forms.Label();
            this.cbTargetLang = new System.Windows.Forms.ComboBox();
            this.lblReference = new System.Windows.Forms.Label();
            this.tbStudyNumber = new System.Windows.Forms.TextBox();
            this.tbReference = new System.Windows.Forms.TextBox();
            this.lblStudyNumber = new System.Windows.Forms.Label();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.lblNotCreatedCount = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pnProgress = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.lbOptional = new System.Windows.Forms.Label();
            this.gbSettings.SuspendLayout();
            this.gbLog.SuspendLayout();
            this.pnProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.lbOptional);
            this.gbSettings.Controls.Add(this.cbMode);
            this.gbSettings.Controls.Add(this.lblMode);
            this.gbSettings.Controls.Add(this.cbUsers);
            this.gbSettings.Controls.Add(this.cbSourceLang);
            this.gbSettings.Controls.Add(this.lblUser);
            this.gbSettings.Controls.Add(this.lblSourceLang);
            this.gbSettings.Controls.Add(this.lblTargetLang);
            this.gbSettings.Controls.Add(this.cbTargetLang);
            this.gbSettings.Controls.Add(this.lblReference);
            this.gbSettings.Controls.Add(this.tbStudyNumber);
            this.gbSettings.Controls.Add(this.tbReference);
            this.gbSettings.Controls.Add(this.lblStudyNumber);
            this.gbSettings.Location = new System.Drawing.Point(12, 12);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(285, 217);
            this.gbSettings.TabIndex = 0;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // cbMode
            // 
            this.cbMode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Location = new System.Drawing.Point(6, 38);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(273, 21);
            this.cbMode.TabIndex = 5;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(3, 22);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(51, 13);
            this.lblMode.TabIndex = 4;
            this.lblMode.Text = "Template";
            // 
            // cbUsers
            // 
            this.cbUsers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbUsers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(6, 87);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(273, 21);
            this.cbUsers.TabIndex = 0;
            // 
            // cbSourceLang
            // 
            this.cbSourceLang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSourceLang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSourceLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceLang.FormattingEnabled = true;
            this.cbSourceLang.Location = new System.Drawing.Point(6, 137);
            this.cbSourceLang.Name = "cbSourceLang";
            this.cbSourceLang.Size = new System.Drawing.Size(121, 21);
            this.cbSourceLang.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(6, 71);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(49, 13);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Manager";
            // 
            // lblSourceLang
            // 
            this.lblSourceLang.AutoSize = true;
            this.lblSourceLang.Location = new System.Drawing.Point(3, 121);
            this.lblSourceLang.Name = "lblSourceLang";
            this.lblSourceLang.Size = new System.Drawing.Size(92, 13);
            this.lblSourceLang.TabIndex = 0;
            this.lblSourceLang.Text = "Source Language";
            // 
            // lblTargetLang
            // 
            this.lblTargetLang.AutoSize = true;
            this.lblTargetLang.Location = new System.Drawing.Point(155, 121);
            this.lblTargetLang.Name = "lblTargetLang";
            this.lblTargetLang.Size = new System.Drawing.Size(89, 13);
            this.lblTargetLang.TabIndex = 0;
            this.lblTargetLang.Text = "Target Language";
            // 
            // cbTargetLang
            // 
            this.cbTargetLang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbTargetLang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTargetLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTargetLang.FormattingEnabled = true;
            this.cbTargetLang.Location = new System.Drawing.Point(158, 137);
            this.cbTargetLang.Name = "cbTargetLang";
            this.cbTargetLang.Size = new System.Drawing.Size(121, 21);
            this.cbTargetLang.TabIndex = 1;
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Location = new System.Drawing.Point(3, 170);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(90, 13);
            this.lblReference.TabIndex = 2;
            this.lblReference.Text = "NOVA Reference";
            // 
            // tbStudyNumber
            // 
            this.tbStudyNumber.Location = new System.Drawing.Point(158, 187);
            this.tbStudyNumber.Name = "tbStudyNumber";
            this.tbStudyNumber.Size = new System.Drawing.Size(121, 20);
            this.tbStudyNumber.TabIndex = 3;
            // 
            // tbReference
            // 
            this.tbReference.Location = new System.Drawing.Point(6, 187);
            this.tbReference.Name = "tbReference";
            this.tbReference.Size = new System.Drawing.Size(121, 20);
            this.tbReference.TabIndex = 2;
            // 
            // lblStudyNumber
            // 
            this.lblStudyNumber.AutoSize = true;
            this.lblStudyNumber.Location = new System.Drawing.Point(155, 170);
            this.lblStudyNumber.Name = "lblStudyNumber";
            this.lblStudyNumber.Size = new System.Drawing.Size(74, 13);
            this.lblStudyNumber.TabIndex = 2;
            this.lblStudyNumber.Text = "Study Number";
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.rtbLog);
            this.gbLog.Location = new System.Drawing.Point(303, 12);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(319, 309);
            this.gbLog.TabIndex = 2;
            this.gbLog.TabStop = false;
            this.gbLog.Text = "Log";
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(3, 16);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(313, 290);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // lblNotCreatedCount
            // 
            this.lblNotCreatedCount.AutoSize = true;
            this.lblNotCreatedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNotCreatedCount.ForeColor = System.Drawing.Color.Red;
            this.lblNotCreatedCount.Location = new System.Drawing.Point(128, 22);
            this.lblNotCreatedCount.Name = "lblNotCreatedCount";
            this.lblNotCreatedCount.Size = new System.Drawing.Size(151, 13);
            this.lblNotCreatedCount.TabIndex = 15;
            this.lblNotCreatedCount.Text = "{0} files were not created";
            this.lblNotCreatedCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblNotCreatedCount.Visible = false;
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(6, 38);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(273, 19);
            this.pbProgress.TabIndex = 13;
            this.pbProgress.Visible = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(52, 63);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Generate";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(158, 63);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(3, 22);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(84, 13);
            this.lblProgress.TabIndex = 12;
            this.lblProgress.Text = "Progress {0}/{1}";
            this.lblProgress.Visible = false;
            // 
            // pnProgress
            // 
            this.pnProgress.Controls.Add(this.pbProgress);
            this.pnProgress.Controls.Add(this.btnStop);
            this.pnProgress.Controls.Add(this.btnStart);
            this.pnProgress.Controls.Add(this.lblNotCreatedCount);
            this.pnProgress.Controls.Add(this.lblError);
            this.pnProgress.Controls.Add(this.lblProgress);
            this.pnProgress.Location = new System.Drawing.Point(12, 235);
            this.pnProgress.Name = "pnProgress";
            this.pnProgress.Size = new System.Drawing.Size(285, 86);
            this.pnProgress.TabIndex = 1;
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(6, 1);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(273, 13);
            this.lblError.TabIndex = 14;
            this.lblError.Text = "Please fill all required fields!";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblError.Visible = false;
            // 
            // lbOptional
            // 
            this.lbOptional.AutoSize = true;
            this.lbOptional.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbOptional.Location = new System.Drawing.Point(224, 171);
            this.lbOptional.Name = "lbOptional";
            this.lbOptional.Size = new System.Drawing.Size(45, 12);
            this.lbOptional.TabIndex = 6;
            this.lbOptional.Text = "(Optional)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 331);
            this.Controls.Add(this.pnProgress);
            this.Controls.Add(this.gbLog);
            this.Controls.Add(this.gbSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulk Certification Tool [NOVA]";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.gbLog.ResumeLayout(false);
            this.pnProgress.ResumeLayout(false);
            this.pnProgress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.ComboBox cbSourceLang;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblSourceLang;
        private System.Windows.Forms.Label lblTargetLang;
        private System.Windows.Forms.ComboBox cbTargetLang;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.TextBox tbStudyNumber;
        private System.Windows.Forms.TextBox tbReference;
        private System.Windows.Forms.Label lblStudyNumber;
        private System.Windows.Forms.GroupBox gbLog;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label lblNotCreatedCount;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Panel pnProgress;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lbOptional;
    }
}

