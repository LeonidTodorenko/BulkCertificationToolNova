using System;

namespace BulkCertificationToolNova.Models
{
    internal class TemplateItem
    {
        public TemplateItem(String template, String value)
        {
            Template = template;
            Value = value;
        }

        public TemplateItem(String template)
            : this(template, String.Empty)
        {
        }

        public String Template { get; set; }

        public String Value { get; set; }
    }
}
