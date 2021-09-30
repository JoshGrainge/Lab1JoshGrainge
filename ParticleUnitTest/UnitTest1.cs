using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParticleUnitTest
{
    using Psim.Particles;
    using System;

    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void TestDriftMethod()
        {
            // Create new phonon
            Phonon p = new Phonon(1);
            
            // Get phonon starting x and y value, speed, and amount of time phonon moves for
            p.GetCoords(out double startingX, out double startingY);
            double phononSpeed = p.Speed;
            double t = 5;

            // Set phonon to have random direction, and save the direction values as xDir and yDir
            p.SetRandomDirection(0, 1);
            p.GetDirection(out double xDir, out double yDir);

            // Calculates the projected values
            double projectedValueX = startingX + (xDir * phononSpeed * t);
            double projectedValueY = startingY + (yDir * phononSpeed * t);

            // Move phonon and get new coordinates after phonon has moved
            p.Drift(t);
            p.GetCoords(out double driftX, out double driftY);

            // Test that the projected coord values equals the values after drift method is called
            Assert.AreEqual(driftX, projectedValueX);
            Assert.AreEqual(driftY, projectedValueY);

        }

    }
}
