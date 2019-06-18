using System;
using System.Collections.Generic;
using System.Text;

namespace VideoPokerGameApp.Models
{
    public struct CombinationAndPayout
    {
        public string name;
        public int payout;

        public CombinationAndPayout(string nameOfCombination, int payoutForCombination)
        {
            name = nameOfCombination;
            payout = payoutForCombination;
        }
    }
}
