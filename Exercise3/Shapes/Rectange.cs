using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectange : Shape
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Rectange(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double Area
        {
            get
            {
                return Width * Height;
            }
        }
        public override string ShapeName
        {
            get
            {
                return "长方形";
            }
        }




        public override bool IsValid()
        {
            return Width > 0 && Height > 0;
        }

        
    }
}
