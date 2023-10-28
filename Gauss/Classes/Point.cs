using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauss.Classes
{
    internal class Point
    {
        public double _id {get;set;}

        public double _x { get;set;}

        public double _y { get;set;}

        public Point(double x, double y)
        {
            _id = 0;
            _x = x;
            _y = y;
        }
    }
}
