using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///授权
namespace LearnEFCore.Authorization
{
    public static class AppAction//操作 动作
    {
        public const string Read = nameof(Read);
        public const string Create = nameof(Create);
        public  const string Delete = nameof(Delete);
        public const string Update = nameof(Update);
    }
}
