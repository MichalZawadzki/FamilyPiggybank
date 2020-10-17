using FamilyPiggybank.API.Infrastructure.Envelope;
using System.Collections.Generic;

namespace FamilyPiggybank.API.Infrastructure
{
    public static class EnvelopeExtensions
    {
        public static Envelope<T> AddError<T>(this Envelope<T> envelope, ErrorType errorType)
        {
            if(envelope.Errors == null)
            {
                envelope.Errors = new List<Error>();
            }
            envelope.Errors.Add(errorType.GetError());
            return envelope;
        }
    }
}
