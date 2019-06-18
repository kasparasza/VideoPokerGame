using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using VideoPokerGameApp.UserInterface;

namespace VideoPokerGameApp.Models
{
    public class Game
    {
        private readonly TextReader inputReader;
        private readonly IGameInterface gameInterface;
        private readonly ICardDealer cardDealer;
        private readonly ICardMapper cardMapper;
        private readonly ICardMapperForUI cardMapperForUI;
        private Hand hand;
        private readonly IEvaluator evaluator;
        private readonly CombinationNameAndPayoutMapper resultMapper;

        public Game(
            TextReader inputReader, 
            IGameInterface gameInterface,
            ICardDealer cardDealer,
            ICardMapper cardMapper,
            ICardMapperForUI cardMapperForUI,
            Hand hand,
            IEvaluator evaluator,
            CombinationNameAndPayoutMapper resultMapper)
        {
            this.inputReader = inputReader;
            this.gameInterface = gameInterface;
            this.cardDealer = cardDealer;
            this.cardMapper = cardMapper;
            this.cardMapperForUI = cardMapperForUI;
            this.hand = hand;
            this.evaluator = evaluator;
            this.resultMapper = resultMapper;
        }

        public void PlayGame()
        {
            gameInterface.DisplayInitialInformation();
            this.hand = DealCards(this.hand, new List<int> {1, 2, 3, 4, 5}, this.cardDealer);

            string[] cardsForDisplay = GetCardsForDisplay(this.hand, this.cardMapper, this.cardMapperForUI);           
            gameInterface.DisplayCards(cardsForDisplay);

            IEnumerable<int> cardsToBeDiscarded = gameInterface.GetCardsToBeDiscarded(this.inputReader);
            if(cardsToBeDiscarded.Count() > 0)
            {
                gameInterface.DisplayInfoAboutCardsDiscarded(cardsToBeDiscarded);
                this.hand = DealCards(this.hand, cardsToBeDiscarded, this.cardDealer);
                string[] updatedCardsForDisplay = GetCardsForDisplay(this.hand, this.cardMapper, this.cardMapperForUI);
                gameInterface.DisplayCards(updatedCardsForDisplay);
            }

            HandCombination gameResult = this.evaluator.EvaluateHand(this.hand);
            CombinationAndPayout resultForDisplay = this.resultMapper.GetCombinationNameAndPayout(gameResult);
            gameInterface.DisplayGameResult(resultForDisplay);
        }

        private Hand DealCards(Hand handToDeal, IEnumerable<int> cardPositionsToBeDealt, ICardDealer dealer)
        {
            foreach (int position in cardPositionsToBeDealt)
            {
                handToDeal.SetCardByPosition(position, dealer.GetNextCardFromDeck());
            }
            return handToDeal;
        }

        private string[] GetCardsForDisplay(Hand handToDisplay, ICardMapper cardMapper, ICardMapperForUI cardMapperForUI)
        {
            int[] cardsInHand = handToDisplay.GetAllCards();
            CardBusinessLogic[] cardsForBusinessLogic = new CardBusinessLogic[cardsInHand.Length];
            for (int i = 0; i < cardsInHand.Length; i++)
            {
                cardsForBusinessLogic[i] = cardMapper.MapCard(cardsInHand[i]);
            }

            string[] cardsForDisplay = new string[cardsForBusinessLogic.Length];
            for (int i = 0; i < cardsForBusinessLogic.Length; i++)
            {
                cardsForDisplay[i] = cardMapperForUI.GetCardForUI(cardsForBusinessLogic[i]);
            }

            return cardsForDisplay;
        }



    } 
}
