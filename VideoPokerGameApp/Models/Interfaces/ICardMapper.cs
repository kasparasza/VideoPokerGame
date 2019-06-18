using System;
using System.Collections.Generic;
using System.Text;

namespace VideoPokerGameApp.Models
{
    public interface ICardMapper
    {
        CardBusinessLogic MapCard(int card);
    }
}
