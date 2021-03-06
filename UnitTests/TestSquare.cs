using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.BattleShip.Model;

namespace UnitTests
{
    [TestClass]
    public class TestSquare
    {
        [TestMethod]
        public void ConstructorCreatesSquareWithGivenCoordinates()
        {
            var s = new Square(1, 5);
            Assert.AreEqual(1, s.Row);
            Assert.AreEqual(5, s.Column);
        }
    }
}
