using LearnEFCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LearnEFCore.Context
{
    public class ApplicationDbContext
            : IdentityDbContext<
                IdentityUser,
                IdentityRole,
                string,
                IdentityUserClaim<string>,
                IdentityUserRole<string>,
                IdentityUserLogin<string>,
                IdentityRoleClaim<string>,
                IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }

            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public DbSet<Car> Cars { get; set; }

    }
}
