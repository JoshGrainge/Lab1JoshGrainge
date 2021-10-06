using Microsoft.VisualStudio.TestTools.UnitTesting;
using Psim.ModelComponents;
using Psim.Particles;
using System.Collections.Generic;

namespace Geometry2DUnitTests
{

    [TestClass]
    public class Lab3Tests
    {
        [TestMethod]
        public void MergeIncomingPhononsTest()
        {
            Cell cell = new Cell(10,10);

            // Add 5 phonons
            for (int i = 0; i < 5; i++)
                cell.AddPhonon(new Phonon(1));

            // Add 7 incoming phonons
            for (int i = 0; i < 7; i++)
                cell.AddIncPhonon(new Phonon(1));

            // Add existing and incoming phonons together (5+7) for a sum of 12
            cell.MergeIncPhonons();

            Assert.AreEqual(cell.Phonons.Count, 12);
        }

        public void TopSurfaceRedirectTest()
        {

        }
    }
}
