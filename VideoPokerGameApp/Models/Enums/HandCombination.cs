using System;
using System.Collections.Generic;
using System.Text;

namespace VideoPokerGameApp.Models
{
    public enum HandCombination
    {
        None,
        JacksOrBetter,
        TwoPairs,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }
}
