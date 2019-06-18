using System;
using System.Collections.Generic;
using System.Text;

namespace VideoPokerGameApp.Models.Interfaces
{
    public interface ICardShuffler
    {
        Stack<int> ShuffleCards(int[] cards);
    }
}
