using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEFCore.Authorization
{
    public static class AppRoleGroup
    {
        public const string SystemAccess = nameof(SystemAccess);
        public const string ManagementHierarchy = nameof(ManagementHierarchy); 
    }
}

//"ManagementHierarchy"
//RoleId ClaimType	ClaimValue	Description	[Group]
//1   Department IT	User belongs to the IT department	ManagementHierarchy
//2	Position	Manager	User is a manager	ManagementHierarchy