using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    class AI : CardPlayer
    {
        public AI(string name) : base(name) { }

        public override void Decsion(bool isMyTurn, string cardSeeking = null, string fishFrom = null)
        {
            if (isMyTurn)
            {
                Console.WriteLine(Name + " turn");
                foreach (KeyValuePair<String, int> cardType in _cards)
                {
                    foreach (KeyValuePair<string, List<string>> public_cards_of_cardplayer in Globals.PUBLICLY_KNOWN_CARDS)
                    {
                        foreach (string public_known_card in public_cards_of_cardplayer.Value)
                         {
                            if (cardType.Key.Equals(public_known_card))
                            {
                                public_cards_of_cardplayer.Value.RemoveAll(card => public_known_card.Equals(card));
                                fishFrom = public_cards_of_cardplayer.Key;
                                cardSeeking = public_known_card;
                                goto End;
                            }
                        }
                    }
                }
                if (cardSeeking == null || fishFrom == null) {
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
            }
            End:
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