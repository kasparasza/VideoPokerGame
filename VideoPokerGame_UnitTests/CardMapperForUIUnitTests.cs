using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoPokerGameApp.Models;
using VideoPokerGameApp.Models.Enums;
using VideoPokerGameApp.UserInterface;

namespace VideoPokerGame_UnitTests
{
    [TestClass]
    public class CardMapperForUIUnitTests
    {
        private CardMapperForUI uiMapper; 
        private CardBusinessLogic twoOfClubs;
        private CardBusinessLogic tenOfClubs;
        private CardBusinessLogic jackOfDiamonds;
        private CardBusinessLogic fiveOfDiamonds;
        private CardBusinessLogic kingOfHearts;
        private CardBusinessLogic aceOfHearts;
        private CardBusinessLogic eightOfSpades;
        private CardBusinessLogic sevenOfSpades;
        private readonly string twoOfClubsForUi = $"[{CardRankName.Two} of {CardSuit.Clubs}]";
        private readonly string tenOfClubsForUi = $"[{CardRankName.Ten} of {CardSuit.Clubs}]";
        private readonly string jackOfDiamondsForUi = $"[{CardRankName.Jack} of {CardSuit.Diamonds}]";
        private readonly string fiveOfDiamondsForUi = $"[{CardRankName.Five} of {CardSuit.Diamonds}]";
        private readonly string kingOfHeartsForUi = $"[{CardRankName.King} of {CardSuit.Hearts}]";
        private readonly string aceOfHeartsForUi = $"[{CardRankName.Ace} of {CardSuit.Hearts}]";
        private readonly string eightOfSpadesForUi = $"[{CardRankName.Eight} of {CardSuit.Spades}]";
        private readonly string sevenOfSpadesForUi = $"[{CardRankName.Seven} of {CardSuit.Spades}]";

        [TestInitialize]
        public void TestInitialize()
        {
            this.uiMapper = new CardMapperForUI();

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
            jackOfDiamonds = new CardBusinessLogic
            {
                Suit = VideoPokerGameApp.Models.Enums.CardSuit.Diamonds,
                Rank = 10
            };
            fiveOfDiamonds = new CardBusinessLogic
            {
                Suit = VideoPokerGameApp.Models.Enums.CardSuit.Diamonds,
                Rank = 4
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
            eightOfSpades = new CardBusinessLogic
            {
                Suit = VideoPokerGameApp.Models.Enums.CardSuit.Spades,
                Rank = 7
            };
            sevenOfSpades = new CardBusinessLogic
            {
                Suit = VideoPokerGameApp.Models.Enums.CardSuit.Spades,
                Rank = 6
            };
        }

        [TestMethod]
        public void GetCardForUI_TestTwoCasesPerEachSuit_ExpectedResult_CorrectStringOutput_TestMethod()
        {
            Assert.AreEqual(twoOfClubsForUi, uiMapper.GetCardForUI(twoOfClubs));
            Assert.AreEqual(tenOfClubsForUi, uiMapper.GetCardForUI(tenOfClubs));
            Assert.AreEqual(jackOfDiamondsForUi, uiMapper.GetCardForUI(jackOfDiamonds));
            Assert.AreEqual(fiveOfDiamondsForUi, uiMapper.GetCardForUI(fiveOfDiamonds));
            Assert.AreEqual(kingOfHeartsForUi, uiMapper.GetCardForUI(kingOfHearts));
            Assert.AreEqual(aceOfHeartsForUi, uiMapper.GetCardForUI(aceOfHearts));
            Assert.AreEqual(eightOfSpadesForUi, uiMapper.GetCardForUI(eightOfSpades));
            Assert.AreEqual(sevenOfSpadesForUi, uiMapper.GetCardForUI(sevenOfSpades));
        }
    }
}
