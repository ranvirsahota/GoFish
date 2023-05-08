using GoFishLibary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish_WPF
{
    internal class Player : CardPlayer
    {
        public Player(string name)  : base(name) { Name = name; }

        public override void Decsion(bool isMyTurn, string cardSeeking = null, string fishFrom = null)
        {
            base.Decsion(isMyTurn, cardSeeking, fishFrom);
        }

        public List<String> getCards()
        {
           List<String> cards = new List<String>();
            foreach (KeyValuePair<String, int> card in _cards)
            {
                for (int i = 0; i < card.Value; i++)
                {
                    cards.Add(card.Key);
                }
            }
            return cards;
        }
    }
}
