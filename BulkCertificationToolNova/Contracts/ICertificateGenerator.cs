using BulkCertificationToolNova.Enums;
using BulkCertificationToolNova.Models;
using System;
using System.Collections.Generic;

namespace BulkCertificationToolNova.Contracts
{
    internal interface ICertificateGenerator
    {
        event EventHandler Started;

        event EventHandler Ended;

        event EventHandler<Boolean> FileCreated;

        IResult<Boolean> LoadSettingsData();

        IResult<Boolean> LoadTemplate(AppMode mode);

        IDictionary<AppMode, String> Modes { get; }

        IEnumerable<Language> Languages { get; }

        IEnumerable<User> Users { get; }

        IEnumerable<String> Errors { get; }

        Int32 FilesCount { get; }

        void StartProcess(AppMode mode, String user, String sourceLanguage, String targetLanguage, String novaReference, String studyNumber);

        void Stop();
    }
}
