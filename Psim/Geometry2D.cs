using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psim
{
    namespace Geometry2D
    {
        /// <summary>
        /// Point class that holds the points X and Y coordinates as well as has methods to get 
        /// points coordinates and set points coordinates
        /// </summary>
        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }

            public Point() { }
            public Point(double x = 0, double y = 0)
            {
                SetCoords(x, y);
            }

            public void GetCoords(out double x, out double y)
            {
                x = X;
                y = Y;
            }

            public void SetCoords(double? x, double? y)
            {
                X = x ?? X;
                Y = y ?? Y;
            }

            public override string ToString()
            {
                return $"X: {X} Y: {Y}\n" +
                base.ToString();
            }
        }

        /// <summary>
        /// Vector class that contains vectors DX and DY as well 
        /// as a method to set DX and DY within a range of -1 to 1
        /// </summary>
        public class Vector
        {
            public double DX { get; private set; }
            public double DY { get; private set; }

            public Vector(double dx = 0, double dy = 0)
            {
                Set(dx, dy);
            }

            public void Set(double dx, double dy)
            {
                // Lambda function to check if value is within -1 and 1
                bool InRange(double x) => (x >= -1 && x <= 1);

                if (InRange(dx) && InRange(dy))
                {
                    DX = dx;
                    DY = dy;
                }
                else
                    throw new ArgumentOutOfRangeException();
            }

            public void Get(out double dx, out double dy)
            {
                dx = DX;
                dy = DY;
            }

        }

        /// <summary>
        /// Rectangle class containing rectangles length, width, and area. 
        /// These variables can be set only in the classes constructor
        /// </summary>
        public class Rectangle
        {
            public double Length { get; }
            public double Width { get; }
            public double Area { get; }

            public Rectangle(double length, double width)
            {
                Length = length;
                Width = width;

                Area = length * width;
            }


        }
    }
}
