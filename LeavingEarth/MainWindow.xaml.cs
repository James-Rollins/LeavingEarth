using System;
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
using System.Xml;

namespace LeavingEarth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game currentGame = new Game();
        Player currentPlayer = new Player();

        public MainWindow()
        {

            InitializeComponent();

            currentPlayer.Setup();
            UpdateBoxes();
            currentGame.Turn(currentPlayer);


        }


        private void endTurn_Click(object sender, RoutedEventArgs e)
        {
            if (currentGame.Year < 1976)
            {
                currentGame.EndTurn();
                currentPlayer.EndTurn();
                UpdateBoxes();
                currentGame.Turn(currentPlayer);
            }
        }



        private void UpdateBoxes()
        {
            yearBox.Text = Convert.ToString(currentGame.Year);
            fundingBox.Text = Convert.ToString(currentPlayer.Funding);
            scoreBox.Text = Convert.ToString(currentPlayer.Score);
        }

        private void Leaving_Earth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                if (MainMenu.Visibility == Visibility.Hidden)
                {
                    MainMenu.Visibility = Visibility.Visible;
                }
                else
                {
                    MainMenu.Visibility = Visibility.Hidden;
                }
            }
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Visibility = Visibility.Hidden;
            DifficultyMenu.Visibility = Visibility.Visible;
        }

        private void Difficulty(object sender, RoutedEventArgs e)
        {
            int i = 0;
            string difficulty = sender.ToString();
            List<string> Sources = new List<string>();

            currentGame.SetUp(difficulty);
            Sources = currentGame.MissionSources();

            foreach (string source in Sources)
            {
                i++;
                string name = "Image" + i.ToString();
                Image image = (Image)FindName(name);
                image.Source = new BitmapImage(new Uri("pack://application:,,,/LeavingEarth;component/" + source, UriKind.Absolute));
                image.Visibility = Visibility.Visible;

            }
            DifficultyMenu.Visibility = Visibility.Hidden;
            AgencyMenu.Visibility = Visibility.Visible;
        }



        private void AgencySelection(object sender, RoutedEventArgs e)
        {
            AgencyMenu.Visibility = Visibility.Hidden;

            var button = (Button)sender;
            string name = button.Name;
            string Agency = "";
            
            for (int i = 0; i < 4; i++)
            {
                Agency = "Images/" + name + (i + 1).ToString() + ".jpg";
                Image image = (Image)FindName("Craft" + (i + 1).ToString());
                image.Source = new BitmapImage(new Uri("pack://application:,,,/LeavingEarth;component/" + Agency, UriKind.Absolute));
            }
            Home.Visibility = Visibility.Visible;

            
        }

        private void Exit_Game_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
