 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    class Player : CardPlayer
    {
        private UI ui;
        public Player(string name) : base(name)
        {
            Name = name;
            ui = new UI();
        }


        public override void Decision(bool isMyTurn, string cardSeeking = null, string fishFrom = null)
        {
            while (true)
            {
                if (isMyTurn)
                {
                    Console.WriteLine(Name + " turn");
                    foreach (KeyValuePair<string, int> card in cards)
                    {
                        Console.WriteLine(card + " ");
                    }
                    fishFrom = ui.enterCardPlayerToFishFrom();
                    if (!Globals.CARD_PLAYER_NAMES.Contains(fishFrom))
                    {
                        throw new CardPlayerDoesNotExsist("Error " + Name);
                    }
                    cardSeeking = ui.enterCardPlayerSeeking(new List<string>(cards.Keys));
                    if (!cards.ContainsKey(cardSeeking))
                    {
                        throw new CardPlayerDoesNotHaveCardType("Error " + Name);
                    }
                }
                break;
            }
            base.Decision(isMyTurn, cardSeeking, fishFrom);
        }
    }
}