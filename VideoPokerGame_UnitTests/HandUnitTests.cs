using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VideoPokerGameApp.Models;

namespace VideoPokerGame_UnitTests
{
    [TestClass]
    public class HandUnitTests
    {
        private Hand hand;
        private static readonly int NUMBER_OF_CARDS_IN_HAND = 5;

        [TestInitialize]
        public void TestInitialize()
        {
            this.hand = new Hand(NUMBER_OF_CARDS_IN_HAND);
        }

        [TestMethod]
        public void SetCardByPosition_GivenPositionNumberTwoSetValueOfTen_ExpectedResult_ValueIsSet_TestMethod()
        {
            Assert.AreEqual(0, this.hand.GetCardByPosition(1));
            Assert.AreEqual(0, this.hand.GetCardByPosition(2));
            Assert.AreEqual(0, this.hand.GetCardByPosition(3));
            Assert.AreEqual(0, this.hand.GetCardByPosition(4));
            Assert.AreEqual(0, this.hand.GetCardByPosition(5));
            this.hand.SetCardByPosition(2, 10);
            Assert.AreEqual(0, this.hand.GetCardByPosition(1));
            Assert.AreEqual(10, this.hand.GetCardByPosition(2));
            Assert.AreEqual(0, this.hand.GetCardByPosition(3));
            Assert.AreEqual(0, this.hand.GetCardByPosition(4));
            Assert.AreEqual(0, this.hand.GetCardByPosition(5));
        }

        [TestMethod]
        public void SetCardByPosition_SetValueForAllCards_ExpectedResult_ValuesAreSet_TestMethod()
        {
            Assert.AreEqual(0, this.hand.GetCardByPosition(1));
            Assert.AreEqual(0, this.hand.GetCardByPosition(2));
            Assert.AreEqual(0, this.hand.GetCardByPosition(3));
            Assert.AreEqual(0, this.hand.GetCardByPosition(4));
            Assert.AreEqual(0, this.hand.GetCardByPosition(5));
            this.hand.SetCardByPosition(1, 1);
            this.hand.SetCardByPosition(2, 6);
            this.hand.SetCardByPosition(3, 8);
            this.hand.SetCardByPosition(4, 12);
            this.hand.SetCardByPosition(5, 2);
            Assert.AreEqual(1, this.hand.GetCardByPosition(1));
            Assert.AreEqual(6, this.hand.GetCardByPosition(2));
            Assert.AreEqual(8, this.hand.GetCardByPosition(3));
            Assert.AreEqual(12, this.hand.GetCardByPosition(4));
            Assert.AreEqual(2, this.hand.GetCardByPosition(5));
        }

        [TestMethod]
        public void SetCardByPosition_SetAndThenResetValueForAllCards_ExpectedResult_ValuesAreReset_TestMethod()
        {
            this.hand.SetCardByPosition(1, 11);
            this.hand.SetCardByPosition(2, 16);
            this.hand.SetCardByPosition(3, 24);
            this.hand.SetCardByPosition(4, 40);
            this.hand.SetCardByPosition(5, 3);
            this.hand.SetCardByPosition(1, 1);
            this.hand.SetCardByPosition(2, 6);
            this.hand.SetCardByPosition(3, 8);
            this.hand.SetCardByPosition(4, 12);
            this.hand.SetCardByPosition(5, 2);
            Assert.AreEqual(1, this.hand.GetCardByPosition(1));
            Assert.AreEqual(6, this.hand.GetCardByPosition(2));
            Assert.AreEqual(8, this.hand.GetCardByPosition(3));
            Assert.AreEqual(12, this.hand.GetCardByPosition(4));
            Assert.AreEqual(2, this.hand.GetCardByPosition(5));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SetCardByPosition_GivenPositionLowerThanOne_ExpectedResult_ThrowsIndexOutOfRangeException_TestMethod()
        {
            this.hand.SetCardByPosition(1, 10);
            this.hand.SetCardByPosition(0, 11);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SetCardByPosition_GivenPositionHigherThanFive_ExpectedResult_ThrowsIndexOutOfRangeException_TestMethod()
        {
            this.hand.SetCardByPosition(5, 10);
            this.hand.SetCardByPosition(6, 11);
        }
    }
}
