using System;
using System.Collections.Generic;

namespace AngularSieve
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = GetNumbers(2, 100);

            Console.WriteLine("2-100内的质数有：" + string.Join(", ", result));
        }

        private static IEnumerable<int> GetNumbers(int min, int max)
        {
            //标记 flag[i] 代表 min+i 是不是质数
            bool?[] resultFlags = new bool?[max - min + 1];
            int minIndex = 0;
            int minValue;
            //不可能超过max开方
            double maxPossible = Math.Sqrt(max);
            do
            {
                //获取未处理的最小数字
                while (minIndex < resultFlags.Length - 1 && resultFlags[minIndex].HasValue)
                {
                    minIndex++;
                }
                minValue = minIndex + min;
                //添加minValue这个值
                resultFlags[minIndex] = true;
                //排除minValue的整数倍数字
                for (int i = minValue * 2; i <= max; i += minValue)
                {
                    resultFlags[i - min] = false;
                }
            } while (minValue < maxPossible);

            //没有读取到的数字全都是质数
            for (int i = 0; i < resultFlags.Length; i++)
            {
                if (!resultFlags[i].HasValue)
                {
                    resultFlags[i] = true;
                }
            }



            //返回结果
            for (int i = 0; i < resultFlags.Length; i++)
            {
                if (resultFlags[i] == true)
                    yield return i + min;

            }

        }
    }
}
