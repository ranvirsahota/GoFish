using System;
using System.Collections.Generic;
using System.Text;

namespace GoFish
{
    class UI
    {
        public String enterCardPlayerToFishFrom()
        {
            return verifyInput(Globals.CARD_PLAYER_NAMES, "Enter a card player name to fish from: ", "This name does not a name of a card player. Please try again.");
        }

        public String enterCardPlayerSeeking(List<string> cards) 
        {
            return verifyInput(cards, "Enter card to seek: ", "You do not have this card in your hand. Please try again.");
        }


        String verifyInput(List<String> array, string printLine, string errorMessage)
        {
            Console.Write(printLine);
            string userInput = Console.ReadLine().Trim();
            Boolean isInputCorrect = false;

            while (isInputCorrect == false)
            {
                foreach (String arrayElement in array)
                {
                    if (userInput.Equals(arrayElement))
                    {
                        isInputCorrect = true;
                    }
                }

                if (isInputCorrect == false) {
                    Console.WriteLine(errorMessage);
                    Console.Write(printLine);
                    userInput = Console.ReadLine();
                }
            }
            return userInput;
        }
    }
}
