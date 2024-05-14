using System.Collections.ObjectModel;

namespace GoFish
{
    class Player : CardPlayer
    {
        private ObservableCollection<string> _hand;

        public ObservableCollection<string> Hand
        {
            get { return _hand; }
            set {_hand = value; }
        }

        public Player(string name, ObservableCollection<string> log) : base(name, log) {

            Name = name;
            Hand = new ObservableCollection<string>();
        }



        public override void Decsion(bool isMyTurn, string cardSeeking = null, string fishFrom = null)
        {
            base.Decsion(isMyTurn, cardSeeking, fishFrom);
            if (!isMyTurn) { _removeObservableHand(cardSeeking, Globals.CARD_TRANSACTION_NEW["amount"]); }
        }

        public override void CardsSet(string cardToAdd, int cardCount = 1)
        {
            base.CardsSet(cardToAdd, cardCount);

            if (Books.Contains(cardToAdd))
            {
                _removeObservableHand(cardToAdd, 4 - cardCount);
            }
            else
            {
                for (int i = 0; i < cardCount; i++)
                {
                    Hand.Add(cardToAdd);
                }
            }

        }

        private void _removeObservableHand(string card, int amount)
        {
            for (int i = 1; i <= amount;)
            {
                i = Hand.Remove(card) ? i + 1 : i;
            }
        }
    }
}