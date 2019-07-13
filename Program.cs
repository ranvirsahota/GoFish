
namespace GoFish
{
    class Program
    {
        static void main(string[] args)
        {
            GameSetup gameSetup = new GameSetup();
            RunGame runGame = new RunGame(gameSetup.cardPlayers);
        }
    }
}
