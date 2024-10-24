using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnLinq.Source
{
    public static class MyExtensions
    {
        public static IList<int> MyExtensionsWhere(this IList<int> list,Func<int,bool> func)
        {
            IList<int> tempList = new List<int>();

            foreach (var item in list) 
            {
                if (func(item)) 
                {
                    tempList.Add(item);
                }
            }
            return tempList;
        }
    }
}
