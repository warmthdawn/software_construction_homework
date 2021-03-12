using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public abstract class Shape
    {
        public abstract double Area { get; }
        public abstract bool IsValid();
        public abstract string ShapeName { get; }
    }
}
