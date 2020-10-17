using System.Runtime.Serialization;

namespace FamilyPiggybank.API.Infrastructure.Envelope
{
    public enum ErrorType
    {
        [EnumMember(Value = "default_error")] DefaultError,
    }
}
