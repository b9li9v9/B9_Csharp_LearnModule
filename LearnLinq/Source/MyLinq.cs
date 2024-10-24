using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnLinq.Source
{
    public class MyLinq
    {
        public static async Task<IList<int>> GenerateRandomNumbers(int count, int minValue, int maxValue)
        {
            IList<int> intList = new List<int>();

            var random = new Random();  // 创建一个 Random 实例

            for (int i = 0; i < count; i++)
            {
                // 生成一个在 minValue 和 maxValue 之间的随机整数
                int randomNumber = random.Next(minValue, maxValue);
                intList.Add(randomNumber);  // 将生成的数字添加到列表中
            }
            return intList;
        }

        public static async Task PrintIntList(IList<int> intList)
        {
            foreach (int i in intList)
            {
                Console.WriteLine(i);
            }
        }

    }
}
