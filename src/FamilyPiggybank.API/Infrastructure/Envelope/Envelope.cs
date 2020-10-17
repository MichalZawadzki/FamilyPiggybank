using System;
using System.Collections.Generic;

namespace FamilyPiggybank.API.Infrastructure.Envelope
{
    public class Envelope<T>
    {
        public T Data { get; }
        public ICollection<Error> Errors { get; set; }
        public DateTime TimeGenerated { get; }

        protected internal Envelope(T result, ICollection<Error> errors)
        {
            Data = result;
            Errors = errors;
            TimeGenerated = DateTime.UtcNow;
        }
    }

    public class Envelope : Envelope<Error>
    {
        protected Envelope(ICollection<Error> errors) : base(null, errors)
        {
        }

        public static Envelope<T> Ok<T>(T result) => new Envelope<T>(result, errors: null);
        public static Envelope Ok() => new Envelope(null);
        public static Envelope Error(Error error) => new Envelope(new List<Error>() { error });
        public static Envelope Error(ICollection<Error> errors) => new Envelope(errors);
    }
}
