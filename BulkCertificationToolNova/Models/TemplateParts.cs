using System;

namespace BulkCertificationToolNova.Models
{
    internal class TemplateParts
    {
        public TemplateItem SourceLanguage { get; set; }

        public TemplateItem TargetLanguage { get; set; }

        public TemplateItem NovaReference { get; set; }

        public TemplateItem StudyNumber { get; set; }

        public TemplateItem FileName { get; set; }

        public TemplateItem Manager { get; set; }

        public String ManagerSignature { get; set; }
    }
}
