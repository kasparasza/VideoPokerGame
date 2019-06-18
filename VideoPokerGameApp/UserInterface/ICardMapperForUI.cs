using System;
using System.Collections.Generic;
using System.Text;
using VideoPokerGameApp.Models;

namespace VideoPokerGameApp.UserInterface
{
    public interface ICardMapperForUI
    {
        string GetCardForUI(CardBusinessLogic card);
    }
}
