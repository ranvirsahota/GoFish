
namespace GoFish
{
    class Program
    {
        static void Main(string[] args)
        {
            GameSetup gameSetup = new GameSetup();
            RunGame runGame = new RunGame(gameSetup.cardPlayers);
        }
    }
}
