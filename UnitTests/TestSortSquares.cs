using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.BattleShip.Model;

namespace Vsite.BattleShip.UnitTests
{
    [TestClass]
    public class TestSortSquares
    {
        [TestMethod]
        public void ConstructorCreateCollectionOfSquaresSortedByColumnForHorizontallyPlacedSquares()
        {
            SortedSquares coll = new SortedSquares(new Square[] { new Square(3, 4), new Square(3, 3), new Square(3, 5) });
            Assert.AreEqual(3, coll.Count);
            Assert.AreEqual(new Square(3, 3), coll[0]);
            Assert.AreEqual(new Square(3, 4), coll[1]);
            Assert.AreEqual(new Square(3, 5), coll[2]);
        }

        [TestMethod]
        public void ConstructorCreateCollectionOfSquaresSortedByColumnForVerticallyPlacedSquares()
        {
            SortedSquares coll = new SortedSquares(new Square[] { new Square(3, 4), new Square(2, 4), new Square(4, 4) });
            Assert.AreEqual(3, coll.Count);
            Assert.AreEqual(new Square(2, 4), coll[0]);
            Assert.AreEqual(new Square(3, 4), coll[1]);
            Assert.AreEqual(new Square(4, 4), coll[2]);
        }

        [TestMethod]
        public void AfterAddMethodIsInvokedSquaresAreSortedByColumnsForHorizontallyPlacedSquares()
        {
            SortedSquares coll = new SortedSquares(new Square[] { new Square(3, 4), new Square(3, 5) });
            Assert.AreEqual(2, coll.Count);
            coll.Add(new Square(3, 3));
            Assert.AreEqual(3, coll.Count);
            Assert.AreEqual(new Square(3, 3), coll[0]);
            Assert.AreEqual(new Square(3, 4), coll[1]);
            Assert.AreEqual(new Square(3, 5), coll[2]);
        }

        [TestMethod]
        public void AfterAddMethodIsInvokedSquaresAreSortedByColumnsForVerticallyPlacedSquares()
        {
            SortedSquares coll = new SortedSquares(new Square[] { new Square(3, 4), new Square(4, 4) });
            Assert.AreEqual(2, coll.Count);
            coll.Add(new Square(2, 4));
            Assert.AreEqual(3, coll.Count);
            Assert.AreEqual(new Square(2, 4), coll[0]);
            Assert.AreEqual(new Square(3, 4), coll[1]);
            Assert.AreEqual(new Square(4, 4), coll[2]);
        }
    }
}
