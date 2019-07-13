using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    abstract class AI : CardPlayer
    {
        public AI(string name) : base(name) { }

        public override void Decision(bool isMyTurn, string cardSeeking, string fishFrom)
        {
            if (isMyTurn && (cardSeeking == null && fishFrom == null))
            {
                cardSeeking = selectRandomCard();
                fishFrom = findHighestCard();                                                                                                 
            }
            base.Decision(isMyTurn, cardSeeking, fishFrom);
        }

        private String selectRandomCard()
        {
            int i = new Random().Next(0, Globals.CARD_PLAYER_NAMES.Count - 1);
            if (Name == Globals.CARD_PLAYER_NAMES[i])
            {
                if (i == 0) { i++; }
                else if (i == Globals.CARD_PLAYER_NAMES.Count - 1) { i--; }
                else { i++; }
            }
           return Globals.CARD_PLAYER_NAMES[i];
        }

        private String findHighestCard()
        {
            KeyValuePair<string, int> highestCard = new KeyValuePair<string, int>(null, 0);
            foreach (KeyValuePair<string, int> cardType in cards)
            {
                if (cardType.Value > highestCard.Value) { highestCard = new KeyValuePair<string, int>(cardType.Key, cardType.Value); }
            }
            return highestCard.Key;
        }
    }
}