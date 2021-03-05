using System;
using System.Collections.Generic;

namespace PrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个整数");
            var input = Console.ReadLine();
            int number;
            try
            {
                number = Convert.ToInt32(input);
            }
            catch
            {
                Console.WriteLine("你输入的数字不合法~咕咕！");
                return;
            }

            var result = GetPrime(number);
            Console.WriteLine("输入的数字的质因数为：" + string.Join(", ", result));
            Console.ReadLine();

        }

        private static IEnumerable<int> GetPrime(int number)
        {
            //计算质因数
            List<int> result = new List<int>();

            int i = 2;
            while (i <= number)
            {
                if (number % i == 0)
                {
                    number /= i;
                    yield return i;
                }
                else
                {
                    i++;
                }
            }
        }
    }
}
