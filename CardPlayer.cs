using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    public abstract class CardPlayer
    {
        public string Name { get; set; }
        public List<string> books { get; set; } //group of same four cards
        protected Dictionary<string, int> cards; //current hand
        public int cardCount = 0;
        private string cardSeeking;//card current player has asked another player for

        public CardPlayer(string name)
        {
            Name = name;
            books = new List<string>();
            cards = new Dictionary<string, int>() { };
            Globals.PUBLICLY_KNOWNcarDS.Add(Name, new List<string> { name });
            Globals.CardPlayerNames.Add(Name);
        }
        public virtual void Decision(bool isMyTurn, string cardSeeking = null, string fishFrom = null)
        {
            this.cardSeeking = cardSeeking;

            if (isMyTurn)
            {
                fishing(fishFrom);
            }
            else
            {
                goFishOrHandCards();
            }
        }

        public void CardsSet(string cardToAdd, int cardCount = 1)
        {
            if (cards.ContainsKey(cardToAdd))
            {
                cards[cardToAdd] += cardCount;
                tryToBook(cardToAdd);
            }
            else
            {
                cards.Add(cardToAdd, cardCount);
            }
            cardCount += cardCount;
        }
        private void goFishOrHandCards()
        {
            if (cards.ContainsKey(cardSeeking))
            {
                handCards();
            }
            else
            {
                goFish();
            } 
        }
        private string removeCard(string cardToRemove)
        {
            cardCount -= cards[cardToRemove];
            cards.Remove(cardToRemove);
            if (Globals.PUBLICLY_KNOWNcarDS[Name].Contains(cardToRemove))
            {
                Globals.PUBLICLY_KNOWNcarDS[Name].Remove(cardToRemove);
            }
            return cardToRemove;
        }

        private void fishing(string fishFrom)
        {
            Globals.CARD_PLAYERS_FROM_TO_TRANSACTION[0] = Name;
            Globals.CARD_PLAYERS_FROM_TO_TRANSACTION[1] = fishFrom;
            Globals.CARD_TRANSACTION.Add(cardSeeking, 0);
            Console.WriteLine(Name + " fish for: " + cardSeeking + " from " + fishFrom);
        }

        private void handCards()
        {
            if (cards.ContainsKey(cardSeeking))
            {
                Globals.CARD_TRANSACTION[cardSeeking] = cards[cardSeeking];
                Console.WriteLine(Name + " got: " + cardSeeking + " " + cards[cardSeeking]);
                removeCard(cardSeeking);
            }
        }
        private void goFish()
        {
            Globals.CARD_TRANSACTION[cardSeeking] = 0;
            Console.WriteLine("Go Fish " + Globals.CARD_PLAYERS_FROM_TO_TRANSACTION[0]);
        }
        //Looks for cards of four that are the same                                  
        private void tryToBook(string cardToBook = null)
        {
            if (cards[cardToBook] == 4)
            {
                removeCard(cardToBook);
                books.Add(cardToBook);
                Console.WriteLine(Name + "books: " + cardToBook);
            }
        }
    }
}