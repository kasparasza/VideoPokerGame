using System;
using System.Collections.Generic;
using System.Text;

namespace VideoPokerGameApp.Models
{
    public interface IEvaluator
    {
        HandCombination EvaluateHand(Hand hand);
    }
}
