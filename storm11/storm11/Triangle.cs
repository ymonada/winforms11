using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storm11
{
    public class Triangle
    {
        public Point A {get;set;}
        public Point B { get; set; }
        public Point C { get; set; }
        public Color Color { get; set; } = Color.Black;
        public Triangle(Point A, Point B, Point C) 
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

    }
}
