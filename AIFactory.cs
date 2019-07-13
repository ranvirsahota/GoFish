using System;
using System.Collections.Generic;
using System.Text;

namespace GoFish
{
    class AIFactory
    {
        public AI makeAI(string userInputAIName, String userInputAIType)
        {
            if (userInputAIType.Equals("Dumb AI")) {
                return new DumbCardPlayer(userInputAIName);
            }
            else
            {
                return new SmartCardPlayer(userInputAIName);
            }
        }
    }
}
