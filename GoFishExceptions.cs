namespace GoFish
{
    public class GoFishExceptions : System.Exception
    {
        public GoFishExceptions() { }
        public GoFishExceptions(string message) : base(message) { }
    }
    public class CardPlayerDoesNotHaveCardType : GoFishExceptions
    {
        public CardPlayerDoesNotHaveCardType() { }
        public CardPlayerDoesNotHaveCardType(string message) : base(message) { }
    }
    public class PlayerFishingHasNotSpecifedCardToFish : GoFishExceptions
    {
        public PlayerFishingHasNotSpecifedCardToFish() { }
        public PlayerFishingHasNotSpecifedCardToFish(string message) : base(message) { }
    }
}