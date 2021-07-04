using System.ComponentModel;

namespace BulkCertificationToolNova.Enums
{
    internal enum AppMode
    {
        [Description("Forward Translation Certificate NOVA")]
        ForwardTranslation,

        [Description("Forward Translation Certificate NOVA with Study")]
        ForwardTranslationWithStudy,

        [Description("Back Translation Certificate NOVA")]
        BackTranslation,

        [Description("Back Translation Certificate NOVA with Study")]
        BackTranslationWithStudy
    }
}
