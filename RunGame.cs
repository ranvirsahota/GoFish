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

                    if (currentWinner.books.Count < cardPlayer.Value.books.Count)
                    {
                        currentWinner = cardPlayer.Value;
                    }
                    for (int i = 0; i < 1;)
                    {
                        string cardSeeking = null;
                        int cardSeekingAmount = 0;

                        if (cardPlayer.Value.cardCount == 0)
                        {
                            if (Globals.Stack.Count >= 1)
                            {
                                cardPlayer.Value.CardsSet(Globals.Stack[0]);
                                Console.WriteLine("I got a: " + Globals.Stack[0]);
                                Globals.PUBLICLY_KNOWNcarDS[cardPlayer.Key].Add(Globals.Stack[0]);
                                Globals.Stack.Remove(Globals.Stack[0]);
                            }
                            else
                            {
                                Globals.CardPlayerNames.Remove(cardPlayer.Key);
                                Globals.PUBLICLY_KNOWNcarDS.Remove(cardPlayer.Key);
                                break;
                            }
                        }
                        try
                        {
                            cardPlayer.Value.Decision(true);
                        }
                        catch (CardPlayerDoesNotHaveCardType ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }
                        cardSeeking = Globals.CARD_TRANSACTION.Keys.First();
                        if (!Globals.PUBLICLY_KNOWNcarDS[cardPlayer.Key].Contains(cardSeeking)) { Globals.PUBLICLY_KNOWNcarDS[cardPlayer.Key].Add(cardSeeking); }
                        cardPlayers[Globals.CARD_PLAYERS_FROM_TO_TRANSACTION[1]].Decision(false, cardSeeking);

                        cardSeekingAmount = Globals.CARD_TRANSACTION[Globals.CARD_TRANSACTION.Keys.First()];

                        if (cardSeekingAmount > 0) { cardPlayer.Value.CardsSet(cardSeeking, cardSeekingAmount); }

                        else
                        {
                            if (Globals.Stack.Count >= 1)
                            {
                                cardPlayer.Value.CardsSet(Globals.Stack[0]);
                                Console.WriteLine("I got a: " + Globals.Stack[0]);
                                Globals.PUBLICLY_KNOWNcarDS[cardPlayer.Key].Add(Globals.Stack[0]);
                                if (Globals.Stack[0] != cardSeeking)
                                {
                                    i++;
                                    Console.WriteLine("Not a match");
                                }
                                Globals.Stack.Remove(Globals.Stack[0]);
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
            } while (Globals.CardPlayerNames.Count > 1);
            Console.WriteLine("Card Player: " + currentWinner.Name);
            Console.ReadLine();
        }
    }
}
