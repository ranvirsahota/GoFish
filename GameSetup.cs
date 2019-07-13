using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoFish
{
    class GameSetup
    {
        public List<string> cards;
        public Dictionary<string, CardPlayer> cardPlayers;
        private AIFactory aiFactory;

        public GameSetup()
        {
            aiFactory = new AIFactory();
        }

        private void createCardes()
        {
            cards = new List<string>()
            {
                "ace", "ace", "ace", "ace",
                "two", "two", "two", "two",
                "three", "three", "three", "three",
                "four", "four", "four", "four",
                "five", "five", "five", "five",
                "six", "six", "six", "six",
                "nine", "nine", "nine", "nine",
                "ten", "ten", "ten", "ten",
                "jack", "jack", "jack", "jack",
                "queen", "queen", "queen", "queen",
                "king", "king", "king", "king",
                "seven", "seven", "seven", "seven",
                "eight", "eight", "eight", "eight"
            };
        }

        private void shufflecards()
        {
            cards = cards.OrderBy(x => new Random().Next()).ToList<string>();
        }

        private void createAICardPlayers(string userInputAIName, string userInputAIType)
        {
            cardPlayers.Add(userInputAIName, aiFactory.makeAI(userInputAIName, userInputAIType));
        }

        private void handCards()
        {
            for (int counter = 1; counter == 5; counter++)
            {
                foreach (KeyValuePair<string, CardPlayer> cardPlayer in cardPlayers)
                {
                    cardPlayer.Value.CardsSet(cards[0]);
                    cards.RemoveAt(0);
                }
            }
        }

        private void makeStack()
        {
            Globals.Stack = cards;
        }
    }
}