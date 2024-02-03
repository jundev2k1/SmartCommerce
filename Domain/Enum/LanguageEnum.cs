using System.Runtime.Serialization;

namespace Domain.Enum
{
    public enum LanguageEnum
    {
        [EnumMember(Value = "vi")]
        VietNamese,
        [EnumMember(Value = "en")]
        English,
        [EnumMember(Value = "jp")]
        Japanese,
    }
}
