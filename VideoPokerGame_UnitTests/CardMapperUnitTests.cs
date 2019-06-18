using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoPokerGameApp.Models;

namespace VideoPokerGame_UnitTests
{
    [TestClass]
    public class CardMapperUnitTests
    {
        private ICardMapper mapper;
        private CardBusinessLogic twoOfClubs;
        private CardBusinessLogic tenOfClubs;
        private CardBusinessLogic aceOfClubs;
        private CardBusinessLogic twoOfDiamonds;
        private CardBusinessLogic jackOfDiamonds;
        private CardBusinessLogic aceOfDiamonds;
        private CardBusinessLogic twoOfHearts;
        private CardBusinessLogic kingOfHearts;
        private CardBusinessLogic aceOfHearts;
        private CardBusinessLogic twoOfSpades;
        private CardBusinessLogic sevenOfSpades;
        private CardBusinessLogic aceOfSpades;

        [TestInitialize]
        public void TestInitialize()
        {
            mapper = new CardMapper();

            twoOfClubs = new CardBusinessLogic
            {
                Suit = VideoPokerGameApp.Models.Enums.CardSuit.Clubs,
                Rank = 1
            };
            tenOfClubs = new CardBusinessLogic
            {
                Suit = VideoPokerGameApp.Models.Enums.CardSuit.Clubs,
                Rank = 9
            };
            aceOfClubs = new CardBusinessLogic
            {
                Suit = VideoPokerGameApp.Models.Enums.CardSuit.Clubs,
                Rank = 13
            };
            twoOfDiamonds = new CardBusinessLogic
            {
                Suit = VideoPokerGameApp.Models.Enums.CardSuit.Diamonds,
                Rank = 1
            };
            jackOfDiamonds = new CardBusinessLogic
            {
                Suit = VideoPokerGameApp.Models.Enums.CardSuit.Diamonds,
                Rank = 10
            };
            aceOfDiamonds = new CardBusinessLogic
            {
                Suit = VideoPokerGameApp.Models.Enums.CardSuit.Diamonds,
                Rank = 13
            };
            twoOfHearts = new CardBusinessLogic
            {
                Suit = VideoPokerGameApp.Models.Enums.CardSuit.Hearts,
                Rank = 1
            };
            kingOfHearts = new CardBusinessLogic
            {
                Suit = VideoPokerGameApp.Models.Enums.CardSuit.Hearts,
                Rank = 12
            };
            aceOfHearts = new CardBusinessLogic
            {
                Suit = VideoPokerGameApp.Models.Enums.CardSuit.Hearts,
                Rank = 13
            };
            twoOfSpades = new CardBusinessLogic
            {
                Suit = VideoPokerGameApp.Models.Enums.CardSuit.Spades,
                Rank = 1
            };
            sevenOfSpades = new CardBusinessLogic
            {
                Suit = VideoPokerGameApp.Models.Enums.CardSuit.Spades,
                Rank = 6
            };
            aceOfSpades = new CardBusinessLogic
            {
                Suit = VideoPokerGameApp.Models.Enums.CardSuit.Spades,
                Rank = 13
            };
        }

        [TestMethod]
        public void MapCard_TestAllConerAndSomeInBetweenCases_ExpectedResult_CorrectMapping_TestMethod()
        {
            Assert.AreEqual(twoOfClubs, mapper.MapCard(1));
            Assert.AreEqual(tenOfClubs, mapper.MapCard(1 + 8));
            Assert.AreEqual(aceOfClubs, mapper.MapCard(1 + 12));

            Assert.AreEqual(twoOfDiamonds, mapper.MapCard(14));
            Assert.AreEqual(jackOfDiamonds, mapper.MapCard(14 + 9));
            Assert.AreEqual(aceOfDiamonds, mapper.MapCard(14 + 12));

            Assert.AreEqual(twoOfHearts, mapper.MapCard(27));
            Assert.AreEqual(kingOfHearts, mapper.MapCard(27 + 11));
            Assert.AreEqual(aceOfHearts, mapper.MapCard(27 + 12));

            Assert.AreEqual(twoOfSpades, mapper.MapCard(40));
            Assert.AreEqual(sevenOfSpades, mapper.MapCard(40 + 5));
            Assert.AreEqual(aceOfSpades, mapper.MapCard(40 + 12));
        }
    }
}
