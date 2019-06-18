using System;
using System.Collections.Generic;
using System.Text;

namespace VideoPokerGameApp.Models
{
    public class Hand
    {
        private readonly int[] hand;
        private readonly int numberOfCards;

        public Hand(int numberOfCards)
        {
            this.numberOfCards = numberOfCards;
            this.hand = new int[numberOfCards];
        }

        public void SetCardByPosition(int cardPosition, int cardValue)
        {
            this.hand[cardPosition - 1] = cardValue;
        }

        public int GetCardByPosition(int cardPosition)
        {
            return this.hand[cardPosition - 1];
        }

        public int[] GetAllCards()
        {
            return this.hand;
        }
    }
}
