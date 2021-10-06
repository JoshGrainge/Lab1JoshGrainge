using Psim.Geometry2D;
using Psim.Particles;
using Psim.ModelComponents;
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
            //Cell c = new Cell(10, 10);

            //Phonon p = new Phonon(1);
            //p.SetDirection(0.5, 0.5);

            //BoundarySurface s = new BoundarySurface(SurfaceLocation.left, new Cell(10,10));

            Cell cell = new Cell(10, 10);

            // Add 5 phonons
            for (int i = 0; i < 5; i++)
                cell.AddPhonon(new Phonon(1));

            // Add 7 incoming phonons
            for (int i = 0; i < 7; i++)
                cell.AddIncPhonon(new Phonon(1));

            // Add existing and incoming phonons together (5+7) for a sum of 12
            cell.MergeIncPhonons();

            cell.ToString();

            Console.WriteLine(cell);
            //s.HandlePhonon(p);
            //Console.WriteLine(p);

            Console.ReadKey();
        }
    }

}
       
