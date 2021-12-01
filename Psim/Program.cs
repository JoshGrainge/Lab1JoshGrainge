using Psim.Materials;
using Psim.IOManagers;
using System;
using System.Collections.Generic;

namespace Psim
{
    class Program
    {
        static void Main(string[] args)
        {
            
            const string path = "D:/CPIN Folder/OOP 2/Lab1JoshGrainge/Lab1JoshGrainge/Psim/model.json";

            Model model = InputManager.InitializeModel(path);

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            model.RunSimulation("D:/CPIN Folder/OOP 2/Lab1JoshGrainge/Lab1JoshGrainge/Psim");

            watch.Stop();
            System.Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds / 1000} [s]");
            
            
            Console.ReadKey();
        }

    }
}
