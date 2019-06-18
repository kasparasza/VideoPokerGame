using System;
using System.Collections.Generic;
using System.Text;
using VideoPokerGameApp.Models.Enums;

namespace VideoPokerGameApp.Models
{
    public class CardBusinessLogic
    {
        public CardSuit Suit { get; set; }
        public int Rank { get; set; }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                CardBusinessLogic compared = (CardBusinessLogic)obj;
                return (this.Suit == compared.Suit) && (this.Rank == compared.Rank);
            }
        }

        public override int GetHashCode()
        {
            return this.Rank * this.Suit.GetHashCode(); 
        }
    }
}
