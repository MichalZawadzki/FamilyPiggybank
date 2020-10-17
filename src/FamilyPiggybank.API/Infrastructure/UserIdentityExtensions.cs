using FamilyPiggybank.API.Infrastructure.Envelope;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FamilyPiggybank.API.Infrastructure
{
    public static class UserIdentityExtensions
    {
        public static Guid? GetId(this ClaimsPrincipal user)
        {
            string userId = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return null;
            }

            return new Guid(userId);
        }

        public static ICollection<Error> MapToMetaError(this IEnumerable<IdentityError> identityErrors) =>
            identityErrors
                .Select(identityError => new Error(identityError.Code, new[] { identityError.Description }))
                .ToList();
    }
}
