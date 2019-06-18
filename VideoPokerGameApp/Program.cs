using System;
using System.Collections.Generic;
using System.IO;
using VideoPokerGameApp.Models;
using VideoPokerGameApp.Models.Interfaces;
using VideoPokerGameApp.UserInterface;

namespace VideoPokerGameApp
{
    class Program
    {
        private static readonly int NUMBER_OF_CARDS_IN_HAND = 5;
        private static readonly int NUMBER_OF_CARDS_IN_DECK = 52;

        static void Main(string[] args)
        {
            TextReader inputReader = Console.In;
            IGameInterface gameInterface = new GameInterface(NUMBER_OF_CARDS_IN_HAND);
            ICardShuffler shuffler = new CardShuffler();
            ICardDealer cardDealer = new CardDealer(NUMBER_OF_CARDS_IN_DECK, shuffler);
            ICardMapper cardMapper = new CardMapper();
            ICardMapperForUI cardMapperForUI = new CardMapperForUI();
            Hand hand = new Hand(NUMBER_OF_CARDS_IN_HAND);
            IEvaluator evaluator = new Evaluator(cardMapper);
            CombinationNameAndPayoutMapper resultMapper = new CombinationNameAndPayoutMapper();

            Game game = new Game(
                inputReader,
                gameInterface,
                cardDealer,
                cardMapper,
                cardMapperForUI,
                hand,
                evaluator,
                resultMapper);

            game.PlayGame();
        }
    }
}
