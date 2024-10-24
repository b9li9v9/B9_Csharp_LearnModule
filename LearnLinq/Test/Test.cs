using LearnLinq.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnLinq.Test
{
    public class TestLinq
    {
        public async Task TestLinqMain(bool io = false) 
        {
            if (io) 
            {
                IList<int> intList = await MyLinq.GenerateRandomNumbers(10, 1, 100);
                await MyLinq.PrintIntList(intList);
                Console.WriteLine();
                Console.ReadKey();

                IList<int> tempList = intList.Where(x => x > 50).ToList();
                await MyLinq.PrintIntList(tempList);
                Console.WriteLine();
                Console.ReadKey();

                IList<int> customWhereTempList = intList.MyExtensionsWhere(i => i > 80).ToList();
                await MyLinq.PrintIntList(customWhereTempList);
                Console.WriteLine();
                Console.ReadKey();
            }
        }


    }
}
