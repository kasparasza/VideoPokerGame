using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using VideoPokerGameApp.Models;
using VideoPokerGameApp.Models.Interfaces;

namespace VideoPokerGame_UnitTests
{
    [TestClass]
    public class CardShufflerUnitTests
    {
        private int[] cardsNormalDeck;
        private int[] cardsSmallDeck;
        private static readonly int NUMBER_OF_CARDS_IN_DECK = 52;
        private static readonly int NUMBER_OF_CARDS_IN_SMALL_DECK = 5;
        private ICardShuffler shuffler;

        [TestInitialize]
        public void TestInitialize()
        {
            this.shuffler = new CardShuffler();

            this.cardsNormalDeck = new int[NUMBER_OF_CARDS_IN_DECK];
            for (int i = 0; i < cardsNormalDeck.Length; i++)
            {
                this.cardsNormalDeck[i] = i + 1;
            }

            this.cardsSmallDeck = new int[NUMBER_OF_CARDS_IN_SMALL_DECK];
            for (int i = 0; i < cardsSmallDeck.Length; i++)
            {
                this.cardsSmallDeck[i] = i + 1;
            }
        }

        [TestMethod]
        public void ShuffleCards_GivenFiftyTwoDifferentCards_ExpectedResult_AllAreUniqueAndWithinBounds_TestMethod()
        {
            Stack<int> shuffledCards = this.shuffler.ShuffleCards(this.cardsNormalDeck);
            Assert.AreEqual(shuffledCards.Max(), NUMBER_OF_CARDS_IN_DECK);
            Assert.AreEqual(shuffledCards.Min(), 1);

            ISet<int> shuffledCardsUnique = new HashSet<int>(shuffledCards);
            Assert.AreEqual(shuffledCardsUnique.Count, NUMBER_OF_CARDS_IN_DECK);
        }

        //Note: Commented out as takes significanlty longer time
        //[TestMethod]
        //public void ShuffleCards_TestRandomnesOfAlgorithm_ExpectedResult_AllOccurenciesAreSufficientlyLikely_TestMethod()
        //{
        //    Dictionary<string, int> occurencies = new Dictionary<string, int>();

        //    for (int i = 0; i < 1e7; i++)
        //    {
        //        Stack<int> shuffledCards = this.shuffler.ShuffleCards(this.cardsSmallDeck);
        //        string key = string.Join(" ", shuffledCards.ToArray());

        //        if (!occurencies.ContainsKey(key))
        //        {
        //            occurencies.Add(key, 1);
        //        }
        //        else
        //        {
        //            occurencies[key]++;
        //        }
        //    }
        //    int minCount = occurencies.Values.Min();
        //    int maxCount = occurencies.Values.Max();
        //    double ratio = (double)minCount / (double)maxCount;

        //    Assert.IsTrue(ratio >= 0.95);
        //}
    }
}
