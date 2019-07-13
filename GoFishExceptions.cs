using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    public class GoFishExceptions : System.Exception
    {
        public GoFishExceptions(string message) : base(message) { }
    }
    public class CardPlayerDoesNotHaveCardType : GoFishExceptions
    {
        public CardPlayerDoesNotHaveCardType(string message) : base(message) { }
    }
    public class PlayerFishingHasNotSpecifedCardToFish : GoFishExceptions
    {
        public PlayerFishingHasNotSpecifedCardToFish(string message) : base(message) { }
    }
    public class CardPlayerDoesNotExsist : GoFishExceptions
    {
        public CardPlayerDoesNotExsist(string message) : base(message) { }
    }
}