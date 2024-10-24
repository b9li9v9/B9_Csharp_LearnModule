using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LearnEFCore.Authorization
{
   

    public record class AppPermission(string Feature,string Action,string Group,string Description,bool IsBasic = false)//Description 描述
    {
        public string Name = NameFor(Feature, Action);
        public static string NameFor(string feature, string action)
            => $"Permission.{feature}.{action}";
    }
    /// <summary>
    /// 两个组，admin和basic
    /// </summary>
    public class AppPermissions 
    {
        private static readonly AppPermission[] _all = new AppPermission[]
            {
                new(AppFeature.Users, AppAction.Create, AppRoleGroup.SystemAccess, "Create Users"),
                new(AppFeature.Users, AppAction.Update, AppRoleGroup.SystemAccess, "Update Users"),
                new(AppFeature.Users, AppAction.Read, AppRoleGroup.SystemAccess, "Read Users"),
                new(AppFeature.Users, AppAction.Delete, AppRoleGroup.SystemAccess, "Delete Users"),

                new(AppFeature.UserRoles, AppAction.Read, AppRoleGroup.SystemAccess, "Read User Roles"),
                new(AppFeature.UserRoles, AppAction.Update, AppRoleGroup.SystemAccess, "Update User Roles"),

                new(AppFeature.Roles, AppAction.Read, AppRoleGroup.SystemAccess, "Read Roles"),
                new(AppFeature.Roles, AppAction.Create, AppRoleGroup.SystemAccess, "Create Roles"),
                new(AppFeature.Roles, AppAction.Update, AppRoleGroup.SystemAccess, "Update Roles"),
                new(AppFeature.Roles, AppAction.Delete, AppRoleGroup.SystemAccess, "Delete Roles"),

                new(AppFeature.RoleClaims, AppAction.Read, AppRoleGroup.SystemAccess, "Read Role Claims/Permissions"),
                new(AppFeature.RoleClaims, AppAction.Update, AppRoleGroup.SystemAccess, "Update Role Claims/Permissions"),
            };

        /// <summary>
        /// 获取admin组权限列表
        /// </summary>
        public static IReadOnlyList<AppPermission> AdminPermissions { get; } =
            new ReadOnlyCollection<AppPermission>(_all.Where(p => !p.IsBasic).ToArray());

        /// <summary>
        /// 获取basic组权限列表
        /// </summary>
        public static IReadOnlyList<AppPermission> BasicPermissions { get; } =
        new ReadOnlyCollection<AppPermission>(_all.Where(p => p.IsBasic).ToArray()); 

    }
}
