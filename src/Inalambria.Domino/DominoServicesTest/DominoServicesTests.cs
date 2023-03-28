using Inalambria.Domino.ApplicationServices.Ordering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace DominoServicesTest
{
    [TestClass]
    public class DominoServicesTests
    {

        private IDominoServices _dominoServices;

        [TestInitialize]
        public void Initialize()
        {
            _dominoServices = new DominoServices();
        }
        [TestMethod]
        public void OrderDomino_GivenNull_ReturnsEmptyList()
        {
            // Arrange
            List<string> fichas = null;

            // Act
            var result = _dominoServices.OrderDomino(fichas);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void OrderDomino_GivenLessThanTwo_ReturnsEmptyList()
        {
            // Arrange
            List<string> fichas = new List<string>() { "[1|2]" };

            // Act
            var result = _dominoServices.OrderDomino(fichas);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void OrderDomino_Doubles()
        {
            // Arrange
            var inputList = new List<string> {  "[1|2]", "[2|3]", "[4|4]", "[4|3]", "[4|1]", "[1|1]" };
            var expectedOrder = new List<string> { "[1|1]", "[1|2]", "[2|3]", "[3|4]", "[4|4]", "[4|1]" };

            // Act
            var result = _dominoServices.OrderDomino(inputList);

            // Assert
            CollectionAssert.AreEqual(expectedOrder, result);
        }
        [TestMethod]
        public void OrderDomino_Valid()
        {
            // Arrange
            var inputList = new List<string> { "[1|2]", "[4|3]", "[4|1]", "[2|3]" };
            var expectedOrder = new List<string> { "[1|2]", "[2|3]", "[3|4]","[4|1]" };

            // Act
            var result = _dominoServices.OrderDomino(inputList);

            // Assert
            CollectionAssert.AreEqual(expectedOrder, result);
        }


        [TestMethod]
        public void OrderDomino_invalid()
        {
            // Arrange
            var inputList = new List<string> { "[1|2]", "[2|3]", "[4|6]", "[4|1]", "[1|1]" };
            

            // Act
            var result = _dominoServices.OrderDomino(inputList);

            // Assert
            Assert.AreEqual(0, result.Count);
        }
    }
}