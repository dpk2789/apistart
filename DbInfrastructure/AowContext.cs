using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DbInfrastructure
{
    public class AowContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public AowContext(DbContextOptions<AowContext> options) : base(options)
        {

        }
    }
}