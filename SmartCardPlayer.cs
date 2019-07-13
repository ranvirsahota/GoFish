using System;
using System.Collections.Generic;
using System.Text;

namespace GoFish
{
    class SmartCardPlayer : AI
    {
        public SmartCardPlayer(string name) : base(name){}

        public override void Decision(bool isMyTurn, string cardSeeking, string fishFrom)
        {
            foreach (KeyValuePair<String, int> cardType in _cards)
            {
                foreach (KeyValuePair<string, List<string>> public_cards_of_cardplayer in Globals.PUBLICLY_KNOWN_CARDS)
                {
                    if (!public_cards_of_cardplayer.Key.Equals(Name))
                    {
                        foreach (string public_known_card in public_cards_of_cardplayer.Value)
                        {
                            if (cardType.Key.Equals(public_known_card))
                            {
                                cardSeeking = public_known_card;
                                fishFrom = public_cards_of_cardplayer.Key;
                                break;
                            }
                        }
                    }
                    if (!(cardSeeking == null && fishFrom == null)) { break; }
                }
                if (!(cardSeeking == null && fishFrom == null)) { break; }
            }
            base.Decision(isMyTurn, cardSeeking, fishFrom);
        }
    }
}
 