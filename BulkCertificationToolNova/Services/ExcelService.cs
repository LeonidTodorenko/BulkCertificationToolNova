using BulkCertificationToolNova.Contracts;
using BulkCertificationToolNova.Models;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BulkCertificationToolNova.Services
{
    internal class ExcelService : IExcelService
    {
        public IResult<Boolean> LoadSettings(string fileName)
        {
            try
            {
                using (var book = new XLWorkbook(fileName))
                {
                    Users = book.Worksheet(1).Rows().Skip(1)
                        .Select(r => new User
                        {
                            Name = r.Cell(1).Value.ToString().Trim(),
                            ImagePath = r.Cell(2).Value.ToString().Trim()
                        });

                    Languages = book.Worksheet(2).Rows().Skip(1)
                        .Select(r => new Language
                        {
                            Name = r.Cell(1).Value.ToString().Trim()
                        });

                    return new Result<Boolean>(true);
                }
            }
            catch (Exception ex)
            {
                return new Result<Boolean>(false, ex.Message);
            }
        }


        public IEnumerable<User> Users { get; private set; }

        public IEnumerable<Language> Languages { get; private set; }
    }
}
