using System;
using System.Collections.Generic;
using System.Text;
using VideoPokerGameApp.Models.Interfaces;

namespace VideoPokerGameApp.Models
{
    public class CardDealer : ICardDealer
    {
        private readonly Stack<int> shuffeledDeck;
        private readonly int cardsInDeck;
        private readonly ICardShuffler shuffler;

        public CardDealer(int cardsInDeck, ICardShuffler shuffler)
        {
            this.cardsInDeck = cardsInDeck;
            int[] sortedDeck = GetSortedDeck(cardsInDeck);
            this.shuffler = shuffler;
            this.shuffeledDeck = shuffler.ShuffleCards(sortedDeck);
        }

        private int[] GetSortedDeck(int cardsNumber)
        {
            int[] cards = new int[cardsNumber];

            for (int i = 0; i < cardsNumber; i++)
            {
                cards[i] = i + 1;
            }
            return cards;
        }

        public int GetNextCardFromDeck()
        {
            return this.shuffeledDeck.Pop();
        }
    }
}
