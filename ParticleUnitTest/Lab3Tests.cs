// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using Psim.ModelComponents;
// using Psim.Particles;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// 
// namespace ParticleUnitTest
// {
//     [TestClass]
//     public class Lab3Tests
//     {
//         [TestMethod]
//         public void TestPhononMerge()
//         {
//             //Cell cell = new Cell(10, 10);
// 
//             // Add 5 phonons
//             for (int i = 0; i < 5; i++)
//                 cell.AddPhonon(new Phonon(1));
// 
//             // Add 7 incoming phonons
//             for (int i = 0; i < 7; i++)
//                 cell.AddIncPhonon(new Phonon(1));
// 
//             // Add existing and incoming phonons together (5+7) for a sum of 12
//             cell.MergeIncPhonons();
// 
//             Assert.AreEqual(12, cell.Phonons.Count);
//         }
// 
//         [TestMethod]
//         public void TestEmptyPhononMerge()
//         {
//             //Cell cell = new Cell(10, 10);
// 
//             // Add 7 incoming phonons
//             for (int i = 0; i < 7; i++)
//                 cell.AddIncPhonon(new Phonon(1));
// 
//             // Add existing and incoming phonons together (5+7) for a sum of 12
//             cell.MergeIncPhonons();
// 
//             Assert.AreEqual(7, cell.Phonons.Count);
//         }
// 
//         /// <summary>
//         /// Create 2 phonons, one hits top surface and one hits bottom. Checks that logic works for both surfaces because they have similar logic
//         /// </summary>
//         [TestMethod]
//         public void TestTopAndBottomSurfacesHit()
//         {
//             Cell cell = new Cell(10, 10);
// 
//             BoundarySurface topSurface = new BoundarySurface(SurfaceLocation.top, cell);
//             BoundarySurface bottomSurface = new BoundarySurface(SurfaceLocation.bot, cell);
// 
//             Phonon topPhonon = new Phonon(1);
//             Phonon bottomPhonon = new Phonon(1);
// 
//             Random random = new Random();
// 
//             double startDirX = random.Next(0, 1);
//             double startDirY = random.Next(0, 1);
// 
//             topPhonon.SetDirection(startDirX, startDirY);
//             bottomPhonon.SetDirection(startDirX, startDirY);
// 
//             topSurface.HandlePhonon(topPhonon);
//             bottomSurface.HandlePhonon(bottomPhonon);
// 
//             // Check that the phonons new direction has flipped Y direction but original X direction after each phonon hits top or bottom surfaces
//             bool topDirectionsAreEqual = ((topPhonon.Direction.DX == startDirX) && (topPhonon.Direction.DY == -startDirY));
//             bool bottomDirectionsAreEqual = ((bottomPhonon.Direction.DX == startDirX) && (bottomPhonon.Direction.DY == -startDirY));
// 
// 
//             Assert.IsTrue(topDirectionsAreEqual && bottomDirectionsAreEqual);
// 
//         }
// 
//         /// <summary>
//         /// Create 2 phonons, one hits left surface and one hits right. Checks that logic works for both surfaces because they have similar logic
//         /// </summary>
//         [TestMethod]
//         public void TestLeftAndRightSurfacesHit()
//         {
//             Cell cell = new Cell(10, 10);
// 
//             BoundarySurface leftSurface = new BoundarySurface(SurfaceLocation.left, cell);
//             BoundarySurface rightSurface = new BoundarySurface(SurfaceLocation.right, cell);
// 
//             Phonon leftPhonon = new Phonon(1);
//             Phonon rightPhonon = new Phonon(1);
// 
//             Random random = new Random();
// 
//             double startDirX = random.Next(0, 1);
//             double startDirY = random.Next(0, 1);
// 
//             leftPhonon.SetDirection(startDirX, startDirY);
//             rightPhonon.SetDirection(startDirX, startDirY);
// 
//             leftSurface.HandlePhonon(leftPhonon);
//             rightSurface.HandlePhonon(rightPhonon);
// 
//             // Check that the phonons new direction has flipped Y direction but original X direction after each phonon hits top or bottom surfaces
//             bool leftDirectionsAreEqual = ((leftPhonon.Direction.DX == -startDirX) && (leftPhonon.Direction.DY == startDirY));
//             bool rightDirectionsAreEqual = ((rightPhonon.Direction.DX == -startDirX) && (rightPhonon.Direction.DY == startDirY));
// 
//             Assert.IsTrue(leftDirectionsAreEqual && rightDirectionsAreEqual);
// 
//         }
//     }
// }