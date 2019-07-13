using System;
using System.Collections.Generic;
using System.Text;

namespace GoFish
{
    class AIFactory
    {
        public AI makeAI(string AIType, string AIName)
        {
            if (AIType.Equals("Dumb AI"))
            {
                return new DumbCardPlayer(AIName);
            }

            else
            {
                return new SmartCardPlayer(AIName);
            }
        }
    }
}
