using System.Collections.ObjectModel;

namespace GoFish
{
    public abstract class CardPlayer
    {
        public string Name { get; set; }
        public List<string> Books { get; set; } //group of same four cards
        public ObservableCollection<string> Log { get; set; }
        protected Dictionary<string, int> _cards; //current hand
        public int CardCount = 0;
        private string _cardSeeking;//card current player has asked another player for
        public CardPlayer(string name, ObservableCollection<string> log)
        {
            Name = name;
            Books = new List<string>();
            this.Log = log;
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

        public virtual void CardsSet(string cardToAdd, int cardCount = 1)
        {
            if (_cards.ContainsKey(cardToAdd))
            {
                _cards[cardToAdd] += cardCount;
                _findBook(cardToAdd);
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
        private void _removeCard(string cardToRemove)
        {
            CardCount -= _cards[cardToRemove];
            _cards.Remove(cardToRemove);
            if (Globals.PUBLICLY_KNOWN_CARDS[Name].Contains(cardToRemove))
            {
                Globals.PUBLICLY_KNOWN_CARDS[Name].Remove(cardToRemove);
            }
        }

        //should method be in main window
        private void _fishing(string fishFrom)
        {
/*            Globals.CARD_PLAYERS_FROM_TO_TRANSACTION[0] = Name;
            Globals.CARD_PLAYERS_FROM_TO_TRANSACTION[1] = fishFrom;
            Globals.CARD_TRANSACTION.Add(_cardSeeking, 0);*/

            Globals.CARD_TRANSACTION_NEW["fishing"] = Name;
            Globals.CARD_TRANSACTION_NEW["target"] = fishFrom;
            Globals.CARD_TRANSACTION_NEW["card"] = _cardSeeking;

/*            Globals.CARD_TRANSACTION_NEW = new Dictionary<string, dynamic>()
            {
                ["fishing"] = Name,
                ["target"] = fishFrom,
                ["card"] = _cardSeeking,
                ["amount"] = 0,

            };
*/
            Log.Add(Name + " fish for: " + _cardSeeking + " from " + fishFrom);
        }

        private void _handCards()
        {
            if (_cards.ContainsKey(_cardSeeking))
            {
                //Globals.CARD_TRANSACTION[_cardSeeking] = _cards[_cardSeeking];
                Globals.CARD_TRANSACTION_NEW["amount"] = _cards[_cardSeeking];
                Log.Add(Name + " got: " + _cardSeeking + " " + _cards[_cardSeeking]);
                _removeCard(_cardSeeking);
            }
        }
        private void _goFish()
        {
/*            Globals.CARD_TRANSACTION[_cardSeeking] = 0;
*/            Globals.CARD_TRANSACTION_NEW["amount"] = 0;
            Log.Add("Go Fish " + Globals.CARD_TRANSACTION_NEW["fishing"]);
        }

        //Looks for cards of four that are the same                                  
        private void _findBook(string cardToBook = null)
        {
            if (_cards[cardToBook] == 4)
            {
                _removeCard(cardToBook);
                Books.Add(cardToBook);
                Log.Add(Name + " book: " + cardToBook);
            }
        }
    }
}