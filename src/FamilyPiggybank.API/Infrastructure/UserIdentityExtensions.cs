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
    }
}
