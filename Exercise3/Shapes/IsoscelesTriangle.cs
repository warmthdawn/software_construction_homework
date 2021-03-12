using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class IsoscelesTriangle : Shape
    {
        public double Bottom { get; private set; }
        public double Height { get; private set; }

        public IsoscelesTriangle(double bottom, double height)
        {
            Bottom = bottom;
            Height = height;
        }


        public override double Area
        {
            get
            {
                return Bottom * Height / 2;
            }
        }
        public override string ShapeName
        {
            get
            {
                return "等腰三角形";
            }
        }


        public override bool IsValid()
        {
            return Bottom > 0 && Height > 0;
        }
    }
}
