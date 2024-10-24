using JWTWebApplication.Authorization;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace JWTWebApplication.Permissions
{
    public class CustomPermissionAuthorizationHandler : AuthorizationHandler<CustomPermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomPermissionRequirement requirement)
        {
            var userPermissions = GetUserPermissions(context.User);

            if (requirement.Permissions.Any(p => userPermissions.Contains(p)))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

        private List<string> GetUserPermissions(ClaimsPrincipal user)
        {
            return user.Claims
                .Where(c => c.Type == AppClaim.Permission)
                .Select(c => c.Value)
                .ToList();
        }
    }
}
