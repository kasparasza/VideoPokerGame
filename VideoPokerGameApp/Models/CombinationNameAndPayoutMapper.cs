using System;
using System.Collections.Generic;
using System.Text;

namespace VideoPokerGameApp.Models
{
    public class CombinationNameAndPayoutMapper
    {
        public CombinationAndPayout GetCombinationNameAndPayout(HandCombination combination)
        {
            CombinationAndPayout result;
            switch (combination)
            {
                case HandCombination.JacksOrBetter:
                    result.name = "jacks or better";
                    result.payout = 1;
                    break;
                case HandCombination.TwoPairs:
                    result.name = "two pairs";
                    result.payout = 2;
                    break;
                case HandCombination.ThreeOfAKind:
                    result.name = "three of a kind";
                    result.payout = 3;
                    break;
                case HandCombination.Straight:
                    result.name = "straight";
                    result.payout = 4;
                    break;
                case HandCombination.Flush:
                    result.name = "flush";
                    result.payout = 6;
                    break;
                case HandCombination.FullHouse:
                    result.name = "full house";
                    result.payout = 9;
                    break;
                case HandCombination.FourOfAKind:
                    result.name = "four of a kind";
                    result.payout = 25;
                    break;
                case HandCombination.StraightFlush:
                    result.name = "straight flush";
                    result.payout = 50;
                    break;
                case HandCombination.RoyalFlush:
                    result.name = "royal flush";
                    result.payout = 800;
                    break;
                default:
                    result.name = "no win";
                    result.payout = 0;
                    break;
            }
            return result;
        }
    }
}
