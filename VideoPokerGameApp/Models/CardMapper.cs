using System;
using System.Collections.Generic;
using System.Text;
using VideoPokerGameApp.Models.Enums;

namespace VideoPokerGameApp.Models
{
    public class CardMapper : ICardMapper
    {
        public CardBusinessLogic MapCard(int card)
        {
            int rank = GetRank(card);
            int suitNumber = GetSuitNumber(card);
            CardSuit suit;
            
            switch (suitNumber)
            {
                case 0:
                    suit = CardSuit.Clubs;
                    break;
                case 1:
                    suit = CardSuit.Diamonds;
                    break;
                case 2:
                    suit = CardSuit.Hearts;
                    break;
                default:
                    suit = CardSuit.Spades;
                    break;
            }

            return new CardBusinessLogic
            {
                Suit = suit,
                Rank = rank
            };
        }

        private int GetSuitNumber(int card)
        {
            return (card - 1) / 13;
        }

        private int GetRank(int card)
        {
            int suit = GetSuitNumber(card);
            return card - suit * 13;
        }

    }
}
