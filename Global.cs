using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    public static class Globals
    {
        public static Dictionary<string, List<string>> PUBLICLY_KNOWN_CARDS = new Dictionary<string, List<string>>();
        public static string[] CARD_PLAYERS_FROM_TO_TRANSACTION = new string[2];
        public static Dictionary<string, int> CARD_TRANSACTION = new Dictionary<string, int>();
        public static List<string> STACK = new List<string>();
        public static List<string> CARD_PLAYER_NAMES = new List<string>();
    }
}