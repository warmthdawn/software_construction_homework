using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public enum ShapeType
    {
        Rectangle,
        Square,
        IsoscelesTriangle
    }
    public class ShapeFactory
    {
        Random random = new Random();
        public Shape Create(ShapeType type, params double[] args)
        {
            switch (type)
            {
                case ShapeType.Rectangle:
                    if (args.Length < 2)
                        throw new ArgumentException("需要2个参数");
                    return new Rectange(args[0], args[1]);
                case ShapeType.Square:
                    if (args.Length < 1)
                        throw new ArgumentException("需要1个参数");
                    return new Square(args[0]);
                case ShapeType.IsoscelesTriangle:
                    if (args.Length < 2)
                        throw new ArgumentException("需要2个参数");
                    return new IsoscelesTriangle(args[0], args[1]);
            }

            return null;
        }

        public Shape CreateRandom()
        {
            var type = (ShapeType)random.Next(3);
            if (type == ShapeType.Square)
                return Create(type, random.Next(1, 10));
            return Create(type, random.Next(1, 10), random.Next(1, 10));
        }
    }
}