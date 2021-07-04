using BulkCertificationToolNova.Enums;
using System;
using System.Collections.Generic;

namespace BulkCertificationToolNova.Models
{
    internal class GeneratorData
    {
        public String TemplatesPath { get; set; }

        public String FilePrefix { get; set; }

        public String ExcelFile { get; set; }

        public IDictionary<AppMode, String> WordFiles { get; set; }

        public IEnumerable<String> FileNames { get; set; }
    }
}
