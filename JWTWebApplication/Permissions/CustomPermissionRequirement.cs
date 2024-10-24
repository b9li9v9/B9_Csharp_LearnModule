using Microsoft.AspNetCore.Authorization;

namespace JWTWebApplication.Permissions
{
    public class CustomPermissionRequirement : IAuthorizationRequirement
    {
        public List<string> Permissions { get; }

        public CustomPermissionRequirement(List<string> permissions)
        {
            Permissions = permissions;
        }
    }
}
