using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

// Link to GitHub Repo:
// https://github.com/Alison-Doyle/TiddlyWinksWorldCup

namespace TidldyWinksWordCup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Team> teams = new List<Team>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetData();
        }

        private void lbxTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePlayersListBox(lbxTeams.SelectedIndex);
        }

        private void btnRecordWin_Click(object sender, RoutedEventArgs e)
        {
            AddNewResultToPlayer('W');
        }

        private void btnRecordLoss_Click(object sender, RoutedEventArgs e)
        {
            AddNewResultToPlayer('L');
        }

        private void btnRecordDraw_Click(object sender, RoutedEventArgs e)
        {
            AddNewResultToPlayer('D');
        }

        private void lbxPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayPlayerRating();
        }

        private void UpdatePlayersListBox(int teamIndex)
        {
            List<Player> players = new List<Player>(teams[teamIndex].Players);
            lbxPlayers.ItemsSource = players;
        }

        private void GetData()
        {
            // Create sample teams
            Team t1 = new Team("France", new List<Player>());
            Team t2 = new Team("Italy", new List<Player>());
            Team t3 = new Team("Spain", new List<Player>());

            // Create sample players and add them to appropriate team
            Player p1 = new Player("Marie", "WWDDL");
            Player p2 = new Player("Claude", "DDDLW");
            Player p3 = new Player("Antoine", "LWDLW");
            t1.Players.Add(p1);
            t1.Players.Add(p2);
            t1.Players.Add(p3);

            Player p4 = new Player("Marco", "WWDLL");
            Player p5 = new Player("Giovanni", "LLLLD");
            Player p6 = new Player("Valentina", "DLWWW");
            t2.Players.Add(p4);
            t2.Players.Add(p5);
            t2.Players.Add(p6);

            Player p7 = new Player("Maria", "WWWWW");
            Player p8 = new Player("Jose", "LLLLL");
            Player p9 = new Player("Pablo", "DDDDD");
            t3.Players.Add(p7);
            t3.Players.Add(p8);
            t3.Players.Add(p9);

            // Add teams to teams observable collection
            teams.Add(t1);
            teams.Add(t2);
            teams.Add(t3);

            // Update listbox
            UpdateTeamsListBox();
        }
    
        private void AddNewResultToPlayer(char result)
        {
            int teamIndex = ValidateListBoxSelectedIndex(lbxTeams.SelectedIndex);
            int playerIndex = ValidateListBoxSelectedIndex(lbxPlayers.SelectedIndex);

            // Make sure there is an item slected in each listbox
            if (teamIndex != -1 && playerIndex != -1)
            {
                teams[teamIndex].Players[playerIndex].UpdateResultRecord(result);

                // Update UI to repersent changes
                DisplayPlayerRating();
                UpdatePlayersListBox(teamIndex);
            }
            else
            {
                MessageBox.Show("Please ensure you have selected a team and player before submitting a result", "Error");
            }
        }

        private int ValidateListBoxSelectedIndex(int selectedIndex)
        {
            int index = selectedIndex == null ? -1 : selectedIndex;

            return index;
        }

        private void UpdateTeamsListBox()
        {
            // Order teams in descending order by points
            teams.Sort();

            // Update listbox
            lbxTeams.ItemsSource = null;
            lbxTeams.ItemsSource = teams;
        }

        private void DisplayPlayerRating()
        {
            int teamIndex =  ValidateListBoxSelectedIndex(lbxTeams.SelectedIndex);
            int playerIndex = ValidateListBoxSelectedIndex(lbxPlayers.SelectedIndex);

            // Make sure a team and player is selected
            if (teamIndex != -1 && playerIndex != -1)
            {
                int playerPoints = teams[teamIndex].Players[playerIndex].Points;

                // Create star bitmaps
                BitmapImage outlinedStar = new BitmapImage();
                outlinedStar.BeginInit();
                outlinedStar.UriSource = new Uri("/resources/staroutline.PNG", UriKind.Relative);
                outlinedStar.EndInit();

                BitmapImage filledStar = new BitmapImage();
                filledStar.BeginInit();
                filledStar.UriSource = new Uri("/resources/starsolid.PNG", UriKind.Relative);
                filledStar.EndInit();

                // Set appropriate amount of stars (Need to change all stars each time to prevent leaving artifacts of previous player)
                if (playerPoints == 0)
                {
                    imgStar1.Source = outlinedStar;
                    imgStar2.Source = outlinedStar;
                    imgStar3.Source = outlinedStar;
                }
                else if ((playerPoints >= 1) && (playerPoints <= 5))
                {
                    imgStar1.Source = filledStar;
                    imgStar2.Source = outlinedStar;
                    imgStar3.Source = outlinedStar;
                }
                else if ((playerPoints >= 6) && (playerPoints <= 10))
                {
                    imgStar1.Source = filledStar;
                    imgStar2.Source = filledStar;
                    imgStar3.Source = outlinedStar;
                }
                else
                {
                    imgStar1.Source = filledStar;
                    imgStar2.Source = filledStar;
                    imgStar3.Source = filledStar;
                }
            }
        }
    }
}
