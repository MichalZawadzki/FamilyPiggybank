using System;
using FamilyPiggybank.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FamilyPiggybank.API.Data
{
    public class FamilyPiggybankDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public FamilyPiggybankDbContext(DbContextOptions<FamilyPiggybankDbContext> options)
            : base(options)
        {
        }
    }
}
