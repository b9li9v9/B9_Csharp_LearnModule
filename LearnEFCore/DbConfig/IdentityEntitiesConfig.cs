using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LearnEFCore.DbConfig
{
    internal class IdentityUserConfig : IEntityTypeConfiguration<IdentityUser>
    {                                           //ApplicationUser
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder
               .ToTable("Users", SchemaNames.Security);
        }
    }
    internal class IdentityRoleConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder
               .ToTable("Roles", SchemaNames.Security);
        }
    }

    internal class IdentityRoleClaimConfig : IEntityTypeConfiguration<IdentityRoleClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder)
        {
            builder
               .ToTable("RoleClaims", SchemaNames.Security);
        }
    }
    internal class IdentityUserClaimConfig : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            builder
               .ToTable("UserClaim", SchemaNames.Security);
        }
    }
    internal class IdentityUserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder
               .ToTable("UserRoles", SchemaNames.Security);
        }
    }
    internal class IdentityUserLoginConfig : IEntityTypeConfiguration<IdentityUserLogin<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
        {
            builder
               .ToTable("UserLogins", SchemaNames.Security);
        }
    }
    internal class IdentityUserTokenConfig : IEntityTypeConfiguration<IdentityUserToken<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
        {
            builder
               .ToTable("UserTokens", SchemaNames.Security);
        }
    }
}
