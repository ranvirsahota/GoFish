using System.Collections.ObjectModel;

namespace GoFish
{
    public static class Globals
    {
        public static Dictionary<string, List<string>> PUBLICLY_KNOWN_CARDS = new Dictionary<string, List<string>>();
/*        public static string[] CARD_PLAYERS_FROM_TO_TRANSACTION = new string[2];
        public static Dictionary<string, int> CARD_TRANSACTION = new Dictionary<string, int>();
*/        public static Dictionary<string, dynamic> CARD_TRANSACTION_NEW = new Dictionary<string, dynamic>()
        {
          /*["fishing"] = "", *player taking turn 
            ["target"] = "", *player who is being targeted
            ["card"] = "", *card player is looking for
            ["amount"] = 0, *amount of card of type "card" "target" player had on them
          */
        };
        public static List<string> Stack = new List<string>();
        public static List<string> CardPlayerNames = new List<string>();
    }
}