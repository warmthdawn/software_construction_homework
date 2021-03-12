using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ShapeFactory();

            //创建随机对象
            double sum = 0;
            for (int i = 0; i < 10; i++)
            {
                var shape = factory.CreateRandom();
                var area = shape.Area;
                sum += area;
                Console.WriteLine($"第 {i} 个图形是 {shape.ShapeName} , 面积为 {area}");
            }
            Console.WriteLine($"面积和为 {sum}");
        }
    }
}
