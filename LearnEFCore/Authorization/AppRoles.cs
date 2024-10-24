using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEFCore.Authorization
{
    public static class AppRoles
    {
        public const string Admin = nameof(Admin);
        public const string Basic = nameof(Basic);

        public static IReadOnlyList<string> DefaultRoles { get; }
            = new ReadOnlyCollection<string>(new[]
            {
                Admin,
                Basic
            });

        public static bool IsDefault(string roleName)
            => DefaultRoles.Any(x => x == roleName);//Any 只找一个就返回
    }
}
