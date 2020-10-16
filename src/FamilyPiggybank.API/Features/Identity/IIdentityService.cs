using FamilyPiggybank.API.Models;

namespace FamilyPiggybank.API.Features.Identity
{
    public interface IIdentityService
    {
        string GenerateJwtToken(User user, string secret);
    }
}
