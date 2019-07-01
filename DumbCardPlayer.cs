using System;
using System.Collections.Generic;
using System.Text;

namespace GoFish
{
    //set memory capacity to 0
    class DumbCardPlayer : AI
    {
        public DumbCardPlayer(String name) : base(name) {}

        public override void Decision(bool isMyTurn, string cardSeeking, string fishFrom)
        {
            base.Decision(isMyTurn, cardSeeking, fishFrom);
        }
    }
}