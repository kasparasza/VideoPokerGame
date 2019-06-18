using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoPokerGameApp.Models;

namespace VideoPokerGame_UnitTests
{
    [TestClass]
    public class EvaluatorUnitTest
    {
        private static readonly int NUMBER_OF_CARDS_IN_HAND = 5;
        private Hand hand;
        private ICardMapper cardMapper;
        private IEvaluator evaluator;

        [TestInitialize]
        public void TestInitialize()
        {
            this.cardMapper = new CardMapper();
            this.evaluator = new Evaluator(this.cardMapper);
            this.hand = new Hand(NUMBER_OF_CARDS_IN_HAND);
            this.hand.SetCardByPosition(1, 1);
            this.hand.SetCardByPosition(2, 8);
            this.hand.SetCardByPosition(3, 17);
            this.hand.SetCardByPosition(4, 29);
            this.hand.SetCardByPosition(5, 44);
        }

        [TestMethod]
        public void EvaluateHand_RoyalFlush_ExpectedResult_RoyalFlush_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 9);
            this.hand.SetCardByPosition(2, 10);
            this.hand.SetCardByPosition(3, 11);
            this.hand.SetCardByPosition(4, 12);
            this.hand.SetCardByPosition(5, 13);
            Assert.AreEqual(HandCombination.RoyalFlush, evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_StraightFlushNineToKing_ExpectedResult_StraightFlush_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 12);
            this.hand.SetCardByPosition(2, 11);
            this.hand.SetCardByPosition(3, 10);
            this.hand.SetCardByPosition(4, 9);
            this.hand.SetCardByPosition(5, 8);
            Assert.AreEqual(HandCombination.StraightFlush, evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_StraightFlushThreeToSeven_ExpectedResult_StraightFlush_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 5);
            this.hand.SetCardByPosition(2, 3);
            this.hand.SetCardByPosition(3, 6);
            this.hand.SetCardByPosition(4, 2);
            this.hand.SetCardByPosition(5, 4);
            Assert.AreEqual(HandCombination.StraightFlush, evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_FlushAllOfSameSuitNotConsecutive_ExpectedResult_Flush_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 5 + 13);
            this.hand.SetCardByPosition(2, 1 + 13);
            this.hand.SetCardByPosition(3, 8 + 13);
            this.hand.SetCardByPosition(4, 10 + 13);
            this.hand.SetCardByPosition(5, 11 + 13);
            Assert.AreEqual(HandCombination.Flush, evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_StraightNineToKing_ExpectedResult_Straight_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 12);
            this.hand.SetCardByPosition(2, 11);
            this.hand.SetCardByPosition(3, 10);
            this.hand.SetCardByPosition(4, 9 + 13);
            this.hand.SetCardByPosition(5, 8);
            Assert.AreEqual(HandCombination.Straight, evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_FlushJackToAceAndTwoAllOfSameSuit_ExpectedResult_Flush_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 13);
            this.hand.SetCardByPosition(2, 12);
            this.hand.SetCardByPosition(3, 11);
            this.hand.SetCardByPosition(4, 10);
            this.hand.SetCardByPosition(5, 2);
            Assert.AreEqual(HandCombination.Flush, evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_StraightTenToAce_ExpectedResult_Straight_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 9);
            this.hand.SetCardByPosition(2, 10);
            this.hand.SetCardByPosition(3, 11);
            this.hand.SetCardByPosition(4, 12);
            this.hand.SetCardByPosition(5, 13 + 13);
            Assert.AreEqual(HandCombination.Straight, this.evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_StraightThreeToSeven_ExpectedResult_Straight_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 2);
            this.hand.SetCardByPosition(2, 3);
            this.hand.SetCardByPosition(3, 4 + 13);
            this.hand.SetCardByPosition(4, 5 + 13 * 2);
            this.hand.SetCardByPosition(5, 6);
            Assert.AreEqual(HandCombination.Straight, this.evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_ThreeToEightWithGap_ExpectedResult_None_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 2);
            this.hand.SetCardByPosition(2, 3 + 13);
            this.hand.SetCardByPosition(3, 4);
            this.hand.SetCardByPosition(4, 6);
            this.hand.SetCardByPosition(5, 7);
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_FlushThreeToEightWithGapAllOfSameSuit_ExpectedResult_Flush_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 2);
            this.hand.SetCardByPosition(2, 3);
            this.hand.SetCardByPosition(3, 4);
            this.hand.SetCardByPosition(4, 6);
            this.hand.SetCardByPosition(5, 7);
            Assert.AreEqual(HandCombination.Flush, this.evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_TwoToFourPlusKingAndAce_ExpectedResult_None_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 1);
            this.hand.SetCardByPosition(2, 2);
            this.hand.SetCardByPosition(3, 3);
            this.hand.SetCardByPosition(4, 12);
            this.hand.SetCardByPosition(5, 13 * 3);
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_FourOfAKindFourFives_ExpectedResult_FourOfAKind_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 4);
            this.hand.SetCardByPosition(2, 4 + 13);
            this.hand.SetCardByPosition(3, 4 + 13 * 3);
            this.hand.SetCardByPosition(4, 8);
            this.hand.SetCardByPosition(5, 4 + 13 * 4);
            Assert.AreEqual(HandCombination.FourOfAKind, this.evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_FourOfAKindFourAces_ExpectedResult_FourOfAKind_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 4);
            this.hand.SetCardByPosition(2, 13);
            this.hand.SetCardByPosition(3, 13 * 3);
            this.hand.SetCardByPosition(4, 13 * 2);
            this.hand.SetCardByPosition(5, 13 * 4);
            Assert.AreEqual(HandCombination.FourOfAKind, this.evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_FullHouseTwoAcesAndThreeQueens_ExpectedResult_FullHouse_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 11);
            this.hand.SetCardByPosition(2, 11 + 13);
            this.hand.SetCardByPosition(3, 11 + 13 * 2);
            this.hand.SetCardByPosition(4, 13 * 2);
            this.hand.SetCardByPosition(5, 13 * 4);
            Assert.AreEqual(HandCombination.FullHouse, this.evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_FullHouseTwoTwosAndThreeFours_ExpectedResult_FullHouse_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 3);
            this.hand.SetCardByPosition(2, 1);
            this.hand.SetCardByPosition(3, 3 + 13 * 3);
            this.hand.SetCardByPosition(4, 3 + 13 * 2);
            this.hand.SetCardByPosition(5, 1 + 13);
            Assert.AreEqual(HandCombination.FullHouse, this.evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_ThreeOfAKindThreeAces_ExpectedResult_ThreeOfAKind_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 1);
            this.hand.SetCardByPosition(2, 8);
            this.hand.SetCardByPosition(3, 13 * 3);
            this.hand.SetCardByPosition(4, 13 * 2);
            this.hand.SetCardByPosition(5, 13 * 4);
            Assert.AreEqual(HandCombination.ThreeOfAKind, this.evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_ThreeOfAKindThreeTensPlusJackAndQueenOfSameSuit_ExpectedResult_ThreeOfAKind_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 9);
            this.hand.SetCardByPosition(2, 9 + 13);
            this.hand.SetCardByPosition(3, 10);
            this.hand.SetCardByPosition(4, 9 + 13 * 2);
            this.hand.SetCardByPosition(5, 11);
            Assert.AreEqual(HandCombination.ThreeOfAKind, this.evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_TwoPairPairOfTwosAndPairOfTens_ExpectedResult_TwoPair_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 9);
            this.hand.SetCardByPosition(2, 9 + 13);
            this.hand.SetCardByPosition(3, 1);
            this.hand.SetCardByPosition(4, 1 + 13 * 2);
            this.hand.SetCardByPosition(5, 10);
            Assert.AreEqual(HandCombination.TwoPairs, this.evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_TwoPairPairOfAcesAndPairOfKingsPlusQueen_ExpectedResult_TwoPair_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 13);
            this.hand.SetCardByPosition(2, 12);
            this.hand.SetCardByPosition(3, 11);
            this.hand.SetCardByPosition(4, 13 * 3);
            this.hand.SetCardByPosition(5, 12 + 13 * 2);
            Assert.AreEqual(HandCombination.TwoPairs, this.evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_TestPairOfTens_ExpectedResult_None_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 1);
            this.hand.SetCardByPosition(2, 9);
            this.hand.SetCardByPosition(3, 9 + 13);
            this.hand.SetCardByPosition(4, 3 + 13);
            this.hand.SetCardByPosition(5, 5 + 13 * 2);
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_TestPairOfTensPlusJackToKing_ExpectedResult_None_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 10);
            this.hand.SetCardByPosition(2, 9);
            this.hand.SetCardByPosition(3, 9 + 13);
            this.hand.SetCardByPosition(4, 11);
            this.hand.SetCardByPosition(5, 12);
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_TestPairOfJacks_ExpectedResult_JacksOrBetter_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 7);
            this.hand.SetCardByPosition(2, 10);
            this.hand.SetCardByPosition(3, 10 + 13);
            this.hand.SetCardByPosition(4, 1 + 13);
            this.hand.SetCardByPosition(5, 2);
            Assert.AreEqual(HandCombination.JacksOrBetter, this.evaluator.EvaluateHand(this.hand));
        }

        [TestMethod]
        public void EvaluateHand_TestPairOfJacksPlusQueenToAce_ExpectedResult_JacksOrBetter_TestMethod()
        {
            Assert.AreEqual(HandCombination.None, this.evaluator.EvaluateHand(this.hand));
            this.hand.SetCardByPosition(1, 11);
            this.hand.SetCardByPosition(2, 10);
            this.hand.SetCardByPosition(3, 10 + 13);
            this.hand.SetCardByPosition(4, 12);
            this.hand.SetCardByPosition(5, 13);
            Assert.AreEqual(HandCombination.JacksOrBetter, this.evaluator.EvaluateHand(this.hand));
        }
    }
}
