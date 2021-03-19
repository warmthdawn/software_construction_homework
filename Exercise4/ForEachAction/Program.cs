using System;

namespace ForEachAction
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new GenericList<int>(new[] { 1, 2, 3, 4, 5, 6 });
            if(list.Head == null)
            {
                throw new ArgumentException("列表为空");
            }
            int max, min, sum;
            max = min = list.Head.Data;
            sum = 0;
            Console.WriteLine("--------列表元素--------");
            list.ForEachAction(v => Console.Write(v + " "));
            Console.WriteLine();
            Console.WriteLine("------------------------");
            list.ForEachAction(v =>
            {
                max = Math.Max(v, max);
                min = Math.Min(v, min);
                sum += v;
            });
            Console.WriteLine($"最大值:{max}, 最小值:{min}, 求和:{sum}");

        }
    }
}
