using System.Collections.ObjectModel;

namespace GoFish
{
    class AI : CardPlayer
    {

        public AI(string name, ObservableCollection<string> log) : base(name, log) { }

        public override void Decsion(bool isMyTurn, string cardSeeking = null, string fishFrom = null)
        {
            if (isMyTurn)
            {
                Log.Add(Name + " turn");
                int i = new Random().Next(0, Globals.CardPlayerNames.Count - 1);
                if (Name == Globals.CardPlayerNames[i])
                {
                    if (i == 0) { i++; }
                    else if (i == Globals.CardPlayerNames.Count - 1) { i--; }
                    else { i++; }
                }
                fishFrom = Globals.CardPlayerNames[i];
                cardSeeking = FindHighestCard();
            }
            base.Decsion(isMyTurn, cardSeeking, fishFrom);
        }

        private String FindHighestCard()
        {
            KeyValuePair<string, int> highestCard = new KeyValuePair<string, int>(null, 0);
            foreach (KeyValuePair<string, int> cardType in _cards)
            {
                if (cardType.Value > highestCard.Value) { highestCard = new KeyValuePair<string, int>(cardType.Key, cardType.Value); }
            }
            return highestCard.Key;
        }
    }
}