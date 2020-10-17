using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace FamilyPiggybank.API.Infrastructure.Envelope
{
    public class Error
    {
        public Error()
        {
        }

        public Error(string code, IList<string> reasons)
        {
            Code = code;
            Reasons = reasons;
        }

        [JsonProperty("code")] public string Code { get; set; }

        [JsonProperty("reasons")] public IList<string> Reasons { get; set; } = new List<string>();
    }
}
