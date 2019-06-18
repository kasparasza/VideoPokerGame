using System;
using System.Collections.Generic;
using System.Linq;
using VideoPokerGameApp.Models.Enums;

namespace VideoPokerGameApp.Models
{
    public class Evaluator : IEvaluator
    {
        private readonly ICardMapper mapper;

        public Evaluator(ICardMapper mapper)
        {
            this.mapper = mapper;
        }

        /*
         * Note: Sequence of tests matters.
         * test for FourOfAKind has to be before the test for IsStraight
         */
        public HandCombination EvaluateHand(Hand hand)
        {
            IEnumerable<CardBusinessLogic> cards = GetCardsBusinessLogic(hand, this.mapper);
            IDictionary<int, int> ranksCount = GetCardsRankCount(cards);

            if (IsRoyalFlush(cards))
            {
                return HandCombination.RoyalFlush;
            }

            if (IsStraigthFlush(cards))
            {
                return HandCombination.StraightFlush;
            }

            if (IsFourOfAKind(ranksCount))
            {
                return HandCombination.FourOfAKind;
            }

            if (IsFullHouse(ranksCount))
            {
                return HandCombination.FullHouse;
            }

            if (IsFlush(cards))
            {
                return HandCombination.Flush;
            }

            if (IsStraight(cards))
            {
                return HandCombination.Straight;
            }

            if (IsThreeOfAKind(ranksCount))
            {
                return HandCombination.ThreeOfAKind;
            }

            if (IsTwoPair(ranksCount))
            {
                return HandCombination.TwoPairs;
            }

            if (IsJacksOrBetter(ranksCount))
            {
                return HandCombination.JacksOrBetter;
            }

            else return HandCombination.None;

        }

        private IEnumerable<CardBusinessLogic> GetCardsBusinessLogic(Hand hand, ICardMapper mapper)
        {
            List<CardBusinessLogic> cards = new List<CardBusinessLogic>();

            foreach (int card in hand.GetAllCards())
            {
                cards.Add(mapper.MapCard(card));
            }
            return cards;
        }

        private IDictionary<int, int> GetCardsRankCount(IEnumerable<CardBusinessLogic> cards)
        {
            IDictionary<int, int> ranksCount = new Dictionary<int, int>();
            foreach (CardBusinessLogic card in cards)
            {
                if (!ranksCount.ContainsKey(card.Rank))
                {
                    ranksCount.Add(card.Rank, 1);
                }
                else
                {
                    ranksCount[card.Rank]++;
                }
            }
            return ranksCount;
        }

        private bool IsFlush(IEnumerable<CardBusinessLogic> cards)
        {
            ISet<CardSuit> suits = new HashSet<CardSuit>();
            foreach(CardBusinessLogic card in cards)
            {
                suits.Add(card.Suit);
            }
            return suits.Count == 1;
        }

        private bool IsRoyalFlush(IEnumerable<CardBusinessLogic> cards)
        {
            if (IsFlush(cards))
            {
                int min = cards.Min(x => x.Rank);
                int max = cards.Max(x => x.Rank);
                return min == 9 && max == 13;
            }
            return false;
        }

        private bool IsStraigthFlush(IEnumerable<CardBusinessLogic> cards)
        {
            if (IsFlush(cards))
            {
                int min = cards.Min(x => x.Rank);
                int max = cards.Max(x => x.Rank);
                return max - min == 4;
            }
            return false;
        }

        private bool IsStraight(IEnumerable<CardBusinessLogic> cards)
        {
            int min = cards.Min(x => x.Rank);
            int max = cards.Max(x => x.Rank);
            return max - min == 4;
        }

        private bool IsFourOfAKind(IDictionary<int, int> ranksCount)
        {
            return ranksCount.Values.Max() == 4;
        }

        private bool IsFullHouse(IDictionary<int, int> ranksCount)
        {
            return ranksCount.Values.Max() == 3 && ranksCount.Values.Min() == 2;
        }

        private bool IsThreeOfAKind(IDictionary<int, int> ranksCount)
        {
            return ranksCount.Values.Max() == 3 && ranksCount.Values.Min() == 1;
        }

        private bool IsTwoPair(IDictionary<int, int> ranksCount)
        {
            return ranksCount.Values.Max() == 2 && ranksCount.Keys.Count == 3;
        }

        private bool IsJacksOrBetter(IDictionary<int, int> ranksCount)
        {
            return ranksCount.Keys.Count == 4
                && ranksCount.Keys.Where(x => ranksCount[x] == 2).Single() > 9;
        }
    }
}
