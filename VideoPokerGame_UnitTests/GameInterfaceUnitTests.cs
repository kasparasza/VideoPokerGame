using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using VideoPokerGameApp.UserInterface;
using System.Linq;

namespace VideoPokerGame_UnitTests
{
    [TestClass]
    public class GameInterfaceUnitTests
    {
        private static readonly int NUMBER_OF_CARDS_IN_HAND = 5;
        private IGameInterface gameInterface;
        private readonly string emptyInput = "";
        private readonly string oneNumberWithinBouds = "2";
        private readonly string oneNumberWithinBoudsWithSpaceChars = "  2 ";
        private readonly string threeNumbersWithinBouds = "2 1 5";
        private readonly string threeNumbersWithinBoudsWithExtraSpaceChars = " 2   1 5 ";
        private readonly string fiveNumbersWithinBouds = "2 1 5 3 4";
        private readonly string sixNumbersWithinBouds = "2 1 5 3 4 5";
        private readonly string oneNumberAboveBounds = "6";
        private readonly string oneNumberBelowBounds = "-1";
        private readonly string oneInputNotInt = "2.3";
        private readonly string oneInputNotANumber = "z";
        private readonly string threeNumbersWhereOneIsOutsideBouds = "2 0 5";
        private readonly string threeInputsWhereOneIsIntWithinBounds = "2 0 x";
        private readonly string threeInputsWhereOneIsNotInt = "2.3 3 1";
        private readonly string fiveInputsAllNotANumber = "% z ; a ^";


        [TestInitialize]
        public void TestInitialize()
        {
            this.gameInterface = new GameInterface(NUMBER_OF_CARDS_IN_HAND);
        }

        [TestMethod]
        public void GetCardsToBeDiscarded_TestEmptyInput_ExpectedResult_EmptyCollection_TestMethod()
        {
            TextReader mockReader = new StringReader(emptyInput);
            string expectedResult = "";
            Assert.AreEqual(expectedResult, string.Join(" ", this.gameInterface.GetCardsToBeDiscarded(mockReader).ToArray()));
        }

        [TestMethod]
        public void GetCardsToBeDiscarded_TestOneNumberWithinBouds_ExpectedResult_CollectionWithLenghtOne_TestMethod()
        {
            TextReader mockReader = new StringReader(oneNumberWithinBouds);
            string expectedResult = "2";
            Assert.AreEqual(expectedResult, string.Join(" ", this.gameInterface.GetCardsToBeDiscarded(mockReader).ToArray()));
        }

        [TestMethod]
        public void GetCardsToBeDiscarded_TestOneNumberWithinBoudsWithSpaceChars_ExpectedResult_CollectionWithLenghtOne_TestMethod()
        {
            TextReader mockReader = new StringReader(oneNumberWithinBoudsWithSpaceChars);
            string expectedResult = "2";
            Assert.AreEqual(expectedResult, string.Join(" ", this.gameInterface.GetCardsToBeDiscarded(mockReader).ToArray()));
        }

        [TestMethod]
        public void GetCardsToBeDiscarded_TestThreeNumbersWithinBouds_ExpectedResult_CollectionWithLenghtThree_TestMethod()
        {
            TextReader mockReader = new StringReader(threeNumbersWithinBouds);
            string expectedResult = "2 1 5";
            Assert.AreEqual(expectedResult, string.Join(" ", this.gameInterface.GetCardsToBeDiscarded(mockReader).ToArray()));
        }

        [TestMethod]
        public void GetCardsToBeDiscarded_TestThreeNumbersWithinBoudsWithExtraSpaceChars_ExpectedResult_CollectionWithLenghtThree_TestMethod()
        {
            TextReader mockReader = new StringReader(threeNumbersWithinBoudsWithExtraSpaceChars);
            string expectedResult = "2 1 5";
            Assert.AreEqual(expectedResult, string.Join(" ", this.gameInterface.GetCardsToBeDiscarded(mockReader).ToArray()));
        }

        [TestMethod]
        public void GetCardsToBeDiscarded_TestFiveNumbersWithinBouds_ExpectedResult_CollectionWithLenghtFive_TestMethod()
        {
            TextReader mockReader = new StringReader(fiveNumbersWithinBouds);
            string expectedResult = "2 1 5 3 4";
            Assert.AreEqual(expectedResult, string.Join(" ", this.gameInterface.GetCardsToBeDiscarded(mockReader).ToArray()));
        }

