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
        public List<string> Books { get; set; } //group of same four cards
        protected Dictionary<string, int> _cards; //current hand
        public int CardCount = 0;
        private string _cardSeeking;//card current player has asked another player for

        public CardPlayer(string name)
        {
            Name = name;
            Books = new List<string>();
            _cards = new Dictionary<string, int>() { };
            Globals.PUBLICLY_KNOWN_CARDS.Add(Name, new List<string> { name });
            Globals.CardPlayerNames.Add(Name);
        }
        public virtual void Decsion(bool isMyTurn, string cardSeeking = null, string fishFrom = null)
        {
            _cardSeeking = cardSeeking;

            if (isMyTurn)
            {
                _fishing(fishFrom);
            }
            else
            {
                GoFishOrHandCards();
            }
        }

        public void CardsSet(string cardToAdd, int cardCount = 1)
        {
            if (_cards.ContainsKey(cardToAdd))
            {
                _cards[cardToAdd] += cardCount;
                _tryToBook(cardToAdd);
            }
            else { _cards.Add(cardToAdd, cardCount); }
            CardCount += cardCount;
        }
        private void GoFishOrHandCards()
        {
            if (_cards.ContainsKey(_cardSeeking))
            {
                _handCards();
            }
            else
            {
                _goFish();
            } 
        }
        private string _removeCard(string cardToRemove)
        {
            CardCount -= _cards[cardToRemove];
            _cards.Remove(cardToRemove);
            if (Globals.PUBLICLY_KNOWN_CARDS[Name].Contains(cardToRemove))
            {
                Globals.PUBLICLY_KNOWN_CARDS[Name].Remove(cardToRemove);
            }
            return cardToRemove;
        }

        private void _fishing(string fishFrom)
        {
            Globals.CARD_PLAYERS_FROM_TO_TRANSACTION[0] = Name;
            Globals.CARD_PLAYERS_FROM_TO_TRANSACTION[1] = fishFrom;
            Globals.CARD_TRANSACTION.Add(_cardSeeking, 0);
            Console.WriteLine(Name + " fish for: " + _cardSeeking + " from " + fishFrom);
        }

        private void _handCards()
        {
            if (_cards.ContainsKey(_cardSeeking))
            {
                Globals.CARD_TRANSACTION[_cardSeeking] = _cards[_cardSeeking];
                Console.WriteLine(Name + " got: " + _cardSeeking + " " + _cards[_cardSeeking]);
                _removeCard(_cardSeeking);
            }
        }
        private void _goFish()
        {
            Globals.CARD_TRANSACTION[_cardSeeking] = 0;
            Console.WriteLine("Go Fish " + Globals.CARD_PLAYERS_FROM_TO_TRANSACTION[0]);
        }
        //Looks for cards of four that are the same                                  
        private void _tryToBook(string cardToBook = null)
        {
            if (_cards[cardToBook] == 4)
            {
                _removeCard(cardToBook);
                Books.Add(cardToBook);
                Console.WriteLine(Name + "books: " + cardToBook);
            }
        }
    }
}