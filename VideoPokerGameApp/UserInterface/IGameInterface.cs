using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using VideoPokerGameApp.Models;

namespace VideoPokerGameApp.UserInterface
{
    public interface IGameInterface
    {
        void DisplayInitialInformation();
        void DisplayCards(string[] cards);
        IEnumerable<int> GetCardsToBeDiscarded(TextReader reader);
        void DisplayInfoAboutCardsDiscarded(IEnumerable<int> cardsDiscarded);
        void DisplayGameResult(CombinationAndPayout result);
    }
}