        [TestMethod]
        public void GetCardsToBeDiscarded_TestSixNumbersWithinBouds_ExpectedResult_CollectionWithLenghtFive_TestMethod()
        {
            TextReader mockReader = new StringReader(sixNumbersWithinBouds);
            string expectedResult = "2 1 5 3 4";
            Assert.AreEqual(expectedResult, string.Join(" ", this.gameInterface.GetCardsToBeDiscarded(mockReader).ToArray()));
        }

        [TestMethod]
        public void GetCardsToBeDiscarded_TestOneNumberAboveBounds_ExpectedResult_EmptyCollection_TestMethod()
        {
            TextReader mockReader = new StringReader(oneNumberAboveBounds);
            string expectedResult = "";
            Assert.AreEqual(expectedResult, string.Join(" ", this.gameInterface.GetCardsToBeDiscarded(mockReader).ToArray()));
        }

        [TestMethod]
        public void GetCardsToBeDiscarded_TestOneNumberBelowBounds_ExpectedResult_EmptyCollection_TestMethod()
        {
            TextReader mockReader = new StringReader(oneNumberBelowBounds);
            string expectedResult = "";
            Assert.AreEqual(expectedResult, string.Join(" ", this.gameInterface.GetCardsToBeDiscarded(mockReader).ToArray()));
        }

        [TestMethod]
        public void GetCardsToBeDiscarded_TestOneInputNotInt_ExpectedResult_EmptyCollection_TestMethod()
        {
            TextReader mockReader = new StringReader(oneInputNotInt);
            string expectedResult = "";
            Assert.AreEqual(expectedResult, string.Join(" ", this.gameInterface.GetCardsToBeDiscarded(mockReader).ToArray()));
        }

        [TestMethod]
        public void GetCardsToBeDiscarded_TestOneInputNotANumber_ExpectedResult_EmptyCollection_TestMethod()
        {
            TextReader mockReader = new StringReader(oneInputNotANumber);
            string expectedResult = "";
            Assert.AreEqual(expectedResult, string.Join(" ", this.gameInterface.GetCardsToBeDiscarded(mockReader).ToArray()));
        }

        [TestMethod]
        public void GetCardsToBeDiscarded_TestThreeNumbersWhereOneIsOutsideBouds_ExpectedResult_CollectionWithLenghtTwo_TestMethod()
        {
            TextReader mockReader = new StringReader(threeNumbersWhereOneIsOutsideBouds);
            string expectedResult = "2 5";
            Assert.AreEqual(expectedResult, string.Join(" ", this.gameInterface.GetCardsToBeDiscarded(mockReader).ToArray()));
        }

        [TestMethod]
        public void GetCardsToBeDiscarded_TestThreeInputsWhereOneIsIntWithinBounds_ExpectedResult_CollectionWithLenghtOne_TestMethod()
        {
            TextReader mockReader = new StringReader(threeInputsWhereOneIsIntWithinBounds);
            string expectedResult = "2";
            Assert.AreEqual(expectedResult, string.Join(" ", this.gameInterface.GetCardsToBeDiscarded(mockReader).ToArray()));
        }

        [TestMethod]
        public void GetCardsToBeDiscarded_TestThreeInputsWhereOneIsNotInt_ExpectedResult_CollectionWithLenghtTwo_TestMethod()
        {
            TextReader mockReader = new StringReader(threeInputsWhereOneIsNotInt);
            string expectedResult = "3 1";
            Assert.AreEqual(expectedResult, string.Join(" ", this.gameInterface.GetCardsToBeDiscarded(mockReader).ToArray()));
        }

        [TestMethod]
        public void GetCardsToBeDiscarded_TestFiveInputsAllNotANumber_ExpectedResult_EmptyCollection_TestMethod()
        {
            TextReader mockReader = new StringReader(fiveInputsAllNotANumber);
            string expectedResult = "";
            Assert.AreEqual(expectedResult, string.Join(" ", this.gameInterface.GetCardsToBeDiscarded(mockReader).ToArray()));
        }
    }
}
