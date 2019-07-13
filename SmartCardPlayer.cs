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
                foreach (KeyValuePair<string, List<string>> publiccards_ofcardplayer in Globals.PUBLICLY_KNOWNcarDS)
                {
                    if (!publiccards_ofcardplayer.Key.Equals(Name))
                    {
                        foreach (string public_knowncard in publiccards_ofcardplayer.Value)
                        {
                            if (cardType.Key.Equals(public_knowncard))
                            {
                                cardSeeking = public_knowncard;
                                fishFrom = publiccards_ofcardplayer.Key;
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
 