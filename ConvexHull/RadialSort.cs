using System;
using System.Collections.Generic;
using System.Drawing;

namespace ConvexHull
{
    class RadialSort : IComparer<Point>
    {
        private Point _pivot;


        public RadialSort(Point pivot)
        {
            _pivot = pivot;
        }

        public int Compare(Point pt1, Point pt2)
        {
            return SignedArea(_pivot, pt1,pt2);
        }

        public int SignedArea(Point a, Point b, Point c)
        {
            //abba bccb caac
            return a.X * b.Y - b.X * a.Y + b.X * c.Y - c.X * b.Y + c.X * a.Y - a.X * c.Y;
                // a.X * b.Y - b.X * a.Y + b.X * c.Y - c.X * b.Y + c.X * a.Y - a.X * c.Y;
        }
    }   
}
