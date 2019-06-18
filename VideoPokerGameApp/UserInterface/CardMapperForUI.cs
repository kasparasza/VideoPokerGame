using System;
using System.Collections.Generic;
using System.Text;
using VideoPokerGameApp.Models;
using VideoPokerGameApp.Models.Enums;

namespace VideoPokerGameApp.UserInterface
{
    public class CardMapperForUI : ICardMapperForUI
    {
        public string GetCardForUI(CardBusinessLogic card)
        {
            return $"[{(CardRankName)card.Rank} of {card.Suit}]";
        }
    }
}
