using BulkCertificationToolNova.Contracts;
using BulkCertificationToolNova.Enums;
using BulkCertificationToolNova.Extensions;
using BulkCertificationToolNova.Models;
using BulkCertificationToolNova.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BulkCertificationToolNova
{
    internal class CertificateGenerator : ICertificateGenerator
    {
        private readonly TemplateParts _parts;
        private readonly GeneratorData _data;

        private readonly IExcelService _excel;
        private readonly IWordService _word;

        private List<String> _errors;
        private CancellationTokenSource _cts;

        public CertificateGenerator(TemplateParts parts, GeneratorData data)
        {
            _parts = parts;
            _data = data;

            _excel = new ExcelService();
            _word = new WordService();

            _errors = new List<String>();
        }

        public event EventHandler Started;

        public event EventHandler Ended;

        public event EventHandler<Boolean> FileCreated;

        public IResult<Boolean> LoadSettingsData()
        {
            var path = Path.Combine(_data.TemplatesPath, _data.ExcelFile);
            var fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                var message = String.Format("Settings file \"{0}\" doesn't exists. Application will be stopped.", path);
                return new Result<Boolean>(false, message);
            }

            if (!fileInfo.Extension.Equals(".xlsx"))
            {
                var message = String.Format("Settings file \"{0}\" must be a \".xlsx\"-file. Application will be stopped.", path);
                return new Result<Boolean>(false, message);
            }

            var result = _excel.LoadSettings(path);
            return result;
        }

        public IResult<Boolean> LoadTemplate(AppMode mode)
        {
            var path = Path.Combine(_data.TemplatesPath, _data.WordFiles[mode]);
            var fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                var message = String.Format("Template file \"{0}\" doesn't exists. Application will be stopped.", path);
                return new Result<Boolean>(false, message);
            }

            if (!fileInfo.Extension.Equals(".docx"))
            {
                var message = String.Format("Template file \"{0}\" must be a \".docx\"-file. Application will be stopped.", path);
                return new Result<Boolean>(false, message);
            }

            var result = _word.LoadTemplate(path);
            return result;
        }

        public IDictionary<AppMode, String> Modes
        {
            get
            {
                return EnumExtension.GetItems<AppMode>()
                    .ToDictionary(n => n, n => n.GetCustomAttribyte<DescriptionAttribute>().Description);
            }
        }

        public IEnumerable<Language> Languages
        {
            get
            {
                return _excel.Languages;
            }
        }

        public IEnumerable<User> Users
        {
            get
            {
                return _excel.Users;
            }
        }

        public IEnumerable<String> Errors
        {
            get
            {
                return _errors;
            }
        }

        public int FilesCount
        {
            get
            {
                return _data.FileNames.Count();
            }
        }

        public async void StartProcess(AppMode mode, String user, String sourceLanguage, String targetLanguage, String novaReference, String studyNumber)
        {
            _errors = new List<String>();
            _cts = new CancellationTokenSource();

            if (Started != null)
            {
                Started(this, new EventArgs());
            }

            var usr = _excel.Users.Single(u => u.Name == user);

            await CreateCertificateFile(mode, usr, sourceLanguage, targetLanguage, novaReference, studyNumber);

            if (Ended != null)
            {
                Ended(this, new EventArgs());
            }
        }

        public void Stop()
        {
            _cts.Cancel();
        }

        #region Private

        private async Task CreateCertificateFile(AppMode mode, User user, String sourceLanguage, String targetLanguage, String novaReference, String studyNumber)
        {
            if (String.IsNullOrWhiteSpace(user.ImagePath))
            {
                _errors.Add(String.Format("There is no signature for {0}", user.Name));
                return;
            }

            _parts.Manager.Value = user.Name;
            _parts.ManagerSignature = user.ImagePath;

            _parts.SourceLanguage.Value = sourceLanguage;
            _parts.TargetLanguage.Value = targetLanguage;
            _parts.NovaReference.Value = novaReference;
            _parts.StudyNumber.Value = studyNumber;

            foreach (var fileName in _data.FileNames)
            {
                if (_cts.IsCancellationRequested)
                {
                    return;
                }

                LoadTemplate(mode);

                _parts.FileName.Value = Path.GetFileName(fileName);

                var apply = _word.ApplyChanges(_parts);
                if (apply.HasError)
                {
                    _errors.Add(apply.Error);
                    break;
                }

                var directory = Path.GetDirectoryName(fileName) ?? String.Empty;
                var path = Path.Combine(directory, _data.FilePrefix + Path.GetFileNameWithoutExtension(fileName) + ".docx");

                var result = await _word.SaveFileAsAsync(path);

                if (FileCreated != null)
                {
                    FileCreated(this, result.Value);
                }

                if (result.HasError)
                {
                    _errors.Add(result.Error);
                }
            }
        }

        #endregion
    }
}
