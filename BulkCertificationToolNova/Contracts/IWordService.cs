using BulkCertificationToolNova.Models;
using System;
using System.Threading.Tasks;

namespace BulkCertificationToolNova.Contracts
{
    internal interface IWordService
    {
        IResult<Boolean> LoadTemplate(String fileName);

        IResult<Boolean> ApplyChanges(TemplateParts parts);

        Task<IResult<Boolean>> SaveFileAsAsync(String newPath);
    }
}
