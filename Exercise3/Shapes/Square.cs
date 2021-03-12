using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Square : Rectange
    {
        public Square(double side)
            : base(side, side)
        {

        }

        public double Side
        {
            get
            {
                return Width;
            }
        }


        public override string ShapeName
        {
            get
            {
                return "正方形";
            }
        }
    }
}
