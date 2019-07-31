using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoFish
{
    class RunGame
    {
        public RunGame(Dictionary<String, CardPlayer> cardPlayers)
        {

            CardPlayer currentWinner = null;
            do
            {
                foreach (KeyValuePair<string, CardPlayer> cardPlayer in cardPlayers)
                {
                    if (currentWinner == null) { currentWinner = cardPlayer.Value; }

                    if (currentWinner.Books.Count < cardPlayer.Value.Books.Count) { currentWinner = cardPlayer.Value; }
                    for (int i = 0; i < 1;)
                    {
                        string cardSeeking = null;
                        int cardSeekingAmount = 0;

                        if (cardPlayer.Value.CardCount == 0)
                        {
                            if (Globals.STACK.Count >= 1)
                            {
                                cardPlayer.Value.CardsSet(Globals.STACK[0]);
                                Console.WriteLine(cardPlayer.Key + "got a: " + Globals.STACK[0]);
                                Globals.PUBLICLY_KNOWN_CARDS[cardPlayer.Key].Add(Globals.STACK[0]);
                                Globals.STACK.Remove(Globals.STACK[0]);
                            }
                            else
                            {
                                Globals.CARD_PLAYER_NAMES.Remove(cardPlayer.Key);
                                Globals.PUBLICLY_KNOWN_CARDS.Remove(cardPlayer.Key);
                                break;
                            }
                        }

                        cardPlayer.Value.Decision(true);

                        cardSeeking = Globals.CARD_TRANSACTION.Keys.First();
                        if (!Globals.PUBLICLY_KNOWN_CARDS[cardPlayer.Key].Contains(cardSeeking)) { Globals.PUBLICLY_KNOWN_CARDS[cardPlayer.Key].Add(cardSeeking); }
                        cardPlayers[Globals.CARD_PLAYERS_FROM_TO_TRANSACTION[1]].Decision(false, cardSeeking);

                        cardSeekingAmount = Globals.CARD_TRANSACTION[Globals.CARD_TRANSACTION.Keys.First()];

                        if (cardSeekingAmount > 0) { cardPlayer.Value.CardsSet(cardSeeking, cardSeekingAmount); }

                        else
                        {
                            if (Globals.STACK.Count >= 1)
                            {
                                cardPlayer.Value.CardsSet(Globals.STACK[0]);
                                Console.WriteLine("I got a: " + Globals.STACK[0]);
                                Globals.PUBLICLY_KNOWN_CARDS[cardPlayer.Key].Add(Globals.STACK[0]);
                                if (Globals.STACK[0] != cardSeeking)
                                {
                                    i++;
                                    Console.WriteLine("Not a match");
                                }
                                Globals.STACK.Remove(Globals.STACK[0]);
                            }
                            else
                            {
                                i++;
                            }
                        }

                        Console.ReadLine();

                        Globals.CARD_TRANSACTION.Remove(cardSeeking);
                        Globals.CARD_PLAYERS_FROM_TO_TRANSACTION[1] = null;
                        Globals.CARD_PLAYERS_FROM_TO_TRANSACTION[0] = null;
                    }
                }
            } while (Globals.CARD_PLAYER_NAMES.Count > 1);
            Console.WriteLine("Card Player: " + currentWinner.Name);
            Console.WriteLine("Card in stack: " + Globals.STACK.Count);
            Console.WriteLine(String.Format("{0} has {1} books", currentWinner.Name, currentWinner.Books.Count));
            Console.ReadLine();
        }
    }
}
