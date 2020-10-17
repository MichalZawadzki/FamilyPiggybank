using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPiggybank.API.Infrastructure.Envelope
{
    internal static class Errors
    {
        public static IList<Error> Values { get; } = new List<Error>
        {
            new Error(ErrorType.DefaultError.ToSerializationName(),
                new[] {"Default error."})
        };

        public static Error GetError(this ErrorType type) =>
            Values.SingleOrDefault(error => error.Code == type.ToSerializationName());
    }
}