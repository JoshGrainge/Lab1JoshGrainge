using System;

using Psim.Particles;
using Psim.ModelComponents;
using Psim.Materials;

namespace Psim
{
    class Program
    {
        static void Main(string[] args)
        {
            DispersionData dData;
            dData.LaData = new double[] { -2.22e-7, 9260.0, 0.0 };
            dData.TaData = new double[] { -2.28e-7, 5240.0, 0.0 };
            dData.WMaxLa = 7.63916048e13;
            dData.WMaxTa = 3.0100793072e13;

            RelaxationData rData;
            rData.Bl = 1.3e-24;
            rData.Btn = 9e-13;
            rData.Btu = 1.9e-18;
            rData.BI = 1.2e-45;
            rData.W = 2.42e13;

            Material silicon = new Material(in dData, in rData);

            double highTemp = 1.425;
            double lowTemp = 0.253;
            double simTime = 1;
            Model model = new Model(silicon, highTemp, lowTemp, simTime);

            model.AddSensor(4, 0.5);    // Ensure adding sensor doesn't throw error

            // Test if duplicate throws error
            try
            {
                model.AddSensor(4, 1);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            // Test that invalid sensor id throws error
            try
            {
                model.AddCell(3, 3, 12);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            // Test that new cell gets added and doesn't throw error
            model.AddCell(2, 2, 4); 

            // test if having too few cells throws error
            try
            {
                model.CallSetSurfaces();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Ensure set surfaces works with proper amount of cells (3)
            model.AddCell(2, 2, 4);
            model.CallSetSurfaces();

            Console.ReadKey();
        }
    }
}
