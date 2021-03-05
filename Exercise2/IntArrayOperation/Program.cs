using System;
using System.Collections.Generic;
using System.Linq;

namespace IntArrayOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个数组（空格分隔）");
            var strArrays = Console.ReadLine().Split(' ');
            var intArrays = new int[strArrays.Length];
            if (strArrays.Length <= 0)
            {
                Console.WriteLine("数组为空！");
                return;
            }
            try
            {
                for (int i = 0; i < strArrays.Length; i++)
                {
                    intArrays[i] = int.Parse(strArrays[i]);
                }
            }
            catch
            {
                Console.WriteLine("输入的数字有误！");
                return;
            }

            int max, min, average;
            GetInfo(intArrays, out max, out min, out average);

            Console.WriteLine($"最大值：{max}, 最小值：{min}, 平均值{average}");
            Console.ReadLine();
        }

        public static void GetInfo(int[] intArrays, out int max, out int min, out int average)
        {
            max = min = average = intArrays[0];

            foreach (var i in intArrays[1..])
            {
                max = max >= i ? max : i;
                min = min <= i ? min : i;
                average += i;
            }


            average /= intArrays.Length;
        }
    }
}
