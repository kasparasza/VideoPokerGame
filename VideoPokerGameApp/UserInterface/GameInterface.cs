using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using VideoPokerGameApp.Models;

namespace VideoPokerGameApp.UserInterface
{
    public class GameInterface : IGameInterface
    {
        private readonly string SEPARATOR_LINE = "---------------------------------------------------------------------------------------";
        private readonly string LINE_INDENT = "    ";
        private readonly int numberOfCards;

        public GameInterface(int numberOfCards)
        {
            this.numberOfCards = numberOfCards;
        }


        public void DisplayInitialInformation()
        {
            string message =
                "Welcome to Video Poker Game!" + "\n" +
                "\n" +
                "Five cards will be dealt. Then you will have an opportunity to discard one or more cards." + "\n" +
                "Discarded cards will replaced with new ones. After that your combination will be evaluated." + "\n" +
                "Payoffs begin at a pair of jacks. Good luck!" + "\n" +
                "\n" +
                "Cards will be dealt after you press any key." + "\n";

            Console.WriteLine(message);
            Console.ReadKey();
        }

        public void DisplayCards(string[] cards)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SEPARATOR_LINE).Append("\n");
            sb.Append("Your current cards are:").Append("\n").Append("\n");

            for (int i = 0; i < cards.Length; i++)
            {
                sb.Append(LINE_INDENT + (i + 1) + ": " + cards[i]).Append("\n");
            }

            Console.WriteLine(sb);
        }

        public IEnumerable<int> GetCardsToBeDiscarded(TextReader reader)
        {
            string message =
                "If you want to keep all the cards, press 'Enter'" + "\n" +
                "Or enter numbers for the cards you would like to discard, each separated with space." + "\n" +
                "Press 'Enter' when done." + "\n" +
                "\n" +
                "Your input: ";

            Console.Write(message);
            IEnumerable<int> userInput = ReadUserInput(reader);
            return userInput;
        }

        private IEnumerable<int> ReadUserInput(TextReader reader)
        {
            string inputRaw = reader.ReadLine();
            List<int> input = new List<int>();          

            if(!String.IsNullOrEmpty(inputRaw))
            {
                string[] inputValues = inputRaw.Trim().Split(" ");

                foreach (string str in inputValues)
                {
                    int number;
                    bool success = int.TryParse(str, out number);

                    if (success && IsValidNumber(number))
                    {
                        input.Add(number);
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            input = (input.Count > this.numberOfCards) ? TruncateInputs(input, numberOfCards) : input;
            return input;
        }

        private bool IsValidNumber (int input)
        {
            return input >= 1 && input <= 5;
        }

        private List<int> TruncateInputs(List<int> inputsBefore, int maxCount)
        {
            return inputsBefore.GetRange(0, maxCount);
        }

        public void DisplayInfoAboutCardsDiscarded(IEnumerable<int> cardsDiscarded)
        {
            string discarded = string.Join(" ", cardsDiscarded.ToArray());
            string message =
                "\n" +
                $"These cards were discarded: {discarded}." + "\n";
            Console.WriteLine(message);
        }

        public void DisplayGameResult(CombinationAndPayout result)
        {
            string messageForNoWin =
                "Unfortunately your cards are not successfull." + "\n" +
                "Try your luck again!";
            string messageForSuccess =
                $"Great! You have collected {result.name}!" + "\n" +
                $"Your prize amount is {result.payout}!";
            string resultMessage = (result.payout == 0) ? messageForNoWin : messageForSuccess;

            StringBuilder sb = new StringBuilder();
            sb.Append("\n");
            sb.Append(SEPARATOR_LINE).Append("\n").Append("\n");
            sb.Append("Time for results!").Append("\n").Append("\n");
            sb.Append(resultMessage).Append("\n").Append("\n");
            sb.Append("Press any key to end the game.");

            Console.WriteLine(sb);
            Console.ReadKey();
        }
    }
}
