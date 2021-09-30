using Psim.Geometry2D;
using Psim.Particles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psim
{

    class Program
    {
        static void Main(string[] args)
        {
            Phonon p1 = new Phonon(1);

            Phonon p2 = new Phonon(p1);

            p1.SetCoords(5, 5);

            p1.GetCoords(out double x, out double y);

            Console.WriteLine($"Get Coords X: {x} Y: {y}");

            x = 1000;
            x = 200;


            Console.WriteLine($"Get Coords X: {x} Y: {y}");

            Console.WriteLine(p1);

            p2.Position = new Point(1, 1);

            Console.WriteLine(p1);

            Console.WriteLine(p2);

            Console.ReadKey();
        }
    }

}
       
