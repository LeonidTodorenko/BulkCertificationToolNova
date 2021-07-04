using BulkCertificationToolNova.Models;
using System;
using System.Collections.Generic;

namespace BulkCertificationToolNova.Contracts
{
    internal interface IExcelService
    {
        IResult<Boolean> LoadSettings(string fileName);

        IEnumerable<User> Users { get; }

        IEnumerable<Language> Languages { get; }
    }
}
