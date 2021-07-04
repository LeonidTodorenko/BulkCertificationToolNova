using BulkCertificationToolNova.Contracts;
using BulkCertificationToolNova.Enums;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BulkCertificationToolNova
{
    internal partial class MainForm : Form
    {
        private readonly ICertificateGenerator _generator;
        private readonly String _progressLabel;
        private readonly String _notCreated;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(ICertificateGenerator generator)
            : this()
        {
            _generator = generator;

            _generator.Started += (o, e) => GeneratorStarted();
            _generator.Ended += (o, e) => GeneratorEnded();
            _generator.FileCreated += (o, e) => FileCreated();

            _progressLabel = lblProgress.Text;
            _notCreated = lblNotCreatedCount.Text;

            pbProgress.Maximum = _generator.FilesCount;
            lblProgress.Text = String.Format(_progressLabel, pbProgress.Value, _generator.FilesCount);

            //by default log items are hidden
            gbLog.Visible = false;
            Width = Width / 2;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var res = _generator.LoadSettingsData();
            if (res.HasError)
            {
                btnStart.Enabled = false;
                WriteLog(res.Error, true);
                return;
            }

            cbMode.DataSource = _generator.Modes.ToList();
            cbMode.DisplayMember = "Value";
            cbMode.ValueMember = "Key";

            cbUsers.DataSource = _generator.Users.ToList();
            cbUsers.DisplayMember = "Name";
            cbUsers.ValueMember = "Name";

            cbSourceLang.DataSource = _generator.Languages.ToList();
            cbSourceLang.DisplayMember = "Name";
            cbSourceLang.ValueMember = "Name";

            cbTargetLang.DataSource = _generator.Languages.ToList();
            cbTargetLang.DisplayMember = "Name";
            cbTargetLang.ValueMember = "Name";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var validate = ValidateFields();
            lblError.Visible = !validate;

            if (validate)
            {
                btnStart.Enabled = false;
                lblProgress.Visible = pbProgress.Visible = true;
                pbProgress.Value = 0;

                _generator.StartProcess
                    (
                        mode: (AppMode)cbMode.SelectedValue,
                        user: cbUsers.SelectedValue.ToString(),
                        sourceLanguage: cbSourceLang.SelectedValue.ToString(),
                        targetLanguage: cbTargetLang.SelectedValue.ToString(),
                        novaReference: tbReference.Text.Trim(),
                        studyNumber: tbStudyNumber.Text.Trim()
                    );
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            _generator.Stop();
        }

        #region Private

        private void GeneratorStarted()
        {
            btnStop.Enabled = true;
        }

        private void GeneratorEnded()
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;

            if (_generator.Errors != null && _generator.Errors.Any())
            {
                foreach (var error in _generator.Errors)
                {
                    WriteLog(error, true);
                }

                lblNotCreatedCount.Visible = true;
                lblNotCreatedCount.Text = String.Format(_notCreated, _generator.Errors.Count());
            }
            else
            {
                Application.Exit();
            }
        }

        private void FileCreated()
        {
            pbProgress.Value++;
            lblProgress.Text = String.Format(_progressLabel, pbProgress.Value, _generator.FilesCount);
        }

        private void WriteLog(String text, Boolean isError = false)
        {
            if (!gbLog.Visible)
            {
                Width = Width * 2;
                gbLog.Visible = true;
            }

            rtbLog.SelectionColor = isError ? Color.Red : SystemColors.ControlText;
            rtbLog.AppendText(rtbLog.TextLength > 0 ? Environment.NewLine + text : text);
        }

        private Boolean ValidateFields()
        {
            if (cbMode.SelectedValue == null)
            {
                cbMode.Select();
                return false;
            }

            if (cbUsers.SelectedValue == null)
            {
                cbUsers.Select();
                return false;
            }

            if (cbSourceLang.SelectedValue == null)
            {
                cbSourceLang.Select();
                return false;
            }

            if (cbTargetLang.SelectedValue == null)
            {
                cbTargetLang.Select();
                return false;
            }

            if (tbReference.Text.Trim().Length == 0)
            {
                tbReference.Select();
                return false;
            }

            return true;
        }

        #endregion
    }
}
