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
            foreach (KeyValuePair<String, int> cardType in cards)
            {
                foreach (KeyValuePair<string, List<string>> publicCardsOfCardplayer in Globals.PUBLICLY_KNOWN_CARDS)
                {
                    if (!publicCardsOfCardplayer.Key.Equals(Name))
                    {
                        foreach (string public_knowncard in publicCardsOfCardplayer.Value)
                        {
                            if (cardType.Key.Equals(public_knowncard))
                            {
                                cardSeeking = public_knowncard;
                                fishFrom = publicCardsOfCardplayer.Key;
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
 