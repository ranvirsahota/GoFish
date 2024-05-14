using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoFish
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> cards;
        private Dictionary<string, CardPlayer> cardPlayers;

        public CardPlayer currentWinner;
        public CardPlayer currentCardPlayer;
        public ObservableCollection<string> Hand { get; set; }
        public ObservableCollection<string> AINames { get; set; }
        public ObservableCollection<string> Log { get; set; }

        public MainWindow()
        {
            DataContext = this;
            Log = new ObservableCollection<string>();
            cards = new List<string>() {
            "ace", "ace", "ace", "ace",
            "two", "two", "two", "two",
            "three", "three", "three", "three",
            "four", "four", "four", "four",
            "five", "five", "five", "five",
            "six", "six", "six", "six",

            };

            /*
             *             "nine", "nine", "nine", "nine",
             "ten", "ten", "ten", "ten",
             "jack", "jack", "jack", "jack",
             "queen", "queen", "queen", "queen",
             "king", "king", "king", "king"
                         "seven", "seven", "seven", "seven",
            "eight", "eight", "eight", "eight",*/

            var rnd = new Random();
            cards = cards.OrderBy(x => rnd.Next()).ToList<string>();
            cardPlayers = new Dictionary<string, CardPlayer>() {
                {"Player", new Player("Player", Log)},
                {"Jack", new AI("Jack", Log)},
                {"Archer", new AI("Archer", Log)},
                {"Mr Pickles", new AI("Mr Pickles", Log)}
            };
            randomizeOrder();
            for (int counter = 1; counter < 5; counter++)
            {
                foreach (KeyValuePair<string, CardPlayer> cardPlayer in cardPlayers)
                {
                    cardPlayer.Value.CardsSet(cards[0]);
                    cards.RemoveAt(0);
                }
            }

            Globals.Stack = cards;
            currentCardPlayer = cardPlayers[Globals.CardPlayerNames[0]];
            currentWinner = currentCardPlayer;
            AINames = new ObservableCollection<string>(Globals.CardPlayerNames);     
            AINames.Remove("Player");
            Hand = (cardPlayers["Player"] as Player)!.Hand;
            InitializeComponent();
            fish.Content = $"{currentCardPlayer.Name}'s Turn To Fish";
            
        }

        private void takeTurn()
        {
            if (currentWinner.Books.Count < currentCardPlayer.Books.Count) { currentWinner = currentCardPlayer; }
            if (Globals.CardPlayerNames.Count == 0)
            {
                fish.IsEnabled = false;
                MessageBox.Show($"Winner is: {currentWinner.Name} with {currentWinner.Books.Count} books");
                Log.Add($"********************************GAME OVER********************************");
                foreach (CardPlayer cardPlayer in cardPlayers.Values)
                {
                    Log.Add($"{cardPlayer.Name} had {cardPlayer.Books.Count} Books");
                }
                
                return;
            }
            if (currentCardPlayer.CardCount == 0)
            {
                if (Globals.Stack.Count >= 1)
                {
                    currentCardPlayer.CardsSet(Globals.Stack[0]);
                    Log.Add("I got a: " + Globals.Stack[0]);
                    Globals.Stack.Remove(Globals.Stack[0]);
                }
                else
                {

                    MessageBox.Show($"{currentCardPlayer.Name} is out!");
                    Globals.CardPlayerNames.Remove(currentCardPlayer.Name);
                    AINames.Remove(currentCardPlayer.Name);
                    nextTurn();
                }

                return;
            }
            if (currentCardPlayer is Player)
            {
                currentCardPlayer.Decsion(true, cardSeeking: hand.SelectedValue.ToString()!, fishFrom: ai_names.SelectedValue.ToString()!);
                hand.UnselectAll();
                ai_names.UnselectAll();

            }
            else
            {
                currentCardPlayer.Decsion(true);
            }
            string cardSeeking = Globals.CARD_TRANSACTION_NEW["card"];

            cardPlayers[Globals.CARD_TRANSACTION_NEW["target"]].Decsion(false, cardSeeking);

            if (Globals.CARD_TRANSACTION_NEW["amount"] > 0)
            {
                currentCardPlayer.CardsSet(cardSeeking, Globals.CARD_TRANSACTION_NEW["amount"]);
            }

            else
            {
                if (Globals.Stack.Count >= 1)
                {
                    currentCardPlayer.CardsSet(Globals.Stack[0]);
                    Log.Add("I got a: " + Globals.Stack[0]);
                    if (Globals.Stack[0] != cardSeeking)
                    {
                        nextTurn();
                        Log.Add("Not a match");
                    }
                    Globals.Stack.Remove(Globals.Stack[0]);
                }
                else
                {
                    nextTurn();
                }
            }
/*            Globals.CARD_TRANSACTION.Remove(cardSeeking);
            Globals.CARD_PLAYERS_FROM_TO_TRANSACTION[1] = null;
            Globals.CARD_PLAYERS_FROM_TO_TRANSACTION[0] = null;*/


        }
        private void randomizeOrder()
        {
            Random rng = new Random();
            int n = Globals.CardPlayerNames.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                String value = Globals.CardPlayerNames[k];
                Globals.CardPlayerNames[k] = Globals.CardPlayerNames[n];
                Globals.CardPlayerNames[n] = value;
            }
        }
        private void nextTurn()
        {
            switch (Globals.CardPlayerNames.Count)
            {
                case 0:
                    fish.Content = "CLICK TO FIND WINNER!";
                    return;
                case 1:
                    currentCardPlayer = cardPlayers[Globals.CardPlayerNames[0]];
                    break;
                case > 1:
                    int index = Globals.CardPlayerNames.IndexOf(currentCardPlayer.Name);
                    index = index == Globals.CardPlayerNames.Count - 1 ? 0 : index + 1;
                    currentCardPlayer = cardPlayers[
                        Globals.CardPlayerNames[index]
                    ];
                    break;
            }
            fish.Content = $"{currentCardPlayer.Name}'s Turn To Fish";
        }

        private void fish_Click(object sender, RoutedEventArgs e)
        {
            if (currentCardPlayer is Player && currentCardPlayer.CardCount >= 1 &&
                (hand.SelectedValue == null || ai_names.SelectedValue == null))
            {
                MessageBox.Show("Player must select both a card to fish for and a target");
                return; 
            }

            takeTurn();
        }


    }
}