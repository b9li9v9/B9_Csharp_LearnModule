using LearnEFCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEFCore.Context
{
    public class ApplicationDbseeder
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _dbContext;

        public ApplicationDbseeder
            (UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        public async Task SeedDatabaseAsync()
        {
            await CheckAndApplyPendingMigrationAsync(); //更新迁移
            await SeedRolesAsync(); //根据AppRoles.cs和AppPermission.cs 更新数据库的Role和RoleClaim
            await SeedAdminUserAsync(); // 初始一个admin、分配角色、写入User和Role表
        }
        private async Task CheckAndApplyPendingMigrationAsync()
        {
            //_dbContext.Database.EnsureCreated(); 检查数据库是否存在，但这种方式数据库内没有迁移纪录
            if (_dbContext.Database.GetAppliedMigrations().Any())
            {
                await _dbContext.Database.MigrateAsync();
            }
        }


        private async Task SeedRolesAsync()
        {
            // 检查角色列表是否存在于数据库Role表
            foreach (var roleName in AppRoles.DefaultRoles)
            {
                if (await _roleManager.Roles.FirstOrDefaultAsync(r => r.Name == roleName) is not IdentityRole role)
                {
                    role = new IdentityRole
                    {
                        Name = roleName,
                    };
                    await _roleManager.CreateAsync(role); //写入Role表
                }

                // 根据相应角色写进相应Claim
                if (roleName == AppRoles.Admin)
                {
                    await AssingPermissionsToRoleAsync(role, AppPermissions.AdminPermissions);
                }
                else if (roleName == AppRoles.Basic)
                {
                    await AssingPermissionsToRoleAsync(role, AppPermissions.BasicPermissions);
                }
            }
        }

        private async Task AssingPermissionsToRoleAsync(IdentityRole role, IReadOnlyList<AppPermission> permissions)
        {
            // 去RoleClaim表
            // 找到这个role的所有Claim,
            var currentClaims = await _roleManager.GetClaimsAsync(role); 
            foreach (var permission in permissions)
            {
                // 如果这个Role没有这个Claim,
                // 写一条进RoleClaim
                if (!currentClaims.Any(claim => claim.Type == AppClaim.Permission && claim.Value == permission.Name))
                {
                    await _dbContext.RoleClaims.AddAsync(new IdentityRoleClaim<string>// <string>指定了 ClaimType 和 ClaimValue 两个属性的数据类型。
                    {
                        RoleId = role.Id,
                        ClaimType = AppClaim.Permission,
                        ClaimValue = permission.Name
                    });

                    await _dbContext.SaveChangesAsync();

                }
            }
        }



        private async Task SeedAdminUserAsync()
        {
            // 创建个admin用户
            string adminUserName = AppCredentials.Email[..AppCredentials.Email.IndexOf('@')].ToLowerInvariant();
            var adminUser = new IdentityUser
            {
                Email = AppCredentials.Email,
                UserName = adminUserName,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                NormalizedEmail = AppCredentials.Email.ToUpperInvariant(),
                NormalizedUserName = adminUserName.ToUpperInvariant(),
            };
            // 写入User表
            if (!await _userManager.Users.AnyAsync(u => u.Email == AppCredentials.Email))
            {
                var password = new PasswordHasher<IdentityUser>();
                adminUser.PasswordHash = password.HashPassword(adminUser, AppCredentials.Password);
                await _userManager.CreateAsync(adminUser);
            }
            // 将这个用户写入角色表
            if (!await _userManager.IsInRoleAsync(adminUser, AppRoles.Basic)
                && !await _userManager.IsInRoleAsync(adminUser, AppRoles.Admin))
            {
                await _userManager.AddToRolesAsync(adminUser, AppRoles.DefaultRoles);
            }
        }



    }


}
