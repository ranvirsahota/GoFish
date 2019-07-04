using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
