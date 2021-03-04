using System;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //四则计算器
            Console.Write("请输入算式：");

            string expression = Console.ReadLine();

            var match = Regex.Match(expression, @"([0-9]+\.?[0-9]*)([\+\-\*\/])([0-9]+\.?[0-9]*)");
            if (match.Success)
            {
                var a = double.Parse(match.Groups[1].Value);
                var b = double.Parse(match.Groups[3].Value);
                var operatorStr = match.Groups[2].Value;
                switch (operatorStr)
                {
                    case "+":
                        Console.WriteLine($"{a} + {b} = {a + b}");
                        break;

                    case "-":
                        Console.WriteLine($"{a} - {b} = {a - b}");
                        break;

                    case "*":
                        Console.WriteLine($"{a} * {b} = {a * b}");
                        break;

                    case "/":
                        Console.WriteLine($"{a} / {b} = {a / b}");
                        break;

                }

            }
            else
            {
                Console.WriteLine("您输入的算式有误（目前仅支持二元四则运算）");
            }

            Console.ReadKey();
        }
    }
}
