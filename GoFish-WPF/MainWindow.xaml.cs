using GoFishLibary;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace GoFish_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<CardPlayer> cardPlayersSource;
        public List<String> logSource;

        public MainWindow()
        {
            InitializeComponent();
            //Create Players
            Player player = new Player("You");
            cardPlayersSource = new List<CardPlayer>() { new AI("Archer"), new AI("Patrick"), player};
            cardPlayers.ItemsSource = cardPlayersSource;

            
            //Shuffle
            List<String> cards = new List<String>()
            {
                "ace",
                "ace",
                "ace",
                "ace",
                "two",
                "two",
                "two",
                "two",
                "three",
                "three",
                "three",
                "three",
                "four",
                "four",
                "four",
                "four",
                "five",
                "five",
                "five",
                "five",
                "six",
                "six",
                "six",
                "six",
                "nine",
                "nine",
                "nine",
                "nine",
                "ten",
                "ten",
                "ten",
                "ten",
                "jack",
                "jack",
                "jack",
                "jack",
                "queen",
                "queen",
                "queen",
                "queen",
                "king",
                "king",
                "king",
                "king",
                "seven",
                "seven",
                "seven",
                "seven",
                "eight",
                "eight",
                "eight",
                "eight",
            };
            var rnd = new Random();
            cards = cards.OrderBy(x => rnd.Next()).ToList<string>();
            
            //Deal Cards
            for (int counter = 1; counter <= 5; counter++)
            {
                foreach (CardPlayer cardPlayer in cardPlayersSource)
                {
                    cardPlayer.CardsSet(cards[0]);
                    cards.RemoveAt(0);
                }
            }
            hand.ItemsSource = player.getCards();
            Globals.Stack = cards;
            

            //Set log
            logSource = new List<String>();
            logSource.Add($"Stack : {Globals.Stack}");
            log.ItemsSource = logSource;

            //Game Movement



        }

        private void fishFor_Click(object sender, RoutedEventArgs e)
        {
            CardPlayer? player = cardPlayers.SelectedItem as CardPlayer;
            logSource.Add($"{player.Name}");
            log.Items.Refresh();
        }
    }
}