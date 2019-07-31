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

        private CardPlayerFactory cardPlayerFactory;
        public GameSetup()
        {
            cardPlayers = new Dictionary<string, CardPlayer>();
            cardPlayerFactory = new CardPlayerFactory();           
            createCardPlayers("Smart AI", "Jack");
            createCardPlayers("Dumb AI", "Richard");
            createCardPlayers("Player", "Bill");
            createCardPlayers("Smart AI", "Jake");

            createCards();
            shufflecards();
            handCards();
            makeStack();

        }

        private void createCards()
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

        private void shufflecards() { cards = cards.OrderBy(x => new Random().Next()).ToList<string>(); }

        private void createCardPlayers(string cardPlayerType, string cardPlayerName)
        {
            cardPlayers.Add(cardPlayerName, cardPlayerFactory.makeCardPlayer(cardPlayerType, cardPlayerName));
        }

        private void handCards()
        {
            for (int counter = 1; counter <= 5; counter++)
            {
                Console.WriteLine(counter);
                foreach (KeyValuePair<string, CardPlayer> cardPlayer in cardPlayers)
                {
                    Console.WriteLine(String.Format("{0} goes to {1}", cards[0], cardPlayer.Key));

                    cardPlayer.Value.CardsSet(cards[0]);
                    cards.RemoveAt(0);
                }
            }
        }

        private void makeStack()
        {
            Globals.STACK = cards;
        }
    }
}