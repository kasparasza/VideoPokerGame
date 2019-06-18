using System;
using System.Collections.Generic;
using System.Text;
using VideoPokerGameApp.Models.Interfaces;

namespace VideoPokerGameApp.Models
{
    public class CardShuffler : ICardShuffler
    {
        private readonly Random random;

        public CardShuffler()
        {
            random = new Random();
        }

        /*
         * Method utilizes Fisher–Yates algorithm
         * Source: https://bost.ocks.org/mike/algorithms/#shuffling
         */
        public Stack<int> ShuffleCards(int[] cards)
        {
            int counter = cards.Length - 1;
            while (counter > 0)
            {
                int currentCard = this.random.Next(counter + 1);
                int tempValue = cards[counter];
                cards[counter] = cards[currentCard];
                cards[currentCard] = tempValue;
                counter--;
            }

            return new Stack<int>(cards);
        }
    }
}
